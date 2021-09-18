using AdminUserApi.Domain.Entities;
using AdminUserApi.Models;
using AdminUserApi.Models.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUserApi.Domain.Services
{
    public class PermissionRoleDomainService
    {
        #region Propiedades
        /// <summary>
        /// Repositorio de roles
        /// </summary>
        private readonly IGenericRepository<Role> _roleRepository;
        /// <summary>
        /// Repositorio de permisos
        /// </summary>
        private readonly IGenericRepository<Permission> _permissionRepository;
        /// <summary>
        /// Repositorio de relacion entre permisos y roles
        /// </summary>
        private readonly IGenericRepository<PermissionRole> _permissionRoleRepository;
        /// <summary>
        /// Repositorio de relacion entre permisos y roles
        /// </summary>
        private readonly IGenericRepository<Users> _userRepository;
        #endregion

        #region Build
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="roleRepository"></param>
        /// <param name="permissionRepository"></param>
        /// <param name="permissionRoleRepository"></param>
        public PermissionRoleDomainService(IGenericRepository<Role> roleRepository, IGenericRepository<Permission> permissionRepository, IGenericRepository<PermissionRole> permissionRoleRepository, IGenericRepository<Users> userRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
            _permissionRoleRepository = permissionRoleRepository;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Realiza la inicializacion de Roles y Permisos en la Base de datos
        /// </summary>
        public async Task SetInitialData()
        {

            // 1. insertando permisos
            var permissions = await _permissionRepository.GetList();
            if (permissions.Count() == 0)
            {
                permissions = setPermissions().GetAwaiter().GetResult().ToList();
            }

            // 2. Insertando Roles si no existen
            var roles = await _roleRepository.GetList();
            if (roles.Count() == 0)
            {
                roles = setRoles(permissions).GetAwaiter().GetResult().ToList();

            }

            // 3. Crear usuario por defecto (admon/123)

            var u = await _userRepository.GetList(u => u.Code.Equals("Admon"));
            if (u.FirstOrDefault() == null) {
                byte[] myByte = System.Text.Encoding.UTF8.GetBytes("123");
                var password = Convert.ToBase64String(myByte);
                var user = new Users()
                {
                    Code = "Admon",
                    Name = "Gustavo Adolfo",
                    LastName = "Moreno Ospino",
                    Password = password,
                    Address = "Carrera 69C # 64 - 99  Apto 303",
                    Email = "gustavoamoreno@outlook.com",
                    Age = 34,
                    Phone = "3126587972",
                    RoleId = roles.Where(r => r.Code.Equals("Administrador")).First().Id
                };
                await _userRepository.Add(user);
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Inserta los roles por defecto
        /// </summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        private async Task<List<Role>> setRoles(List<Permission> permissions) {
            List<Role> listRole = new List<Role>() {
                    new Role(){
                        Code = "Administrador",
                        Name = "Administrador",
                        PermissionRoles = new List<PermissionRole>(){
                            new PermissionRole() { Permission = permissions.Where(p => p.Code.Equals("Visitante")).FirstOrDefault()},
                            new PermissionRole() { Permission = permissions.Where(p => p.Code.Equals("Asistente")).FirstOrDefault()},
                            new PermissionRole() { Permission = permissions.Where(p => p.Code.Equals("Editor")).FirstOrDefault()},
                            new PermissionRole() { Permission = permissions.Where(p => p.Code.Equals("Administrador")).FirstOrDefault()}
                        }
                    },
                    new Role(){
                        Code = "Editor",
                        Name = "Editor",
                        PermissionRoles = new List<PermissionRole>(){
                            new PermissionRole() { Permission = permissions.Where(p => p.Code.Equals("Visitante")).FirstOrDefault()},
                            new PermissionRole() { Permission = permissions.Where(p => p.Code.Equals("Asistente")).FirstOrDefault()},
                            new PermissionRole() { Permission = permissions.Where(p => p.Code.Equals("Editor")).FirstOrDefault()}
                        }
                    },
                    new Role(){
                        Code = "Asistente",
                        Name = "Asistente",
                        PermissionRoles = new List<PermissionRole>(){ 
                            new PermissionRole() { Permission = permissions.Where(p => p.Code.Equals("Visitante")).FirstOrDefault()},
                            new PermissionRole() { Permission = permissions.Where(p => p.Code.Equals("Asistente")).FirstOrDefault()}
                        }
                    },
                    new Role(){
                        Code = "Visitante",
                        Name = "Visitante",
                        PermissionRoles = new List<PermissionRole>(){ new PermissionRole() { Permission = permissions.Where(p => p.Code.Equals("Visitante")).FirstOrDefault()} }
                    }
                };
            var result = await _roleRepository.AddRange(listRole);
            return result.ToList();
        }

        /// <summary>
        /// Inserta Los Permisos por defecto 
        /// </summary>
        /// <returns></returns>
        private async Task<List<Permission>> setPermissions() {
            List<Permission> listPermission = new List<Permission>() {
                    new Permission(){
                        Code = "Administrador",
                        Name = "Administrador"
                    },
                    new Permission(){
                        Code = "Editor",
                        Name = "Editor"
                    },
                    new Permission(){
                        Code = "Asistente",
                        Name = "Asistente"
                    },
                    new Permission(){
                        Code = "Visitante",
                        Name = "Visitante"
                    }
                };
            listPermission = await _permissionRepository.AddRange(listPermission);
            return listPermission.ToList();
        }

        #endregion
    }
}
