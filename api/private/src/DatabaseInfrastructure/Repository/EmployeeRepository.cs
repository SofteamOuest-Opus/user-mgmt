using AutoMapper;
using DatabaseInfrastructure.Entities;
using Domain.Model;
using Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatabaseInfrastructure.Repository
{
    public class EmployeeRepository : IReadEmployee, IWriteEmployee
    {
        private readonly UserMgmtContext context;
        private readonly IMapper mapper;
        private readonly ILogger<EmployeeRepository> logger;

        public EmployeeRepository(UserMgmtContext context, IMapper mapper, ILogger<EmployeeRepository> logger)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
        }

        public Employee? GetEmployee(Guid id)
        {
            var entity = context.Employees
                .Where(e => e.Id == id)
                .Include(e => e.Office)
                .Include(e => e.Manager)
                .Include(e => e.HumanResourceManager)
                .Include(e => e.Status)
                .Include(e => e.Occupation)
                .AsNoTracking()
                .FirstOrDefault();
            return entity == null
                ? null
                : mapper.Map<Employee>(entity);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var entities = context.Employees
                .Include(e => e.Office)
                .AsNoTracking();
            return mapper.Map<IEnumerable<Employee>>(entities);
        }

        public async Task<Employee?> CreateEmployeeAsync(Employee employee)
        {
            try
            {
                var entity = mapper.Map<EmployeeEntity>(employee);

                context.Employees.Add(entity);
                await context.SaveChangesAsync();

                context.Entry(entity).State = EntityState.Detached;

                var created = GetEmployee(entity.Id);
                return mapper.Map<Employee>(created);
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Could not create employee {employee}", JsonSerializer.Serialize(employee));
                return null;
            }
        }

        public async Task<Employee?> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                var entity = mapper.Map<EmployeeEntity>(employee);

                context.Employees.Update(entity);
                await context.SaveChangesAsync();

                context.Entry(entity).State = EntityState.Detached;

                var updated = GetEmployee(entity.Id);
                return mapper.Map<Employee>(updated);
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Could not update employee {employee}", JsonSerializer.Serialize(employee));
                return null;
            }
        }
    }
}
