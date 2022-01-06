using AutoMapper;
using Data;
using FragranceShopApi.Models.PerfumeGenderType;
using FragranceShopApi.Services.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FragranceShopApi.Services
{
    public interface IPerfumeGenderTypeService : IScopedService
    {
        List<PerfumeGenderTypeDto> GetAll();
    }
    public class PerfumeGenderTypeService : IPerfumeGenderTypeService
    {
        private readonly IMapper _mapper;
        private readonly PerfumeDbContext _dbContext;

        public PerfumeGenderTypeService(
            IMapper mapper,
            PerfumeDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public List<PerfumeGenderTypeDto> GetAll()
        {
            var genders = _dbContext
                .PerfumeGenderTypes
                .Select(g => new PerfumeGenderTypeDto
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToList();

            return genders;
        }
    }
}
