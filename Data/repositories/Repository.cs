using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserPermissionsManagement.Contexts;

namespace UserPermissionsManagement.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UserPermissionsContext context;
        private readonly DbSet<T> entities;

        public Repository(UserPermissionsContext context)
        {
            this.context = context;
            this.entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public async Task<T> GetById(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            entities.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await entities.FindAsync(id);
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
