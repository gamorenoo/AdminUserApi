using System;
using System.Linq;
using AdminUserApi.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using AdminUserApi.Domain.Entities;
using AdminUserApi.Domain.Services;

namespace AdminUserApi.Application
{
    /// <summary>
    /// Servicio de aplicacion para el control de roles
    /// </summary>
    public class RoleAppService
    {
        #region Propiedades
        /// <summary>
        /// Servicio de dominio para admiinstracion de usuario
        /// </summary>
        private readonly RoleDomainService _roleDomainService;
        #endregion

        #region Build
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="roleDomainService"></param>
        public RoleAppService(RoleDomainService roleDomainService)
        {
            _roleDomainService = roleDomainService;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Obtiene la lista de usuarios
        /// </summary>
        public async Task<object> Get()
        {
            try
            {
                return await _roleDomainService.Get();
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
