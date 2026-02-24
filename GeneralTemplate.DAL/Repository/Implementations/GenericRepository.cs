
namespace GeneralTemplate.DAL.Repository.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _table.ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
            => await _table.FindAsync(id);

        public async Task AddAsync(T entity)
            => await _table.AddAsync(entity);

        public void Update(T entity)
            => _table.Update(entity);

        public void Delete(T entity)
            => _table.Remove(entity);

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}

