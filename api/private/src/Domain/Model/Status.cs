using Domain.Referential;
using System;

namespace Domain.Model
{
    public class Status : IReferentialData, ICloneable
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }

        public string? FunctionalKey => Name;
        public Guid? TechnicalId { get => Id; set => Id = value; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
