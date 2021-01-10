using Contexto;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ExceptionHandling;

namespace Repository.Impl
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        ApplicationContext _db;
        public UserRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public User FindUser(string email)
        {
            return _db.User.FirstOrDefault(d => d.Email.Equals(email));
        }

        public override EntityEntry<User> Add(User obj)
        {
            if (_db.User.Any(e => e.Email.Equals(obj.Email))) throw new GenericException("Já existe um usuário com este e-mail associado.");
            return base.Add(obj);
        }

        public override EntityEntry<User> Update(User obj)
        {
            if (_db.User.Where(e => e.Id != obj.Id).Any(e => e.Email.Equals(obj.Email))) throw new GenericException("Já existe um usuário com este e-mail associado.");
            return base.Update(obj);
        }
    }
}