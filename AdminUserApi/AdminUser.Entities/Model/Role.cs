using System;
using System.Collections.Generic;

#nullable disable

namespace AdminUser.Entities.Model
{
    public partial class Role
    {
        public Role()
        {
            PermissionRoles = new HashSet<PermissionRole>();
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
