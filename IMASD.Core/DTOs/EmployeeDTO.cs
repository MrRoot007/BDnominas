using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina2018.Core.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string SName { get; set; }
        public string SLastName { get; set; }
        public decimal? DSalary { get; set; }
        public int? IZipCode { get; set; }
        public string SStreet { get; set; }
        public string SCity { get; set; }
        public string SCountry { get; set; }
        public int? IIdDepartment { get; set; }
    }
}
