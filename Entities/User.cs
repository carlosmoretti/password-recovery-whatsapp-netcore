using System;
using System.Collections.Generic;

namespace Entities
{
    public class User : DomainBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public List<PasswordChangeRegistry> UserPasswordRegistry { get; set; }
    }
}
