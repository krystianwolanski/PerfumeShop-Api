using AutoMapper;
using Data;
using Data.Entities;
using FragranceShopApi.Exceptions;
using FragranceShopApi.Extensions;
using FragranceShopApi.Models;
using FragranceShopApi.Models.Perfume;
using FragranceShopApi.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using FragranceShopApi.Models.PerfumeImg;
using FragranceShopApi.Models.FragranceNote;

namespace FragranceShopApi.Services
{
    public interface IPerfumeService : IScopedService
    {
        int Create(CreatePerfumeDto dto);
        void Update(UpdatePerfumeDto dto, int id);
        void Delete(int id);
        PagedResult<PerfumeListDto> GetAll(PerfumeQueryFilter filter, PerfumeQueryPager pager);
        PerfumeDto GetById(int id);
        FiltersOptions GetFiltersOptions();
        List<OrderOption> GetOrderOptions();
    }

    public class PerfumeService : IPerfumeService
    {
        private readonly IMapper _mapper;
        private readonly PerfumeDbContext _dbContext;
        private readonly IPerfumeBrandService _perfumeBrandService;
        private readonly IFragranceNoteService _fragranceNoteService;
        private readonly IPerfumeGenderTypeService _perfumeGenderTypeService;
        private readonly IUserContextService _userContextService;
        private readonly IMemoryCache _memoryCache;
        private readonly IHostService _hostService;

        public PerfumeService(
            IMapper mapper,
            PerfumeDbContext dbContext,
            IPerfumeBrandService perfumeBrandService,
            IFragranceNoteService fragranceNoteService,
            IPerfumeGenderTypeService perfumeGenderTypeService,
            IUserContextService userContextService,
            IMemoryCache memoryCache,
            IHostService hostService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _perfumeBrandService = perfumeBrandService;
            _fragranceNoteService = fragranceNoteService;
            _perfumeGenderTypeService = perfumeGenderTypeService;
            _userContextService = userContextService;
            _memoryCache = memoryCache;
            _hostService = hostService;
        }

        public int Create(CreatePerfumeDto dto)
        {
            var perfume = _mapper.Map<Perfume>(dto);
            
            _dbContext.Add(perfume);
            _dbContext.SaveChanges();

            return perfume.Id;
        }

        public void Update(UpdatePerfumeDto dto, int id)
        {
            var perfume = _dbContext.Perfumes
                .Where(p => p.Id == id)
                .Include(p => p.FragranceNotesPerfumes)
                .FirstOrDefault();

            if (perfume is null)
                throw new NotFoundException("Perfume not found");

            _mapper.Map(dto, perfume);

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var perfume = GetPerfumeById(id);

            _dbContext.Remove(perfume);
            _dbContext.SaveChanges();
        }

        public PagedResult<PerfumeListDto> GetAll(PerfumeQueryFilter filter, PerfumeQueryPager pager)
        {
            var baseQuery = _dbContext.Perfumes.AsQueryable();

            #region Filters
            if (!string.IsNullOrEmpty(filter.Name))
            {
                baseQuery = baseQuery.Where(p => p.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            if (filter.MinimumPrice.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.CurrentPrice >= filter.MinimumPrice);
            }

            if (filter.MaximumPrice.HasValue)
            {
                baseQuery = baseQuery.Where(p => p.CurrentPrice <= filter.MaximumPrice);
            }

            if (!filter.PerfumeBrandsNames.IsNullOrEmpty())
            {
                baseQuery = baseQuery.Where(p => filter.PerfumeBrandsNames.Contains(p.PerfumeBrand.Name));
            }

            if (!filter.FragranceNotesNames.IsNullOrEmpty())
            {
                baseQuery = baseQuery
                    .Where(p => p.FragranceNotesPerfumes
                    .Any(n => filter.FragranceNotesNames.Contains(n.FragranceNote.Name)));
            }

            if (!filter.PerfumeGenderTypeIds.IsNullOrEmpty())
            {
                baseQuery = baseQuery.Where(p => filter.PerfumeGenderTypeIds.Contains(p.PerfumeGenderTypeId));
            }

            if (!filter.Capacities.IsNullOrEmpty())
            {
                baseQuery = baseQuery.Where(p => filter.Capacities.Contains(p.Capacity));
            }
            #endregion

            var hostUrl = _hostService.GetHostUrl();

            var perfumes = _dbContext.Perfumes
                .Select(p => new PerfumeListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Year = p.Year,
                    CurrentPrice = p.CurrentPrice,
                    BasePrice = p.BasePrice,
                    Quantity = p.Quantity,
                    Perfumer = new Models.Perfumer.PerfumerDto()
                    {
                        Id = p.PerfumerId,
                        Name = p.Perfumer.Name
                    },
                    Brand = new Models.PerfumeBrand.PerfumeBrandDto()
                    {
                        Id = p.PerfumeBrandId,
                        Name = p.PerfumeBrand.Name
                    },
                    Capacity = p.Capacity,
                    GenderTypeId = p.PerfumeGenderTypeId,
                    Images = p.PerfumeImgs.Select(x => new PerfumeImageDto()
                    {
                        ThumbnailUrl = hostUrl + x.ThumbnailImageUrl,
                        IsPrimary = x.IsPrimary
                    }),
                })
                .Paginate(pager)
                .ToList();

            var totalCount = baseQuery.Count();

            var result = new PagedResult<PerfumeListDto>(perfumes, totalCount, pager.PageSize, pager.PageNumber);

            return result;
        }

