using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using src.DTO;
using src.Entity;
using src.Repository;
using src.Utils;
using static src.DTO.UserDTO;

namespace src.Services.User
{
    public class UserService : IUserService
    {
        protected readonly UserRepository _userRepo;
        protected readonly IMapper _mapper;

        protected readonly IConfiguration _config;

        public UserService(UserRepository userRepo, IMapper mapper, IConfiguration config)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _config = config;
        }

        public async Task<UserReadDto?> CreateOneAsync(UserCreateDto createDto)
        {
            var foundUser = await _userRepo.FindByEmailAsync(createDto.Email);
            if (foundUser != null)
            {
                return null;
            }
            else
            {
                PasswordUtils.HashPassword(
                    createDto.Password,
                    out string hashedPassword,
                    out byte[] salt
                );

                var users = _mapper.Map<UserCreateDto, Users>(createDto);

                users.Password = hashedPassword;
                users.Salt = salt;
                users.Role = Role.Customer;
                // users.Role = Role.Admin;

                var userCreated = await _userRepo.CreateOnAsync(users);
                return _mapper.Map<Users, UserReadDto>(userCreated);
            }
        }

        public async Task<string> LogInAsync(UserLoginDto createDto)
        {
            var foundUser = await _userRepo.FindByEmailAsync(createDto.Email);
            var passwordMatched = PasswordUtils.VerifyPassword(
                createDto.Password,
                foundUser.Password,
                foundUser.Salt
            );
            if (passwordMatched)
            {
                var tokenUtil = new TokenUtils(_config);
                return tokenUtil.GenerateToken(foundUser);
            }
            return "Unauthorized";
        }

        public async Task<bool> DeleteOneAsync(Guid userId)
        {
            var foundUser = await _userRepo.GetByIdAsync(userId);
            var isDeleted = await _userRepo.DeleteOnAsync(foundUser);
            return isDeleted;
        }

        public async Task<List<UserReadDto>> GetAllAsync()
        {
            var userList = await _userRepo.GetAllAsync();
            return _mapper.Map<List<Users>, List<UserReadDto>>(userList);
        }

        public async Task<UserReadDto> GetByIdAsync(Guid userId)
        {
            var foundUser = await _userRepo.GetByIdAsync(userId);
            return _mapper.Map<Users, UserReadDto>(foundUser);
        }

        public async Task<UserProfileDto> GetProfileIdAsync(Guid userId)
        {
            var foundUser = await _userRepo.GetByIdAsync(userId);
            return _mapper.Map<Users, UserProfileDto>(foundUser);
        }

        public async Task<UserProfileDto> UpdateOneAsync(Guid userId, UserProfileDto updateDto)
        {
            var foundUser = await _userRepo.GetByIdAsync(userId);

            if (foundUser == null)
            {
                return null;
            }

            foundUser.Name = updateDto.Name ?? foundUser.Name;
            foundUser.Email = updateDto.Email ?? foundUser.Email;
            foundUser.PhoneNumber = updateDto.PhoneNumber ?? foundUser.PhoneNumber;
            if (!string.IsNullOrEmpty(updateDto.Password))
            {
                PasswordUtils.HashPassword(
                    updateDto.Password,
                    out string hashedPassword,
                    out byte[] salt
                );
                foundUser.Password = hashedPassword;
                foundUser.Salt = salt;
            }

            await _userRepo.UpdateOnAsync(foundUser);

            return _mapper.Map<Users, UserProfileDto>(foundUser);
        }

        public async Task<bool> UpdatePasswordAsync(Guid userId, PasswordUpdateDto updateDto)
        {
            var foundUser = await _userRepo.GetByIdAsync(userId);

            if (foundUser == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(updateDto.Password))
            {
                PasswordUtils.HashPassword(
                    updateDto.Password,
                    out string hashedPassword,
                    out byte[] salt
                );
                foundUser.Password = hashedPassword;
                foundUser.Salt = salt;
            }

            await _userRepo.UpdateOnAsync(foundUser);

            return true;
        }
    }
}
