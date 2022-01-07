using AutoMapper;
using FragranceShopApi.Exceptions;
using FragranceShopApi.Models.User;
using FragranceShopApi.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Services
{
    public interface IUserService : IScopedService
    {
        void Update(int id, UpdateUserDto dto);
    }

    public class UserService : IUserService
    {
        private readonly PerfumeDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(
            PerfumeDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Update(int id, UpdateUserDto dto)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user is null)
                throw new NotFoundException("User not found");

            _mapper.Map(dto, user);

            _dbContext.SaveChanges();
        }
    }
}
