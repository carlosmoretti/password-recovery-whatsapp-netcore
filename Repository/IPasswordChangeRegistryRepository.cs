using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IPasswordChangeRegistryRepository : IRepository<PasswordChangeRegistry>
    {
        PasswordChangeRegistry FindByUser(String email);
    }
}
