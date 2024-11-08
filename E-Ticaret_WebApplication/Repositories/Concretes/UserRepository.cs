using E_Ticaret_WebApplication.Data;
using E_Ticaret_WebApplication.Models;
using E_Ticaret_WebApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret_WebApplication.Repositories.Concretes
{
    public class UserRepository : IUserRepository
    {
        private readonly TrendyolContext _trendyolContext;
        public UserRepository(TrendyolContext context) 
        {
        _trendyolContext = context;
        }   
        public async Task AddUserAsync(User user)
        {
            _trendyolContext.Users.Add(user);
            await _trendyolContext.SaveChangesAsync();
        }



        public async Task DeleteUserAsync(int id)
        {
            var user = await _trendyolContext.Users.FindAsync(id);
            if (user != null)
            {
                _trendyolContext.Users.Remove(user);
                await _trendyolContext.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _trendyolContext.Users.Include(c => c.Cart).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _trendyolContext.Users.Include(c => c.Cart).FirstOrDefaultAsync(u => u.Id == id);    
        }

        public async Task UpdateUserAsync(User user)
        {
            _trendyolContext.Users.Update(user);
            await _trendyolContext.SaveChangesAsync();
        }
    }
}
