using ApplicationServices.DTOs;
using ApplicationServices.Enum;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
           

            CreateMap<NewTSAReportDto, TSAReport>()
                .ForMember(dest => dest.payColDate, opt => opt.MapFrom(src => src.Date));

            CreateMap<TSAReport, NewTSAReportDto>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.payColDate))
                .ReverseMap();

            CreateMap<EditTSAReportDto, TSAReport>().ReverseMap();
            //CreateMap<ApproveTSAByAuthorizerDto, TSAReport>().ReverseMap();
            CreateMap<ApproveBySupperAuthorizerDto, TSAReport>().ReverseMap();

            CreateMap<ApproveTSAByAuthorizerDto, TSAReport>()
            .ForMember(dest => dest.AuthorizedDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.IsAuthorized, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => ((int)StatusEnum.Authorizer_Aproved).ToString()))
            .ForMember(dest => dest.StatusDescription, opt => opt.MapFrom(src => EnumHelper.GetEnumDescription(StatusEnum.Authorizer_Aproved)))
            .ForMember(dest => dest.Authorizedby, opt => opt.MapFrom(src => src.Authorizedby))
            .ForMember(dest => dest.AuthorizerComment, opt => opt.MapFrom(src => src.AuthorizerComment));

            CreateMap<ApproveBySupperAuthorizerDto, TSAReport>()
            .ForMember(dest => dest.SuperAuthorizedDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.IsSuperAuthorized, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => ((int)StatusEnum.SuperAuthorizer_Approved).ToString()))
            .ForMember(dest => dest.StatusDescription, opt => opt.MapFrom(src => EnumHelper.GetEnumDescription(StatusEnum.SuperAuthorizer_Approved)))
            .ForMember(dest => dest.SuperAuthorizedby, opt => opt.MapFrom(src => src.SuperAuthorizedby))
            .ForMember(dest => dest.AuthorizerComment, opt => opt.MapFrom(src => src.SuperAuthorizerComment));


            CreateMap<RejectTSAByAuthorizerDto, TSAReport>()
           .ForMember(dest => dest.RejectionDate, opt => opt.MapFrom(src => DateTime.Now))
           .ForMember(dest => dest.IsRejected, opt => opt.MapFrom(src => true))
           .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => ((int)StatusEnum.Authorizer_Rejected).ToString()))
           .ForMember(dest => dest.StatusDescription, opt => opt.MapFrom(src => EnumHelper.GetEnumDescription(StatusEnum.Authorizer_Rejected)))
           .ForMember(dest => dest.Rejectedby, opt => opt.MapFrom(src => src.Rejectedby))
           .ForMember(dest => dest.AuthorizerComment, opt => opt.MapFrom(src => src.AuthorizerComment));

            CreateMap<RejectedBySupperAuthorizerDto, TSAReport>()
            .ForMember(dest => dest.SuperRejectionDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.IsSuperRejected, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => ((int)StatusEnum.SuperAuthorizer_Rejected).ToString()))
            .ForMember(dest => dest.StatusDescription, opt => opt.MapFrom(src => EnumHelper.GetEnumDescription(StatusEnum.SuperAuthorizer_Rejected)))
            .ForMember(dest => dest.SuperRejectedby, opt => opt.MapFrom(src => src.SuperRejectedby))
            .ForMember(dest => dest.SuperAuthorizerComment, opt => opt.MapFrom(src => src.SuperAuthorizerComment));

            CreateMap<TSAReport, GetTSADto>();

        }
    }
}
