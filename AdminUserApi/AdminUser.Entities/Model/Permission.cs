using System;
using System.Collections.Generic;

#nullable disable

namespace AdminUser.Entities.Model
{
    public partial class Permission
    {
        public Permission()
        {
            PermissionRoles = new HashSet<PermissionRole>();
        }

        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
