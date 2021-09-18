using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUserApi.Domain.Entities
{
    public partial class Permission
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
