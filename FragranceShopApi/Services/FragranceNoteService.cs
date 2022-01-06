using AutoMapper;
using Data;
using Data.Entities;
using FragranceShopApi.Exceptions;
using FragranceShopApi.Extensions;
using FragranceShopApi.Models;
using FragranceShopApi.Models.FragranceNote;
using FragranceShopApi.Services.Common;
using FragranceShopApi.Services.ImageProcess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FragranceShopApi.Services
{
    public interface IFragranceNoteService : IScopedService
    {
        Task<int> Create(CreateFragranceNoteDto dto);
        Task Update(UpdateFragranceNoteDto dto, int id);
        void Delete(int id);
        PagedResult<FragranceNoteDto> GetAll(FragranceNoteQueryFilter filter, FragranceNoteQueryPager pager);
        List<FragranceNoteDto> GetAll();
        FragranceNoteDto GetById(int id);
    }

    public class FragranceNoteService : IFragranceNoteService
    {
        private readonly IMapper _mapper;
        private readonly PerfumeDbContext _dbContext;
        private readonly IUserContextService _userContextService;
        private readonly IFragranceNoteImageProcessService _fragranceNoteImageProcessService;

        public FragranceNoteService(
            IMapper mapper,
            PerfumeDbContext dbContext,
            IUserContextService userContextService,
            IFragranceNoteImageProcessService fragranceNoteImageProcess)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _userContextService = userContextService;
            _fragranceNoteImageProcessService = fragranceNoteImageProcess;
        }

        public async Task<int> Create(CreateFragranceNoteDto dto)
        {
            var fragranceNote = _mapper.Map<FragranceNote>(dto);
            fragranceNote.Image = await _fragranceNoteImageProcessService.Process(dto.Image);

            _dbContext.Add(fragranceNote);
            _dbContext.SaveChanges();

            return fragranceNote.Id;
        }

        public async Task Update(UpdateFragranceNoteDto dto, int id)
        {
            var fragranceNote = GetFragranceNoteById(id);

            _mapper.Map(dto, fragranceNote);
            fragranceNote.Image = await _fragranceNoteImageProcessService.Process(dto.Image);

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var fragranceNote = GetFragranceNoteById(id);

            _dbContext.Remove(fragranceNote);
            _dbContext.SaveChanges();
        }

        public PagedResult<FragranceNoteDto> GetAll(FragranceNoteQueryFilter filter, FragranceNoteQueryPager pager)
        {
            var baseQuery = _dbContext
                .FragranceNotes
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                baseQuery = baseQuery.Where(n => n.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            var fragranceNotes = _dbContext.FragranceNotes.Select(f => new FragranceNoteDto
            {
                Name = f.Name,
                Image = f.Image
            })
            .Paginate(pager)
            .ToList();

            var totalCount = baseQuery.Count();

            var result = new PagedResult<FragranceNoteDto>(fragranceNotes, totalCount, pager.PageSize, pager.PageNumber);

            return result;
        }

        public List<FragranceNoteDto> GetAll()
        {
            var fragranceNotes = _dbContext.FragranceNotes.Select(f => new FragranceNoteDto
            {
                Name = f.Name,
                Image = f.Image
            })
            .ToList();

            return fragranceNotes;
        }

        public FragranceNoteDto GetById(int id)
        {
            var fragranceNote = _dbContext.FragranceNotes.Where(f => f.Id == id)
                .Select(f => new FragranceNoteDto
                {
                    Name = f.Name,
                    Image = f.Image
                })
                .FirstOrDefault();

            if (fragranceNote is null)
                throw new NotFoundException("Fragrance note not found");

            return fragranceNote;
        }

        private FragranceNote GetFragranceNoteById(int id)
        {
            var fragranceNote = _dbContext
                .FragranceNotes
                .FirstOrDefault(f => f.Id == id);

            if (fragranceNote is null)
                throw new NotFoundException("Fragrance note not found");

            return fragranceNote;
        }
    }
}
