using AutoMapper;
using Data.Entities;
using FragranceShopApi.Models;
using FragranceShopApi.Models.Account;
using FragranceShopApi.Models.FragranceNote;
using FragranceShopApi.Models.Order;
using FragranceShopApi.Models.OrderElement;
using FragranceShopApi.Models.Perfume;
using FragranceShopApi.Models.PerfumeBrand;
using FragranceShopApi.Models.PerfumeImage;
using FragranceShopApi.Models.Perfumer;
using FragranceShopApi.Models.PerfumeReview;

namespace FragranceShopApi.Mapper
{
    public class PerfumesShopMappingProfile:Profile
    {
        public PerfumesShopMappingProfile()
        {
            #region Account
            CreateMap<RegisterUserDto, User>()
                .ForMember(u => u.PasswordHash, o => o.Ignore());
           #endregion

            #region Perfumer
            CreateMap<CreatePerfumerDto, Perfumer>();
            CreateMap<UpdatePerfumerDto, Perfumer>();
            #endregion

            #region Perfume
            CreateMap<CreatePerfumeDto, Perfume>()
                .ForMember(p => p.FragranceNotesPerfumes, o => o.MapFrom(x => x.FragranceNotePerfumConnection));

            CreateMap<UpdatePerfumeDto, Perfume>()
                .ForMember(p => p.FragranceNotesPerfumes, o => o.MapFrom(x => x.FragranceNotePerfumConnection));
            #endregion

            #region PerfumeImage
            CreateMap<UpdatePerfumeImageDto, PerfumeImg>();
            #endregion

            #region FragranceNote
            CreateMap<CreateFragranceNoteDto, FragranceNote>()
                .ForMember(f => f.Image, o => o.Ignore());
            CreateMap<UpdateFragranceNoteDto, FragranceNote>()
                .ForMember(f => f.Image, o => o.Ignore());
            #endregion

            #region FragranceNotePerfume
            CreateMap<CreateFragranceNotePerfumConnection, FragranceNotePerfume>();
            CreateMap<UpdateFragranceNotePerfumConnection, FragranceNotePerfume>();
            #endregion

            #region PerfumeBrand
            CreateMap<CreatePerfumeBrandDto, PerfumeBrand>();
            CreateMap<UpdatePerfumeBrandDto, PerfumeBrand>();
            #endregion

            #region PerfumeReview
            CreateMap<CreatePerfumeReviewDto, PerfumeReview>();
            CreateMap<UpdatePerfumeReviewDto, PerfumeReview>();
            #endregion

            #region Order
            CreateMap<CreateOrderDto, Order>()
                .ForMember(o => o.OrderElements, o => o.MapFrom(co => co.CreateOrderElementDtos));
            CreateMap<UpdateOrderDto, Order>();
            CreateMap<MakeOrderDto, Order>()
                .ForMember(o => o.OrderElements, o => o.MapFrom(mo => mo.CreateOrderElementDtos));
            #endregion

            #region OrderElement
            CreateMap<CreateOrderElementDto, OrderElement>();
            CreateMap<UpdateOrderElementDto, OrderElement>();
            #endregion
        }
    }
}
