using Domain.Model;
using System;
using System.Collections.Generic;

namespace Domain.Persistence
{
    public interface IReadEmployee
    {
        IEnumerable<Employee> GetEmployees();

        Employee? GetEmployee(Guid id);
    }
}
