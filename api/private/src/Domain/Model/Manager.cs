using Domain.Referential;
using System;

namespace Domain.Model
{
    public class Manager : ITechnicalId
    {
        public Guid? Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }

        public Guid? TechnicalId { get => Id; set => Id = value; }
    }
}
