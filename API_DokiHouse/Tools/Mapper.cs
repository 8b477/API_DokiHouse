﻿using DAL_DokiHouse.DTO;

using System.Xml.Linq;

namespace API_DokiHouse.Services
{
    public static class Mapper
    {
        public static UserCreateDTO FromConfirmPassToModelCreate(UserCreateDTOPassConfirm user)
        {
            return new UserCreateDTO(user.Name, user.Email, user.Passwd);
        }

        public static UserCreateDTO FromUpdateToModelCreate(UserUpdateDTO user)
        {
            return new UserCreateDTO(user.Name, user.Email, user.Passwd);
        }
    }
}
