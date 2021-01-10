using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User FindUser(string email);
    }
}
