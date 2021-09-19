using AdminUserApi.DTOs;
using System.Threading.Tasks;
using AdminUserApi.Application;
using Microsoft.AspNetCore.Mvc;

namespace AdminUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Fields
        /// <summary>
        /// Servicio de aplicacion administracion depermisos
        /// </summary>
        private readonly UserAppService _userAppService;
        #endregion

        #region Builders
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userAppService"></param>
        public UserController(UserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Crea o actualiza un usuario
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        // [Route("Add")]
        public async Task<ActionResult> save(UsersDTO user)
        {
            var result = await _userAppService.Save(user);
            if (result.GetType().Name.Equals("Users"))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error al crear el usuario:" + (string)result);
            }
        }

        /// <summary>
        /// Obtiene la lista de todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> get()
        {
            var result = await _userAppService.Get();
            if (!result.GetType().Name.Equals("string"))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error al consultar los usuario:" + (string)result);
            }
        }

        /// <summary>
        /// Obtiene un usuario por su codigo
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{code}")]
        public async Task<ActionResult> getByCode(string code)
        {
            var result = await _userAppService.GetBycode(code);
            if (result.GetType().Name.Equals("Users"))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error al consultar el usuario:" + (string)result);
            }
        }

        /// <summary>
        /// Valiad usuario y clave
        /// </summary>
        /// <param name="code"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("login")]
        public async Task<ActionResult> login(string code, string password)
        {
            var result = await _userAppService.Login(code, password);
            if (result == null) {
                return NoContent();
            }
            else if (result.GetType().Name.Equals("Users"))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error al consultar el usuario:" + (string)result);
            }
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> delete(string code)
        {
            var result = await _userAppService.Delete(code);
            if (result.GetType().Name.Equals("Boolean"))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error al eliminar el usuario:" + (string)result);
            }
        }
        #endregion
    }
}
