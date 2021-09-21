using Nomina2018.Core.Entities;
using Nomina2018.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nomina2018.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<List<Employee>> GetEmployeesByDepartment(int id);
        Task<Employee> GetEmployee(int id);
        Task<Employee> CreateEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);
    }
}
