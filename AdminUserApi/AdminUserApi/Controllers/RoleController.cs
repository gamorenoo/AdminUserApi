using AdminUserApi.DTOs;
using System.Threading.Tasks;
using AdminUserApi.Application;
using Microsoft.AspNetCore.Mvc;

namespace AdminUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        #region Fields
        /// <summary>
        /// Servicio de aplicacion administracion depermisos
        /// </summary>
        private readonly RoleAppService _roleAppService;
        #endregion

        #region Builders
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="roleAppService"></param>
        public RoleController(RoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Obtiene la lista de todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> get()
        {
            var result = await _roleAppService.Get();
            if (!result.GetType().Name.Equals("string"))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error al consultar los roles:" + (string)result);
            }
        }
        #endregion
    }
}
