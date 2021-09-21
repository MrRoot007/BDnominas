using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nomina2018.Core.Entities;
using Nomina2018.Core.Interfaces;
using Nomina2018.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nomina2018.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BDNOMINA2018Context _context;
        protected readonly DbSet<T> _entities;
        protected readonly string _connectionString;
        public BaseRepository(BDNOMINA2018Context context, IConfiguration configuration)
        {
            _context = context;
            _entities = context.Set<T>();
            _connectionString = configuration.GetConnectionString("Nominas2018");
        }
        public async Task Add(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.bEnabled = true;
            entity.bDisabled = false;
            await _entities.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.bEnabled = false;
            entity.bDisabled = true;
            entity.DeletedDate = DateTime.Now;
            var x = _entities.Update(entity);
            var x2 = x;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable().Where(x => x.bEnabled == true);
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public void Update(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            var x = _entities.Update(entity);
            var x2 = x;
        }
    }
}
