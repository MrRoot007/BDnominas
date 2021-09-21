using Nomina2018.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina2018.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(EmployeeQueryFilter filter, string actionUrl);
    }
}
