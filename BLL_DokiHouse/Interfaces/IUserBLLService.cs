﻿
using DAL_DokiHouse.DTO;

using Entities_DokiHouse.Entities;

namespace BLL_DokiHouse.Interfaces
{
    public interface IUserBLLService
    {
        Task<bool> Create(UserCreateDTO model);
        Task<IEnumerable<UserDisplayDTO>> Get();
        Task<IEnumerable<UserDisplayDTO>?> GetByName(string name);
        Task<UserDisplayDTO?> GetByID(int id);
        Task<bool> Update(int id, UserCreateDTO model);
        Task<bool> UpdateProfilPicture(int idPicture, int idUser);
        Task<bool> Delete(int id);

        Task<User?> Login(string email, string passwd);
    }
}