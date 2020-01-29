using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Referential
{
    /// <summary>
    /// Default values for referential data.
    /// Can be used to populate the data on app initialization, 
    /// but not intended for later reference, as data may have changed
    /// </summary>
    public class ReferentialDefaults
    {
        private readonly Identification identification;

        public IEnumerable<Occupation> Occupations => SetTechnicalIds(OccupationsWithoutId);

        public IEnumerable<Office> Offices => SetTechnicalIds(OfficesWithoutId);

        public IEnumerable<Status> Statuses => SetTechnicalIds(StatusesWithoutId);

        private static IEnumerable<Occupation> OccupationsWithoutId
        {
            get
            {
                yield return new Occupation { Name = "Employee" };
                yield return new Occupation { Name = "Manager" };
                yield return new Occupation { Name = "Human resource manager" };
                yield return new Occupation { Name = "Top management" };
            }
        }

        private static IEnumerable<Office> OfficesWithoutId
        {
            get
            {
                yield return new Office { Name = "Nantes" };
                yield return new Office { Name = "Rennes" };
            }
        }

        private static IEnumerable<Status> StatusesWithoutId
        {
            get
            {
                yield return new Status { Name = "Internship" };
                yield return new Status { Name = "Subcontractor" };
                yield return new Status { Name = "Freelancer" };
            }
        }

        public ReferentialDefaults(Identification identification)
        {
            this.identification = identification;
        }

        private IEnumerable<T> SetTechnicalIds<T>(IEnumerable<T> referentialData) where T : IReferentialData
            => referentialData.Select(SetTechnicalId);

        public T SetTechnicalId<T>(T dataWithFunctionalKey) where T : IReferentialData
        {
            var functionalKey = dataWithFunctionalKey.FunctionalKey;

            if (functionalKey == default)
            {
                throw new ArgumentOutOfRangeException(nameof(dataWithFunctionalKey), "Functional key is not set");
            }

            var technicalId = identification.NewTechnicalId(functionalKey);
            dataWithFunctionalKey.TechnicalId = technicalId;

            return dataWithFunctionalKey;
        }
    }
}
