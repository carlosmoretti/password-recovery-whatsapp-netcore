using Contexto;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ExceptionHandling;

namespace Repository.Impl
{
    public class PasswordChangeRegistryRepository : Repository<PasswordChangeRegistry>, IPasswordChangeRegistryRepository
    {
        ApplicationContext _context;
        public PasswordChangeRegistryRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public PasswordChangeRegistry FindByUser(string email)
        {
            var usuario = _context.User.FirstOrDefault(e => e.Email.Equals(email));
            if (usuario == null) throw new GenericException("Não encontramos nenhum usuário com este e-mail");

            var res = _context.PasswordChangeRegistry
                .Where(e => e.User_Id == usuario.Id && !e.IsChanged).ToList().LastOrDefault();
            if (res == null) throw new GenericException("Não existe token de alteração para este usuário.");

            return res;
        }
    }
}