        public PerfumeDto GetById(int id)
        {
            var hostUrl = _hostService.GetHostUrl();

            var perfume = _dbContext.Perfumes
                .Select(p => new PerfumeDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Year = p.Year,
                    CurrentPrice = p.CurrentPrice,
                    BasePrice = p.BasePrice,
                    Quantity = p.Quantity,
                    PerfumerName = p.Perfumer.Name,
                    PerfumeBrandName = p.PerfumeBrand.Name,
                    Capacity = p.Capacity,
                    PerfumeGenderTypeId = p.PerfumeGenderTypeId,
                    Images = p.PerfumeImgs.Select(x => new PerfumeImageDto()
                    {
                        ThumbnailUrl = hostUrl + x.ThumbnailImageUrl,
                        FullscreenUrl = hostUrl + x.FullscreenImageUrl,
                        IsPrimary = x.IsPrimary
                    }),
                    FragranceNotePerfumeDtos = p.FragranceNotesPerfumes.Select(x => new FragranceNotePerfumeDto()
                    {
                        Name = x.FragranceNote.Name,
                        FragranceNoteTypeId = x.FragranceNoteTypeId,
                        Image = x.FragranceNote.Image
                    })
                })
                .FirstOrDefault(p => p.Id == id);
                
            if (perfume is null)
                throw new NotFoundException("Perfume not found");
            
            var perfumeDto = _mapper.Map<PerfumeDto>(perfume);

            return perfumeDto;
        }


        public FiltersOptions GetFiltersOptions()
        {
            if (!_memoryCache.TryGetValue(CacheKeys.PerfumeFiltersOptions, out FiltersOptions options))
            {
                options = new FiltersOptions()
                {
                    Brands = _perfumeBrandService.GetAll(),
                    FragranceNotes = _fragranceNoteService.GetAll(),
                    Capacities = new int[] { 50, 100, 150, 200 },
                    PerfumeGenderTypes = _perfumeGenderTypeService.GetAll()
                };

                _memoryCache.Set(CacheKeys.PerfumeFiltersOptions, options, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(4)
                });
            }

            return options;
        }

        public List<OrderOption> GetOrderOptions()
        {
            var options = new List<OrderOption>()
            {
                new OrderOption()
                {
                    SortBy = nameof(Perfume.CurrentPrice),
                    SortDirection = SortDirection.ASC,
                    Display = "Cena najniższa"
                },
                new OrderOption()
                {
                    SortBy = nameof(Perfume.CurrentPrice),
                    SortDirection = SortDirection.DESC,
                    Display = "Cana najwyższa"
                }
            };

            return options;
        }

        private Perfume GetPerfumeById(int id)
        {
            var perfume = _dbContext
                .Perfumes
                .FirstOrDefault(p => p.Id == id);

            if (perfume is null)
                throw new NotFoundException("Perfume not found");

            return perfume;
        }
    }
}
