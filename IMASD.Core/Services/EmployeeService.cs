using Microsoft.Extensions.Options;
using Nomina2018.Core.CustomEntities;
using Nomina2018.Core.Entities;
using Nomina2018.Core.Interfaces;
using Nomina2018.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina2018.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public EmployeeService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var id = await _unitOfWork.EmployeeRepository.CreateEmployee(employee);
            employee.Id = id;
            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var existingUser = await SearchEmploye(id);
            if (existingUser != null)
            {
                await _unitOfWork.EmployeeRepository.DeleteEmployee(id);
                return true;
            }
            return false;
        }

        public Task<Employee> GetEmployee(int id)
        {
            return _unitOfWork.EmployeeRepository.GetEmployeeById(id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetEmployees();
            return employees.ToList();
        }
        public async Task<List<Employee>> GetEmployeesByDepartment(int id)
        {
            var employees = await _unitOfWork.EmployeeRepository.GetEmployeesByDepartment(id);
            return employees.ToList();
        }
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            //var existingUser = await SearchEmploye(employee.Id);
            if (employee.Id > 0)
            {
                await _unitOfWork.EmployeeRepository.UpdateEmployee(employee);
                return true;
            }
            return false;
        }
        private async Task<Employee> SearchEmploye(int id)
        {
            return await _unitOfWork.EmployeeRepository.GetById(id);
        }
    }
}
