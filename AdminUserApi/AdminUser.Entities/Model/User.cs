using System;
using System.Collections.Generic;

#nullable disable

namespace AdminUser.Entities.Model
{
    public partial class User
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
