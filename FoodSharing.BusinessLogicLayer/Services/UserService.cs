using AutoMapper;
using FoodSharing.BusinessLogicLayer.DataTransferObject;
using FoodSharing.BusinessLogicLayer.Interfaces;
using FoodSharing.DataAccessLayer.Entity;
using FoodSharing.DataAccessLayer.Interfaces;
using FoodSharing.DataAccessLayer.Repositories;

namespace FoodSharing.BusinessLogicLayer.Services
{
    public class UserService : IService<UserDto>
    {
        private readonly IUnitOfWork _repo;

        public UserService(IUnitOfWork repo)
        {
            _repo = repo;
        }

        public async Task CreateAsync(UserDto userDto)
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<FoodDto, Food>();
                    cfg.CreateMap<UserDto, User>();
                });
                var mapper = config.CreateMapper();

                var user = mapper.Map<User>(userDto);
                await _repo.Users.CreateAsync(user);
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
                await _repo.Users.DeleteAsync(chatId);
                await _repo.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }          
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Food, FoodDto>();
                    cfg.CreateMap<User, UserDto>();
                });
                var mapper = config.CreateMapper();

                var usersDto = new List<UserDto>(); 
                foreach(var user in  await _repo.Users.GetAllAsync())
                {
                    var userDto = mapper.Map<UserDto>(user);
                    usersDto.Add(userDto);
                }
                return usersDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserDto?> GetAsync(long chatId)
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Food, FoodDto>();
                    cfg.CreateMap<User, UserDto>();
                });
                var mapper = config.CreateMapper();

                var user = await _repo.Users.GetAsync(chatId);
                return mapper.Map<UserDto>(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(UserDto userDto)
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<FoodDto, Food>();
                    cfg.CreateMap<UserDto, User>();
                });
                var mapper = config.CreateMapper();

                var user = mapper.Map<User>(userDto);
                await _repo.Users.UpdateAsync(user);
                await _repo.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CheckUserIsInDb(long chatId)
        {
            try
            {
                var user = await _repo.Users.GetAsync(chatId);

                if (user == null) return false;
                else return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CheckUserIsAdmin(long chatId)
        {
            try
            {
                var user = await (_repo.Users as UserRepository).GetAsync(chatId);

                if (user?.IsAdmin == true) return true;
                else return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
