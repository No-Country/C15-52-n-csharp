using Microsoft.EntityFrameworkCore;
using PharmacyInventory.DataAccess.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PharmacyInventory.DataAccess.Repositories
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbset;
        public Repositorio(ApplicationDbContext context)
        {
            _context = context;
            this.dbset = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbset.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(
                                                                Expression<Func<T, bool>> filter = null, 
                                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
                                                                string includeProperties = null, 
                                                                bool isTracking = true)
        {
            IQueryable<T> query = dbset;

            if (filter != null) query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            if (orderBy != null) query = orderBy(query);

            if (!isTracking) query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbset.FindAsync(id);
        }

        public async Task<T> GetOneAsync(
                                        Expression<Func<T, bool>> filter = null, 
                                        string includeProperties = null, 
                                        bool isTracking = true)
        {
            IQueryable<T> query = dbset;

            if (filter != null) query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            if (!isTracking) query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }
    }
}
