using AdminUserApi.Domain.Entities;
using AdminUserApi.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUserApi.Automapper
{
    public class GlobalMapperProfile : Profile
    {
        /// <summary>
        /// Inicia una nueva instancia del perfil
        /// </summary>
        public GlobalMapperProfile() : base()
        {
            CreateMap<UsersDTO, Users>();
            CreateMap<Users, UsersDTO>()
                .ForMember(d => d.RoleName, o => o.MapFrom(s => s.Role.Name));
            CreateMap<Role, RoleDTO>();
        }
    }
}
