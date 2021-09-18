using AdminUserApi.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUserApi.Application
{
    public class PermissionRoleAppService: DbContext
    {
        #region Propiedades
        /// <summary>
        /// Servicio de dominio para admiinstracion de roles y permisos
        /// </summary>
        private readonly PermissionRoleDomainService _permissionRoleDomainService;
        #endregion

        #region Build
        /// <summary>
        /// Constructor de la clase
        /// </summary>|
        /// <param name="permissionRoleDomainService"></param>
        public PermissionRoleAppService(PermissionRoleDomainService permissionRoleDomainService)
        {
            _permissionRoleDomainService = permissionRoleDomainService;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Realiza la inicializacion de Roles y Permisos en la Base de datos
        /// </summary>
        public async Task<bool> SetInitialData()
        {
            try
            {
                await _permissionRoleDomainService.SetInitialData();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        #endregion
        }
}
