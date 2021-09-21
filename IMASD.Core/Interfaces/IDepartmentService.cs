using Nomina2018.Core.Entities;
using System.Collections.Generic;

namespace Nomina2018.Core.Interfaces
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
    }
}
