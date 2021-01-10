using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class TrocarSenhaDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
    }
}
