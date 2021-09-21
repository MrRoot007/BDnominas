using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina2018.Core.Entities
{
    public class Department : BaseEntity
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public string SName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
