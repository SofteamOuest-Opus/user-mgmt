using Domain.Model;
using Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IReadEmployee readEmployee;
        private readonly IWriteEmployee writeEmployee;

        public EmployeeService(IReadEmployee readEmployee, IWriteEmployee writeEmployee)
        {
            this.readEmployee = readEmployee;
            this.writeEmployee = writeEmployee;
        }

        public Employee? GetEmployee(Guid id) => readEmployee.GetEmployee(id);

        public IEnumerable<Employee> GetEmployees() => readEmployee.GetEmployees();

        public async Task<(ServiceResult, Employee?)> CreateEmployeeAsync(Employee employee)
        {
            var employeeClone = (Employee)employee.Clone();
            if (employeeClone.Id == default)
            {
                employeeClone.Id = Guid.NewGuid();
            }

            var created = await writeEmployee.CreateEmployeeAsync(employeeClone);
            if (created == default)
            {
                return (ServiceResult.Error, created);
            }

            return (ServiceResult.Created, created);
        }

        public async Task<(ServiceResult, Employee?)> UpdateEmployeeAsync(Guid id, Employee employee)
        {
            var employeeClone = (Employee)employee.Clone();
            employeeClone.Id = id;

            var existing = GetEmployee(id);
            if (existing == default)
            {
                return await CreateEmployeeAsync(employeeClone);
            }

            var updated = await writeEmployee.UpdateEmployeeAsync(employeeClone);
            if (updated == default)
            {
                return (ServiceResult.Error, updated);
            }

            return (ServiceResult.Updated, updated);
        }
    }
}
