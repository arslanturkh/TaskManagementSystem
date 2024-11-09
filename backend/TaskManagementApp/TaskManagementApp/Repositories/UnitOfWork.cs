using TaskManagementApp.Data;
using TaskManagementApp.Interfaces;
using TaskManagementApp.Models;

namespace TaskManagementApp.Repositories
{
    // The UnitOfWork class provides a centralized way to manage repositories and commit changes.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRepository<User> Users { get; }
        public IRepository<TaskItem> TaskItems { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new Repository<User>(context);
            TaskItems = new Repository<TaskItem>(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
