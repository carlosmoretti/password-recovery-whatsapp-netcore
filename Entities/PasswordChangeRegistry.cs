using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class PasswordChangeRegistry : DomainBase
    {
        public virtual User User { get;set; }
        public Guid User_Id { get; set; }
        public String Password { get; set; }
        public DateTime Expiration { get; set; }
        public String Token { get; set; }
        public bool IsChanged { get; set; }
    }
}
