using FoodSharing.DataAccessLayer.Entity;
using FoodSharing.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.DataAccessLayer.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly FoodsharingContext _context;

        public UserRepository(FoodsharingContext context)
        {
            _context = context;
        }
        
        public async Task CreateAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(long chatId)
        {
            try
            {
                var user = await _context.Users
                    .Include(x => x.Foods)
                    .SingleOrDefaultAsync(u => u.ChatId == chatId);
                if (user != null)
                {
                    _context.Remove(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<User>> GetAllAdminAsync()
        {
            try
            {
                var admins = new List<User>();
                foreach (var user in await _context.Users.ToListAsync())
                {
                    if (user.IsAdmin == true)
                        admins.Add(user);
                }                    
                return admins;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User?> GetAsync(long chatId)
        {
            try
            {
                return await _context.Users
                    .SingleOrDefaultAsync(u => u.ChatId == chatId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(User user)
        {
            try
            {
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
