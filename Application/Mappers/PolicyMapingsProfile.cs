using AutoMapper;
using InsuranceConsultingOffice.Application.Dtos.Request;
using InsuranceConsultingOffice.Application.Dtos.Response;
using InsuranceConsultingOffice.Domain.Entities;

namespace InsuranceConsultingOffice.Application.Mappers
{
    public class PolicyMapingsProfile : Profile
    {
        public PolicyMapingsProfile() 
        {
            CreateMap<Policy, PolicyResponseDto>().ReverseMap();
            CreateMap<Policy, PolicyRequestDto>().ReverseMap();
        }
    }
}
