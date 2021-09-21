using Nomina2018.Core.Entities;
using System.Threading.Tasks;

namespace Nomina2018.Core.Interfaces
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}
