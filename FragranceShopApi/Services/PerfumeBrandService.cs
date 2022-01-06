using AutoMapper;
using Data;
using Data.Entities;
using FragranceShopApi.Exceptions;
using FragranceShopApi.Extensions;
using FragranceShopApi.Models;
using FragranceShopApi.Models.PerfumeBrand;
using FragranceShopApi.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FragranceShopApi.Services
{
    public interface IPerfumeBrandService : IScopedService
    {
        int Create(CreatePerfumeBrandDto dto);
        void Update(UpdatePerfumeBrandDto dto, int id);
        void Delete(int id);
        PagedResult<PerfumeBrandDto> GetAll(PerfumeBrandQueryFilter filter, PerfumeBrandQueryPager pager);
        List<PerfumeBrandDto> GetAll();
        PerfumeBrandDto GetById(int id);
    }

    public class PerfumeBrandService : IPerfumeBrandService
    {
        private readonly IMapper _mapper;
        private readonly PerfumeDbContext _dbContext;

        public PerfumeBrandService(
            IMapper mapper,
            PerfumeDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public int Create(CreatePerfumeBrandDto dto)
        {
            var newPerfumeBrand = _mapper.Map<PerfumeBrand>(dto);

            _dbContext.Add(newPerfumeBrand);
            _dbContext.SaveChanges();

            return newPerfumeBrand.Id;
        }

        public void Update(UpdatePerfumeBrandDto dto, int id)
        {
            var perfumeBrand = GetPerfumeBrandById(id);

            _mapper.Map(dto, perfumeBrand);

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var perfumeBrand = GetPerfumeBrandById(id);

            _dbContext.Remove(perfumeBrand);
            _dbContext.SaveChanges();
        }

        public PagedResult<PerfumeBrandDto> GetAll(PerfumeBrandQueryFilter filter, PerfumeBrandQueryPager pager)
        {
            var baseQuery = _dbContext
                .PerfumeBrands
                .AsQueryable();

            #region Filters
            if (!string.IsNullOrEmpty(filter.Name))
            {
                baseQuery = baseQuery.Where(b => b.Name.ToLower().Contains(filter.Name.ToLower()));
            }
            #endregion

            var perfumeBrands = baseQuery.Select(b => new PerfumeBrandDto
            { 
                Id = b.Id,
                Name = b.Name
            })
            .Paginate(pager)
            .ToList();

            var totalCount = baseQuery.Count();

            var result = new PagedResult<PerfumeBrandDto>(perfumeBrands, totalCount, pager.PageSize, pager.PageNumber);

            return result;
        }

        public List<PerfumeBrandDto> GetAll()
        {
            var perfumeBrands = _dbContext
                .PerfumeBrands
                .Select(b => new PerfumeBrandDto
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToList();

            return perfumeBrands;
        }

        public PerfumeBrandDto GetById(int id)
        {
            var perfumeBrand = _dbContext.PerfumeBrands
                .Where(b => b.Id == id)
                .Select(b => new PerfumeBrandDto
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .FirstOrDefault();

            if (perfumeBrand is null)
                throw new NotFoundException("Perfume brand not found");

            return perfumeBrand;
        }

        private PerfumeBrand GetPerfumeBrandById(int id)
        {
            var perfumeBrand = _dbContext
                .PerfumeBrands
                .FirstOrDefault(perfumeBrand => perfumeBrand.Id == id);

            if (perfumeBrand is null)
                throw new NotFoundException("Perfume brand not found");

            return perfumeBrand;
        }
    }
}
