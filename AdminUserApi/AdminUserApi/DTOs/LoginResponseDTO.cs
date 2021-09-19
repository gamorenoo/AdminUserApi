using AdminUserApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUserApi.DTOs
{
    public class LoginResponseDTO
    {
        public Users User { get; set; }
        public string Token { get; set; }
    }
}
