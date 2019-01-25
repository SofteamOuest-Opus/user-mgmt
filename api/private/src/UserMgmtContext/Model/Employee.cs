using System;
using System.ComponentModel.DataAnnotations;

namespace UserMgmtContext.Model
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
    }
}