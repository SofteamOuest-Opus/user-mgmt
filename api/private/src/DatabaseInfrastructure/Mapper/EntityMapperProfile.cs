using AutoMapper;
using DatabaseInfrastructure.Entities;
using Domain.Model;
using Domain.Referential;
using System;

namespace DatabaseInfrastructure.Mapper
{
    public class EntityMapperProfile : Profile
    {
        public EntityMapperProfile()
        {
            CreateMap<EmployeeEntity, Employee>();
            CreateMap<EmployeeEntity, Manager>()
                .ForMember(dest => dest.TechnicalId, opt => opt.Ignore());
            CreateMap<OccupationEntity, Occupation>()
                .ForMember(dest => dest.TechnicalId, opt => opt.Ignore());
            CreateMap<OfficeEntity, Office>()
                .ForMember(dest => dest.TechnicalId, opt => opt.Ignore());
            CreateMap<StatusEntity, Status>()
                .ForMember(dest => dest.TechnicalId, opt => opt.Ignore());

            CreateMap<Employee, EmployeeEntity>()
                .ForMember(dest => dest.Office, opt => opt.Ignore())
                .ForMember(dest => dest.OfficeId, opt => opt.MapFrom(src => GetTechnicalId(src.Office)))
                .ForMember(dest => dest.Manager, opt => opt.Ignore())
                .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => GetTechnicalId(src.Manager)))
                .ForMember(dest => dest.HumanResourceManager, opt => opt.Ignore())
                .ForMember(dest => dest.HumanResourceManagerId, opt => opt.MapFrom(src => GetTechnicalId(src.HumanResourceManager)))
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => GetTechnicalId(src.Status)))
                .ForMember(dest => dest.Occupation, opt => opt.Ignore())
                .ForMember(dest => dest.OccupationId, opt => opt.MapFrom(src => GetTechnicalId(src.Occupation)));

            CreateMap<Occupation, OccupationEntity>();
            CreateMap<Office, OfficeEntity>();
            CreateMap<Status, StatusEntity>();
        }

        private Guid? GetTechnicalId(ITechnicalId? source)
        {
            if (source == null)
            {
                return null;
            }
            else if (source.TechnicalId == default(Guid))
            {
                return null;
            }
            else
            {
                return source.TechnicalId;
            }
        }
    }
}
