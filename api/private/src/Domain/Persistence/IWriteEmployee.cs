using Domain.Model;
using System.Threading.Tasks;

namespace Domain.Persistence
{
    public interface IWriteEmployee
    {
        Task<Employee?> CreateEmployeeAsync(Employee employee);
        Task<Employee?> UpdateEmployeeAsync(Employee employee);
    }
}
