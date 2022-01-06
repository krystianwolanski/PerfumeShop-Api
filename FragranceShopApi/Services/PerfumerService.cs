using AutoMapper;
using Data;
using Data.Entities;
using FragranceShopApi.Exceptions;
using FragranceShopApi.Models;
using FragranceShopApi.Models.Perfumer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FragranceShopApi.Extensions;
using FragranceShopApi.Services.Common;

namespace FragranceShopApi.Services
{
    public interface IPerfumerService : IScopedService
    {
        PagedResult<PerfumerDto> GetAll(PerfumerQueryFilter filter, PerfumerQueryPager pager);
        PerfumerDto GetById(int id);
        int Create(CreatePerfumerDto dto);
        void Delete(int id);
        void Update(UpdatePerfumerDto dto, int id);
    }

    public class PerfumerService : IPerfumerService
    {
        private readonly PerfumeDbContext _dbContext;
        private readonly IMapper _mapper;

        public PerfumerService(
            PerfumeDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(CreatePerfumerDto dto)
        {
            var perfumer = _mapper.Map<Perfumer>(dto);

            _dbContext.Add(perfumer);
            _dbContext.SaveChanges();

            return perfumer.Id;
        }

        public void Delete(int id)
        {
            var perfumer = GetPerfumerById(id);

            _dbContext.Remove(perfumer);
            _dbContext.SaveChanges();
        }

        public void Update(UpdatePerfumerDto dto, int id)
        {
            var perfumer = GetPerfumerById(id);

            _mapper.Map(dto, perfumer);
            _dbContext.SaveChanges();
        }

        public PagedResult<PerfumerDto> GetAll(PerfumerQueryFilter filter, PerfumerQueryPager pager)
        {
            var baseQuery = _dbContext
                .Perfumers
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.SearchPhrase))
            {
                baseQuery = baseQuery
                    .Where(r => r.Name.ToLower()
                    .Contains(filter.SearchPhrase.ToLower()));
            }

            var perfumers = baseQuery
                .Select(p => new PerfumerDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .Paginate(pager)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            var result = new PagedResult<PerfumerDto>(perfumers, totalItemsCount, pager.PageSize, pager.PageNumber);

            return result;
        }

        public PerfumerDto GetById(int id)
        {
            var perfumer = _dbContext.Perfumers
                .Where(p => p.Id == id)
                .Select(p => new PerfumerDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .FirstOrDefault();

            if (perfumer is null)
                throw new NotFoundException("Perfumer not found");

            return perfumer;
        }

        private Perfumer GetPerfumerById(int id)
        {
            var perfumer = _dbContext
                .Perfumers
                .FirstOrDefault(p => p.Id == id);

            if (perfumer is null)
                throw new NotFoundException("Perfumer not found");

            return perfumer;
        }
    }
}
