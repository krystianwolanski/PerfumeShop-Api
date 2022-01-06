using AutoMapper;
using FragranceShopApi.Authorization.PerfumeReviewAuthorization;
using Data;
using Data.Entities;
using FragranceShopApi.Exceptions;
using FragranceShopApi.Extensions;
using FragranceShopApi.Models;
using FragranceShopApi.Models.PerfumeReview;
using FragranceShopApi.Models.Account;
using FragranceShopApi.Services.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;

namespace FragranceShopApi.Services
{
    public interface IPerfumeReviewService : IScopedService
    {
        public int Create(int perfumeId, CreatePerfumeReviewDto dto);
        public void Update(int perfumeId, int perfumeReviewId, UpdatePerfumeReviewDto dto);
        public void DeleteAll(int perfumeId);
        public void Delete(int perfumeId, int perfumeReviewId);
        public PagedResult<PerfumeReviewDto> GetAll(int perfumeId, PerfumeReviewQueryFilter filter, PerfumeReviewQueryPager pager);
        public PerfumeReviewDto GetById(int perfumeId, int perfumeReviewId);
        public int Add(int perfumeId, AddPerfumeReviewDto dto);

    }
    public class PerfumeReviewService : IPerfumeReviewService
    {
        private readonly PerfumeDbContext _dbContext;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public PerfumeReviewService(
            PerfumeDbContext dbContext,
            IUserContextService userContextService,
            IMapper mapper,
            IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _userContextService = userContextService;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        public int Create(int perfumeId, CreatePerfumeReviewDto dto)
        {
            var existsPerfume = _dbContext
                .Perfumes
                .Where(p => p.Id == perfumeId)
                .Any();

            if (!existsPerfume)
                throw new NotFoundException("Perfume not found");

            var perfumeReview = _mapper.Map<PerfumeReview>(dto);
            perfumeReview.PerfumeId = perfumeId;

            _dbContext.Add(perfumeReview);
            _dbContext.SaveChanges();

            return perfumeReview.Id;
        }

        public void Update(int perfumeId, int perfumeReviewId, UpdatePerfumeReviewDto dto)
        {
            var perfume = _dbContext
                .Perfumes
                .Select(p => new
                {
                    PerfumeReview = p.PerfumeReviews.FirstOrDefault(r => r.Id == perfumeReviewId)
                })
                .FirstOrDefault();

            if (perfume is null)
                throw new NotFoundException("Perfume not found");

            if (perfume.PerfumeReview is null)
                throw new NotFoundException("Perfume review not found");

            _mapper.Map(dto, perfume.PerfumeReview);

            _dbContext.SaveChanges();
        }

        public void DeleteAll(int perfumeId)
        {
            var existsPerfume = _dbContext
               .Perfumes
               .Where(p => p.Id == perfumeId)
               .Any();

            if (!existsPerfume)
                throw new NotFoundException("Perfume not found");

            var tableName = nameof(_dbContext.PerfumeReviews);
            var columnName = nameof(PerfumeReview.PerfumeId);

            _dbContext.Database
                .ExecuteSqlRaw($"DELETE FROM {tableName} WHERE {columnName} = {perfumeId}");
        }

        public void Delete(int perfumeId, int perfumeReviewId)
        {
            var perfume = _dbContext
                .Perfumes
                .Where(p => p.Id == perfumeId)
                .Select(p => new
                {
                    PerfumeReview = p.PerfumeReviews.FirstOrDefault(r => r.Id == perfumeReviewId)
                })
                .FirstOrDefault();

            if (perfume is null)
                throw new NotFoundException("Perfume not found");

            if (perfume.PerfumeReview is null)
                throw new NotFoundException("Perfume review not found");

            _dbContext.Remove(perfume.PerfumeReview);
            _dbContext.SaveChanges();
        }

        public PagedResult<PerfumeReviewDto> GetAll(int perfumeId, PerfumeReviewQueryFilter filter, PerfumeReviewQueryPager pager)
        {
            var baseQuery = _dbContext
                .PerfumeReviews
                .Where(r => r.PerfumeId == perfumeId);

            #region Filters
            if (filter.AuthorId.HasValue)
            {
                baseQuery = baseQuery.Where(r => r.AuthorId == filter.AuthorId);
            }

            if (filter.RatingFrom.HasValue)
            {
                baseQuery = baseQuery.Where(r => r.Rating >= filter.RatingFrom);
            }

            if (filter.RatingTo.HasValue)
            {
                baseQuery = baseQuery.Where(r => r.Rating <= filter.RatingTo);
            }

            if (!string.IsNullOrEmpty(filter.Review))
            {
                baseQuery = baseQuery
                    .Where(r => r.Review.ToLower()
                        .Contains(filter.Review.ToLower()));
            }
            #endregion

            var perfumeReviews = baseQuery
                .Paginate(pager)
                .Select(r => new PerfumeReviewDto
                {
                    Id = r.Id,
                    Review = r.Review,
                    Rating = r.Rating,
                    AuthorDto = new UserDto
                    {
                        Id = r.AuthorId,
                        FirstName = r.Author.FirstName,
                        LastName = r.Author.LastName
                    }
                })
                .ToList();

            var totalCount = baseQuery.Count();

            var result = new PagedResult<PerfumeReviewDto>(perfumeReviews, totalCount, pager.PageSize, pager.PageNumber);

            return result;
        }

        public PerfumeReviewDto GetById(int perfumeId, int perfumeReviewId)
        {
            var perfume = _dbContext
                .Perfumes
                .Where(p => p.Id == perfumeId)
                .Select(p => new
                {
                    PerfumeReview = p.PerfumeReviews
                        .Where(r => r.Id == perfumeReviewId)
                        .Select(r => new PerfumeReviewDto
                        {
                            Id = r.Id,
                            AuthorDto = new UserDto
                            {
                                Id = r.AuthorId,
                                FirstName = r.Author.FirstName,
                                LastName = r.Author.LastName
                            },
                            Review = r.Review,
                            Rating = r.Rating
                        })
                        .FirstOrDefault()
                })
                .FirstOrDefault();

            if (perfume is null)
                throw new NotFoundException("Perfume not found");

            if (perfume.PerfumeReview is null)
                throw new NotFoundException("Perfume review not found");

            return perfume.PerfumeReview;
        }

        public int Add(int perfumeId, AddPerfumeReviewDto dto)
        {
            var perfumeReviewAuthModel = _dbContext.Perfumes
                .Where(p => p.Id == perfumeId)
                .Select(p => new PerfumeReviewAuthModel
                {
                    UserHasGetSpecificPerfume = p.OrderElements.Where(d => d.Order.CustomerId == _userContextService.User.GetUserId()
                        && d.Order.OrderStatusId == OrderStatusId.Shipped).Any()
                })
                .FirstOrDefault();

            if (perfumeReviewAuthModel is null)
                throw new NotFoundException("Perfume not found");

            var user = _userContextService.User;

            var userCanAddReview = _authorizationService
                .AuthorizeAsync(user, perfumeReviewAuthModel, 
                    new PerfumeReviewOperationRequirement(PerfumeReviewOperation.Add)).Result;

            if (!userCanAddReview.Succeeded)
                throw new ForbidException();

            var newPerfumeReview = _mapper.Map<PerfumeReview>(dto);
            
            var userId = _userContextService.User.GetUserId();
            
            newPerfumeReview.AuthorId = userId;

            _dbContext.Add(newPerfumeReview);
            _dbContext.SaveChanges();

            return newPerfumeReview.Id;
        }
    }
}
