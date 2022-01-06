using AutoMapper;
using Data;
using Data.Entities;
using FragranceShopApi.Exceptions;
using FragranceShopApi.Models.PerfumeImage;
using FragranceShopApi.Models.PerfumeImg;
using FragranceShopApi.Services.Common;
using FragranceShopApi.Services.ImageProcess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Services
{
    public interface IPerfumeImageService : IScopedService
    {
        Task AddRange(int perfumeId, List<CreatePerfumeImageDto> dtos);
        void Update(int perfumeId, int perfumeImageId, UpdatePerfumeImageDto dto);
        void DeleteAll(int perfumeId);
        void Delete(int perfumeId, int perfumeImageId);
        List<PerfumeImageDto> GetAll(int perfumeId);
        PerfumeImageDto GetById(int perfumeId, int perfumeImageId);

    }
    public class PerfumeImageService : IPerfumeImageService
    {
        private readonly PerfumeDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPerfumeImageProcessService _perfumeImageProcessService;
        private readonly IPerfumeImageStaticFilesService _perfumeImageStaticFilesSerice;
        private readonly IHostService _hostService;

        public PerfumeImageService(
            PerfumeDbContext dbContext,
            IMapper mapper,
            IPerfumeImageProcessService perfumeImageProcessService,
            IPerfumeImageStaticFilesService perfumeImageStaticFilesService,
            IHostService hostService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _perfumeImageProcessService = perfumeImageProcessService;
            _perfumeImageStaticFilesSerice = perfumeImageStaticFilesService;
            _hostService = hostService;
        }

        public async Task AddRange(int perfumeId, List<CreatePerfumeImageDto> dtos)
        {
            var perfume = _dbContext
                .Perfumes
                .Where(p => p.Id == perfumeId)
                .Select(p => new
                {
                    BrandName = p.PerfumeBrand.Name,
                    PerfumeName = p.Name
                })
                .FirstOrDefault();

            if (perfume is null)
                throw new NotFoundException("Perfume not found");

            if (dtos.Any(p => p.IsPrimary))
            {
                var anyImageInDbIsPrimary = _dbContext.PerfumeImgs
                    .Where(p => p.PerfumeId == perfumeId)
                    .Any(p => p.IsPrimary);

                if (anyImageInDbIsPrimary)
                    throw new ConflictException("For the entered perfume exists an primary image");
            }

            var perfumeImgEntities = await _perfumeImageProcessService
                .Process(perfume.BrandName, perfume.PerfumeName, dtos);

            perfumeImgEntities.ForEach(image =>
            {
                image.PerfumeId = perfumeId;
            });

            _dbContext.AddRange(perfumeImgEntities);
            _dbContext.SaveChanges();
        }

        public void Update(int perfumeId, int perfumeImageId, UpdatePerfumeImageDto dto)
        {
            var perfume = _dbContext.Perfumes
                .Where(p => p.Id == perfumeId)
                .Select(p => new
                {
                    PerfumeImage = p.PerfumeImgs.FirstOrDefault(pi => pi.Id == perfumeImageId)
                })
                .FirstOrDefault();

            if (perfume is null)
                throw new NotFoundException("Perfume not found");

            if (perfume.PerfumeImage is null)
                throw new NotFoundException("Perfume image not found");

            _mapper.Map(dto, perfume.PerfumeImage);

            if (dto.IsPrimary)
            {
                var anyOtherIsPrimary = _dbContext.PerfumeImgs
                    .Where(p => p.PerfumeId == perfumeId && p.Id != perfume.PerfumeImage.Id)
                    .Any(p => p.IsPrimary);

                if (anyOtherIsPrimary)
                    throw new ConflictException("For the entered perfume exists an primary image");
            }

            _dbContext.SaveChanges();
        }

        public void DeleteAll(int perfumeId)
        {
            var perfume = _dbContext
                .Perfumes
                .Where(p => p.Id == perfumeId)
                .Select(p => new
                {
                    FullscreenImageUrl = p.PerfumeImgs
                        .Where(i => i.FullscreenImageUrl != null)
                        .Select(i => i.FullscreenImageUrl),
                    
                    ThumbnailImageUrls = p.PerfumeImgs
                        .Where(i => i.ThumbnailImageUrl != null)
                        .Select(i => i.ThumbnailImageUrl),

                    OriginalImageUrls = p.PerfumeImgs
                        .Where(i => i.OriginalImageUrl != null)
                        .Select(i => i.OriginalImageUrl)
                })
                .FirstOrDefault();

            if (perfume is null)
                throw new NotFoundException("Perfume not found");
            
            var tableName = nameof(_dbContext.PerfumeImgs);
            var columnName = nameof(PerfumeImg.PerfumeId);

            _dbContext.Database
                .ExecuteSqlRaw($"DELETE FROM {tableName} WHERE {columnName} = {perfumeId}");

            var imagesPaths = perfume.FullscreenImageUrl
                .Concat(perfume.ThumbnailImageUrls)
                .Concat(perfume.OriginalImageUrls)
                .ToArray();

            _perfumeImageStaticFilesSerice
                .DeleteImages(imagesPaths);
        }

        public void Delete(int perfumeId, int perfumeImageId)
        {
            var perfume = _dbContext.Perfumes
                .Where(p => p.Id == perfumeId)
                .Select(p => new
                {
                    PerfumeImage = p.PerfumeImgs.FirstOrDefault(pi => pi.Id == perfumeImageId)
                })
                .FirstOrDefault();

            if (perfume is null)
                throw new NotFoundException("Perfume not found");

            if (perfume.PerfumeImage is null)
                throw new NotFoundException("Perfume image not found");

            var imagesPaths = new string[]
            {
                perfume.PerfumeImage.FullscreenImageUrl,
                perfume.PerfumeImage.ThumbnailImageUrl,
                perfume.PerfumeImage.OriginalImageUrl
            };

            _dbContext.Remove(perfume.PerfumeImage);

            _dbContext.SaveChanges();

            _perfumeImageStaticFilesSerice
                .DeleteImages(imagesPaths);
        }

        public List<PerfumeImageDto> GetAll(int perfumeId)
        {
            var hostUrl = _hostService.GetHostUrl();

            var perfume = _dbContext.Perfumes
                .Where(p => p.Id == perfumeId)
                .Select(p => new
                {
                    PerfumeImages = p.PerfumeImgs.Select(pi => new PerfumeImageDto
                    {
                        FullscreenUrl = hostUrl + pi.FullscreenImageUrl,
                        ThumbnailUrl = hostUrl + pi.ThumbnailImageUrl,
                        IsPrimary = pi.IsPrimary
                    })
                })
                
                .FirstOrDefault();

            if (perfume is null)
                throw new NotFoundException("Perfume not found");

            var perfumeImageDtos = _mapper
                .Map<List<PerfumeImageDto>>(perfume.PerfumeImages);

            return perfumeImageDtos;
        }

        public PerfumeImageDto GetById(int perfumeId, int perfumeImageId)
        {
            var hostUrl = _hostService.GetHostUrl();

            var perfume = _dbContext.Perfumes
                .Where(p => p.Id == perfumeId)
                .Select(p => new
                {
                    PerfumeImage = p.PerfumeImgs
                        .Where(pi => pi.Id == perfumeImageId)
                        .Select(pi => new PerfumeImageDto
                        {
                            FullscreenUrl = hostUrl + pi.FullscreenImageUrl,
                            ThumbnailUrl = hostUrl + pi.ThumbnailImageUrl,
                            IsPrimary = pi.IsPrimary
                        })
                        .FirstOrDefault()
                })
                .FirstOrDefault();

            if (perfume is null)
                throw new NotFoundException("Perfume not found");

            if (perfume.PerfumeImage is null)
                throw new NotFoundException("Perfume image not found");

           
            return perfume.PerfumeImage;
        }
    }
}
