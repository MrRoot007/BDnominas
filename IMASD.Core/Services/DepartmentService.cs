using Microsoft.Extensions.Options;
using Nomina2018.Core.Entities;
using Nomina2018.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina2018.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _iUnitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _iUnitOfWork = unitOfWork;
        }
        public List<Department> GetDepartments()
        {
            return _iUnitOfWork.DepartmentRepository.GetAll().ToList();
        }
    }
}
