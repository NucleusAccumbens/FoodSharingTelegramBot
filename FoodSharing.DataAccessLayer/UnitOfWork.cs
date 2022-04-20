using FoodSharing.DataAccessLayer.Entity;
using FoodSharing.DataAccessLayer.Interfaces;
using FoodSharing.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoodsharingContext _context = new FoodsharingContext();
        public IRepository<User> Users => new UserRepository(_context);
        public IRepository<Food> Foods => new FoodRepository(_context);

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
