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
    public class FoodRepository : IRepository<Food>
    {
        private readonly FoodsharingContext _context;

        public FoodRepository(FoodsharingContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Food food)
        {
            try
            {
                await _context.Foods.AddAsync(food);
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
                var food = await _context.Foods
                    .SingleOrDefaultAsync(f => f.ChatId == chatId);
                if (food != null)
                {
                    _context.Foods.Remove(food);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Food>> GetAllAsync()
        {
            try
            {
                return await _context.Foods.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Food>> GetAllUserFoodsAsync(long chatId)
        {
            try
            {
                var userFoods = new List<Food>();
                foreach(var food in await _context.Foods.ToListAsync())
                {
                    if (food.ChatId == chatId)
                        userFoods.Add(food);
                }
                return userFoods;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Food>> GetAllPlantBasedRawFoodsAsync()
        {
            try
            {
                var plantBasedRawFoods = new List<Food>();
                foreach (var food in await _context.Foods.ToListAsync())
                {
                    if (food.Category == Enum.FoodCategory.PlantBasedRawFoods)
                        plantBasedRawFoods.Add(food);
                }
                return plantBasedRawFoods;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Food>> GetAllVeganFoodsAsync()
        {
            try
            {
                var veganFoods = new List<Food>();
                foreach (var food in await _context.Foods.ToListAsync())
                {
                    if (food.Category == Enum.FoodCategory.VeganFoods)
                        veganFoods.Add(food);
                }
                return veganFoods;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Food>> GetAllGroceryAsync()
        {
            try
            {
                var grocery = new List<Food>();
                foreach (var food in await _context.Foods.ToListAsync())
                {
                    if (food.Category == Enum.FoodCategory.Grocery)
                        grocery.Add(food);
                }
                return grocery;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Food>> GetAllPlourProductsAsync()
        {
            try
            {
                var plourProducts = new List<Food>();
                foreach (var food in await _context.Foods.ToListAsync())
                {
                    if (food.Category == Enum.FoodCategory.PlourProducts)
                        plourProducts.Add(food);
                }
                return plourProducts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Food>> GetAllSweetAsync()
        {
            try
            {
                var sweet = new List<Food>();
                foreach (var food in await _context.Foods.ToListAsync())
                {
                    if (food.Category == Enum.FoodCategory.Sweet)
                        sweet.Add(food);
                }
                return sweet;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Food>> GetAllOtherFoodsAsync()
        {
            try
            {
                var otherFoods = new List<Food>();
                foreach (var food in await _context.Foods.ToListAsync())
                {
                    if (food.Category == Enum.FoodCategory.Other)
                        otherFoods.Add(food);
                }
                return otherFoods;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Food?> GetAsync(long id)
        {
            try
            {
                return await _context.Foods
                    .SingleOrDefaultAsync(f => f.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Food food)
        {
            try
            {
                _context.Entry(food).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
