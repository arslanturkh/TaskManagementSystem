using TaskManagementApp.Interfaces;
using TaskManagementApp.Models;

namespace TaskManagementApp.bl
{
    public class UserBL
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _unitOfWork.Users.Delete(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
