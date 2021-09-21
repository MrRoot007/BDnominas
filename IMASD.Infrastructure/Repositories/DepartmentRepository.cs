using Microsoft.Extensions.Configuration;
using Nomina2018.Core.Entities;
using Nomina2018.Core.Interfaces;
using Nomina2018.Infrastructure.Data;

namespace Nomina2018.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(BDNOMINA2018Context context, IConfiguration configuration) : base(context, configuration) { }
    }
}
