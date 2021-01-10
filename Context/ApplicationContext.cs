using System;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContext db) : base(db)
        {

        }
    }
}
