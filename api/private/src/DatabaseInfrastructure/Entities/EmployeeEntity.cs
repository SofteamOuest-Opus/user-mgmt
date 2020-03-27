using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseInfrastructure.Entities
{
    public class EmployeeEntity
    {
        public Guid Id { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? PhotoUri { get; set; }

        public Guid? OfficeId { get; set; }
        public OfficeEntity? Office { get; set; }

        public Guid? ManagerId { get; set; }
        public EmployeeEntity? Manager { get; set; }

        public Guid? HumanResourceManagerId { get; set; }
        public EmployeeEntity? HumanResourceManager { get; set; }

        public Guid? StatusId { get; set; }
        public StatusEntity? Status { get; set; }

        public Guid? OccupationId { get; set; }
        public OccupationEntity? Occupation { get; set; }
    }
}
