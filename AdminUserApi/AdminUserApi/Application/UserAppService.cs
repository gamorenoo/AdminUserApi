using AdminUserApi.Domain.Entities;
using AdminUserApi.Domain.Services;
using AdminUserApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUserApi.Application
{
    public class UserAppService
    {
        #region Propiedades
        /// <summary>
        /// Servicio de dominio para admiinstracion de usuario
        /// </summary>
        private readonly UserDomainService _userDomainService;
        #endregion

        #region Build
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="userDomainService"></param>
        public UserAppService(UserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Realiza la creacion o actualizacion de un usuario
        /// </summary>
        public async Task<object> Save(UsersDTO user)
        {
            try
            {
                return await _userDomainService.Save(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ex.Message;
            }
        }

        /// <summary>
        /// Obtiene la lista de usuarios
        /// </summary>
        public async Task<object> Get()
        {
            try
            {
                return await _userDomainService.Get();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ex.Message;
            }
        }

        /// <summary>
        /// Obtiene un usuario por su codigo
        /// </summary>
        public async Task<object> GetBycode(string Code)
        {
            try
            {
                return await _userDomainService.GetBycode(Code);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ex.Message;
            }
        }

        /// <summary>
        /// Obtiene un usuario por su codigo
        /// </summary>
        public async Task<object> Login(string Code, string Password)
        {
            try
            {
                return await _userDomainService.Login(Code, Password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ex.Message;
            }
        }
        #endregion
    }
}
