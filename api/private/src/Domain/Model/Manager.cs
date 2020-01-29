using System;

namespace Domain.Model
{
    public class Manager
    {
        public Guid Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
    }
}
