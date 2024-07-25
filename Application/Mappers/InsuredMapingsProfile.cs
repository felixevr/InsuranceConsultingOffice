using AutoMapper;
using InsuranceConsultingOffice.Application.Dtos.Request;
using InsuranceConsultingOffice.Application.Dtos.Response;
using InsuranceConsultingOffice.Domain.Entities;

namespace InsuranceConsultingOffice.Application.Mappers
{
    public class InsuredMapingsProfile : Profile
    {
        public InsuredMapingsProfile()
        {
            CreateMap<Insured, InsuredResponseDto>()
                .ForMember(dest => dest.PolicyAssignments, opt => opt.MapFrom(src => src.Assignaments))
                .ReverseMap();

            CreateMap<Insured, InsuredResponseOnlyDto>().ReverseMap();

            CreateMap<Insured, InsuredRequestDto>().ReverseMap();
        }
    }
}
