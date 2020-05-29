using Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();

        Employee? GetEmployee(Guid id);

        Task<(ServiceResult, Employee?)> CreateEmployeeAsync(Employee employee);

        Task<(ServiceResult, Employee?)> UpdateEmployeeAsync(Guid id, Employee employee);
    }
}
