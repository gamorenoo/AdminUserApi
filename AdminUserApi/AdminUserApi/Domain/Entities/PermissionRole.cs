using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUserApi.Domain.Entities
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
