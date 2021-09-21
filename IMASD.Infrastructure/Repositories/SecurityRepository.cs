using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nomina2018.Core.Entities;
using Nomina2018.Core.Interfaces;
using Nomina2018.Infrastructure.Data;
using System.Threading.Tasks;

namespace Nomina2018.Infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(BDNOMINA2018Context context, IConfiguration configuration) : base(context, configuration) { }
        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User == login.User);
        }
    }
}
