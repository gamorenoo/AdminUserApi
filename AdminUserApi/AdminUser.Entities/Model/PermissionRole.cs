using System;
using System.Collections.Generic;

#nullable disable

namespace AdminUser.Entities.Model
{
    public partial class PermissionRole
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}
