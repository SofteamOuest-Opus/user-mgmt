using AutoMapper;
using DatabaseInfrastructure.Entities;
using Domain.Model;
using Domain.Referential;
using System.Collections.Generic;

namespace DatabaseInfrastructure.Seeding
{
    /// <summary>
    /// Default values for referential data.
    /// Used to populate the database on app initialization, 
    /// but not intended for later reference, as database contents may have changed
    /// </summary>
    public class ReferentialEntities
    {
        private readonly ReferentialDefaults referential;
        private readonly IMapper mapper;

        public IEnumerable<OccupationEntity> Occupations
        {
            get => Convert<Occupation, OccupationEntity>(referential.Occupations);
        }

        public IEnumerable<OfficeEntity> Offices
        {
            get => Convert<Office, OfficeEntity>(referential.Offices);
        }

        public IEnumerable<StatusEntity> Statuses
        {
            get => Convert<Status, StatusEntity>(referential.Statuses);
        }

        public ReferentialEntities(ReferentialDefaults referential, IMapper mapper)
        {
            this.referential = referential;
            this.mapper = mapper;
        }

        private IEnumerable<TDestination> Convert<TSource, TDestination>(IEnumerable<TSource> values)
            => mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(values);
    }
}
