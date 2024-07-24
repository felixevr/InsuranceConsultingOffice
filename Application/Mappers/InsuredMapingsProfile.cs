using AutoMapper;
using InsuranceConsultingOffice.Application.Dtos.Response;
using InsuranceConsultingOffice.Domain.Entities;

namespace InsuranceConsultingOffice.Application.Mappers
{
    public class InsuredMapingsProfile : Profile
    {
        public InsuredMapingsProfile()
        {
            CreateMap<Insured, InsuredResponseDto>().ReverseMap();
        }
    }
}
