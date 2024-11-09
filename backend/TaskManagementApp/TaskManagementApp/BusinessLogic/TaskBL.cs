using TaskManagementApp.Interfaces;
using TaskManagementApp.Models;

namespace TaskManagementApp.bl
{
    public class TaskBL
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TaskItem>> GetTasksAsync()
        {
            return await _unitOfWork.TaskItems.GetAllAsync();
        }

        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            return await _unitOfWork.TaskItems.GetByIdAsync(id);
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            await _unitOfWork.TaskItems.AddAsync(task);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            _unitOfWork.TaskItems.Update(task);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(TaskItem task)
        {
            _unitOfWork.TaskItems.Delete(task);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
