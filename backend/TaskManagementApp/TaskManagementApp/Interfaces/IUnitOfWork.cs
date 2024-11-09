using TaskManagementApp.Models;

namespace TaskManagementApp.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<TaskItem> TaskItems { get; }
        Task<int> SaveChangesAsync();
    }
}
