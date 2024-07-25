using AutoMapper;
using InsuranceConsultingOffice.Application.Dtos.Response;
using InsuranceConsultingOffice.Domain.Entities;

namespace InsuranceConsultingOffice.Application.Mappers
{
    public class AssignamentMapingsProfile : Profile
    {
        public AssignamentMapingsProfile()
        {
            CreateMap<Assignament, InsuredAssignamentResponseDto>().ReverseMap();
            CreateMap<Assignament, PolicyAssignamentResponseDto>().ReverseMap();
        }
    }
}
