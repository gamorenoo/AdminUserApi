using AdminUserApi.Domain.Entities;
using AdminUserApi.DTOs;
using AdminUserApi.Models.Repositories.IRepositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUserApi.Domain.Services
{
    public class UserDomainService
    {
        #region Propiedades
        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Repositorio de roles
        /// </summary>
        private readonly IGenericRepository<Users> _userRepository;
        /// <summary>
        /// Repositorio de roles
        /// </summary>
        private readonly IGenericRepository<Role> _roleRepository;
        /// <summary>
        /// Repositorio de relacion entre permisos y roles
        /// </summary>
        private readonly IGenericRepository<PermissionRole> _permissionRoleRepository;
        /// <summary>
        /// Repositorio de permisos
        /// </summary>
        private readonly IGenericRepository<Permission> _permissionRepository;
        #endregion

        #region Build
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="userRepository"></param>
        public UserDomainService(IMapper mapper, IGenericRepository<Users> userRepository, IGenericRepository<Role> roleRepository, IGenericRepository<PermissionRole> permissionRoleRepository, IGenericRepository<Permission> permissionRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _permissionRoleRepository = permissionRoleRepository;
            _permissionRepository = permissionRepository;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Realiza la creacion o actualizacion de un usuario
        /// </summary>
        public async Task<Users> Save(UsersDTO userDto)
        {
            Users user = _mapper.Map<Users>(userDto);
            byte[] myByte = System.Text.Encoding.UTF8.GetBytes(user.Password);
            user.Password = Convert.ToBase64String(myByte);

            if (user.Id == Guid.Empty)
            {
                return await _userRepository.Add(user);
            }
            else {
                return await _userRepository.Update(user);
            }
        }

        /// <summary>
        /// Obtiene la lista de usuarios
        /// </summary>
        public async Task<IEnumerable<Users>> Get()
        {
            return await _userRepository.GetList();
        }

        /// <summary>
        /// Obtiene un usuario por su codigo
        /// </summary>
        public async Task<Users> GetBycode(string Code)
        {
            var resutl = await _userRepository.GetList(u => u.Code.Equals(Code));
            return resutl.FirstOrDefault();
        }

        /// <summary>
        /// Obtiene un usuario por su codigo
        /// </summary>
        public async Task<Users> Login(string Code, string Password)
        {
            byte[] myByte = System.Text.Encoding.UTF8.GetBytes(Password);
            Password = Convert.ToBase64String(myByte);
            var resutl = await _userRepository.GetList(u => u.Code.Equals(Code) && u.Password.Equals(Password));
            Users user = resutl.FirstOrDefault();
            user.Role = _roleRepository.GetList(r => r.Id.Equals(user.RoleId)).GetAwaiter().GetResult().FirstOrDefault();
            user.Role.PermissionRoles = _permissionRoleRepository.GetList(pr => pr.RoleId.Equals(user.RoleId)).GetAwaiter().GetResult().ToList();

            foreach (var item in user.Role.PermissionRoles.ToList())
            {
                item.Permission = _permissionRepository.Get(p => p.Id.Equals(item.PermissionId)).GetAwaiter().GetResult();
            } 
            return resutl.FirstOrDefault();
        }
        #endregion
    }

}
