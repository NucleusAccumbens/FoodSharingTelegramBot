using AutoMapper;
using FoodSharing.BusinessLogicLayer.DataTransferObject;
using FoodSharing.BusinessLogicLayer.Interfaces;
using FoodSharing.DataAccessLayer.Entity;
using FoodSharing.DataAccessLayer.Interfaces;
using FoodSharing.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.BusinessLogicLayer.Services
{
    public class FoodService : IService<FoodDto>
    {
        private readonly IUnitOfWork _repo;

        public FoodService(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public async Task CreateAsync(FoodDto foodDto)
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<FoodDto, Food>();
                });
                var mapper = config.CreateMapper();

                var food = mapper.Map<Food>(foodDto);
                await _repo.Foods.CreateAsync(food);
                await _repo.SaveAsync();
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
                await _repo.Foods.DeleteAsync(chatId);
                await _repo.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FoodDto>> GetAllAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Food, FoodDto>();
                });
                var mapper = config.CreateMapper();

                var allFoodsDto = new List<FoodDto>();
                foreach(var food in await _repo.Foods.GetAllAsync())
                {
                    var foodDto = mapper.Map<FoodDto>(food);
                    allFoodsDto.Add(foodDto);
                }
                return allFoodsDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FoodDto>> GetAllUserFoodsAsync(long chatId)
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Food, FoodDto>();
                });
                var mapper = config.CreateMapper();

                var allFoodsDto = new List<FoodDto>();
                foreach (var food in await (_repo.Foods as FoodRepository)
                    .GetAllUserFoodsAsync(chatId))
                {
                    var foodDto = mapper.Map<FoodDto>(food);
                    allFoodsDto.Add(foodDto);
                }
                return allFoodsDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FoodDto>> GetAllPlantBasedRawFoodsAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Food, FoodDto>();
                });
                var mapper = config.CreateMapper();

                var allFoodsDto = new List<FoodDto>();
                foreach (var food in await (_repo.Foods as FoodRepository)
                    .GetAllPlantBasedRawFoodsAsync())
                {
                    var foodDto = mapper.Map<FoodDto>(food);
                    allFoodsDto.Add(foodDto);
                }
                return allFoodsDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FoodDto>> GetAllVeganFoodsAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Food, FoodDto>();
                });
                var mapper = config.CreateMapper();

                var allFoodsDto = new List<FoodDto>();
                foreach (var food in await (_repo.Foods as FoodRepository)
                    .GetAllVeganFoodsAsync())
                {
                    var foodDto = mapper.Map<FoodDto>(food);
                    allFoodsDto.Add(foodDto);
                }
                return allFoodsDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FoodDto>> GetAllGroceryAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Food, FoodDto>();
                });
                var mapper = config.CreateMapper();

                var allFoodsDto = new List<FoodDto>();
                foreach (var food in await (_repo.Foods as FoodRepository)
                    .GetAllGroceryAsync())
                {
                    var foodDto = mapper.Map<FoodDto>(food);
                    allFoodsDto.Add(foodDto);
                }
                return allFoodsDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FoodDto>> GetAllPlourProductAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Food, FoodDto>();
                });
                var mapper = config.CreateMapper();

                var allFoodsDto = new List<FoodDto>();
                foreach (var food in await (_repo.Foods as FoodRepository)
                    .GetAllPlourProductsAsync())
                {
                    var foodDto = mapper.Map<FoodDto>(food);
                    allFoodsDto.Add(foodDto);
                }
                return allFoodsDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FoodDto>> GetAllSweetAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Food, FoodDto>();
                });
                var mapper = config.CreateMapper();

                var allFoodsDto = new List<FoodDto>();
                foreach (var food in await (_repo.Foods as FoodRepository)
                    .GetAllSweetAsync())
                {
                    var foodDto = mapper.Map<FoodDto>(food);
                    allFoodsDto.Add(foodDto);
                }
                return allFoodsDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FoodDto>> GetAllOtherFoodsAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Food, FoodDto>();
                });
                var mapper = config.CreateMapper();

                var allFoodsDto = new List<FoodDto>();
                foreach (var food in await (_repo.Foods as FoodRepository)
                    .GetAllOtherFoodsAsync())
                {
                    var foodDto = mapper.Map<FoodDto>(food);
                    allFoodsDto.Add(foodDto);
                }
                return allFoodsDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FoodDto?> GetAsync(long chatId)
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Food, FoodDto>();
                });
                var mapper = config.CreateMapper();

                var food = await _repo.Foods.GetAsync(chatId);
                return mapper.Map<FoodDto>(food);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(FoodDto foodDto)
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<FoodDto, Food>();
                });
                var mapper = config.CreateMapper();

                var food = mapper.Map<Food>(foodDto);
                await _repo.Foods.UpdateAsync(food);
                await _repo.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
