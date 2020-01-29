using AutoMapper;
using DatabaseInfrastructure.Entities;
using Domain.Model;

namespace DatabaseInfrastructure.Mapper
{
    public class EntityMapperProfile : Profile
    {
        public EntityMapperProfile()
        {
            CreateMap<OccupationEntity, Occupation>()
                .ForMember(dest => dest.TechnicalId, opt => opt.Ignore());
            CreateMap<OfficeEntity, Office>()
                .ForMember(dest => dest.TechnicalId, opt => opt.Ignore());
            CreateMap<StatusEntity, Status>()
                .ForMember(dest => dest.TechnicalId, opt => opt.Ignore());
        }
    }
}
