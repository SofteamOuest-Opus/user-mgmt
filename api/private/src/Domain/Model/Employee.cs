using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Employee
    {
        public Guid Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhotoUri { get; set; }
        public Office Office { get; set; }
        public Manager Manager { get; set; }
        public Manager HumanResourceManager { get; set; }
        public Status Status { get; set; }
        public Occupation Occupation { get; set; }
        public IEnumerable<string> AccessRights { get; set; }
    }
}