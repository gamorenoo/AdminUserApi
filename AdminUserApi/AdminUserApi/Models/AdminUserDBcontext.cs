using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdminUserApi.Models
{
    public class AdminUserDBcontext : DbContext
    {
        public AdminUserDBcontext(DbContextOptions<AdminUserDBcontext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
