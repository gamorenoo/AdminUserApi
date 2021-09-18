using AdminUserApi.Application;
using AdminUserApi.Domain.Entities;
using AdminUserApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                return BadRequest("Error al consultar el usuario:" + (string)result);
            }
        }

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
        [HttpGet]
        [Route("login")]
        public async Task<ActionResult> login(string code, string password)
        {
            var result = await _userAppService.Login(code, password);
            if (result == null) {
                return NotFound("No se encuentra usuario asociado al codigo: " + code );
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
        #endregion
    }
}
