using System;
using AutoMapper;
using System.Linq;
using AdminUserApi.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using AdminUserApi.Domain.Entities;
using AdminUserApi.Models.Repositories.IRepositories;

namespace AdminUserApi.Domain.Services
{
    /// <summary>
    /// Servico de dominio para la administracion de Roles
    /// </summary>
    public class RoleDomainService
    {
        #region Propiedades
        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Repositorio de roles
        /// </summary>
        private readonly IGenericRepository<Role> _roleRepository;
        #endregion

        #region Build
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="userRepository"></param>
        public RoleDomainService(IMapper mapper, IGenericRepository<Role> roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Consulta todos los roles
        /// </summary>
        public async Task<IEnumerable<RoleDTO>> Get()
        {
            var roles = await _roleRepository.GetList();

            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }
        #endregion
    }
}
