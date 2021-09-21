using Microsoft.Extensions.Configuration;
using Nomina2018.Core.Interfaces;
using Nomina2018.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina2018.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BDNOMINA2018Context _context;
        private readonly IEmployeeRepository _iEmployeeRepository;
        private readonly IDepartmentRepository _iDepartmentRepository;
        private readonly IConfiguration _configuration;
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(BDNOMINA2018Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public IEmployeeRepository EmployeeRepository => _iEmployeeRepository ?? new EmployeeRepository(_context, _configuration);
        public IDepartmentRepository DepartmentRepository => _iDepartmentRepository ?? new DepartmentRepository(_context, _configuration);
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context, _configuration);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
