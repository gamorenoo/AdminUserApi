using AdminUserApi.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionRoleController : ControllerBase
    {
        #region Fields
        /// <summary>
        /// Servicio de aplicacion administracion depermisos
        /// </summary>
        private readonly PermissionRoleAppService _permissionRoleAppService;
        #endregion

        #region Builders
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="permissionRoleAppService"></param>
        public PermissionRoleController(PermissionRoleAppService permissionRoleAppService)
        {
            _permissionRoleAppService = permissionRoleAppService;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Crea la configuracion inicial de roles y permisos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        // [Route("Add")]
        public async Task<ActionResult> SetInitialData()
        {
            var result = await _permissionRoleAppService.SetInitialData();
            if (result == true)
            {
                return Ok("Se ha creado la data inicial conrrectamente");
            }
            else
            {
                return BadRequest("Error al crear los datos iniciales");
            }
        }

        #endregion
    }
}
