using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Entities;
using ExceptionHandling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Repository;
using WebApi.Dto;
using WhatsAppHelper;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IPasswordChangeRegistryRepository _passwordChangeRegistryRepository;
        private IWhatsAppService _whatsAppService;
        public UserController(IUserRepository userRepository, IPasswordChangeRegistryRepository passwordChangeRegistryRepository, IWhatsAppService whatsAppService)
        {
            _userRepository = userRepository;
            _passwordChangeRegistryRepository = passwordChangeRegistryRepository;
            _whatsAppService = whatsAppService;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        [HttpPost]
        public User Adicionar([FromBody] User user)
        {
            if (!Regex.Match(user.Password, "^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9])))(?=.{6,})").Success)
            {
                throw new GenericException("Sua senha não está segura o suficiente.");
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var res = _userRepository.Add(user);
            _userRepository.Commit();
            return res.Entity;
        }

        [HttpPost("ConfirmarTrocaSenha")]
        public void ConfirmarTrocaSenha([FromBody] TrocarSenhaDto req)
        {
            var res = _passwordChangeRegistryRepository.FindByUser(req.Email);
            var user = _userRepository.FindUser(req.Email);
            var curtime = DateTime.Now;

            if (res.Expiration < curtime)
                throw new GenericException("Este token expirou. Você precisa solicitar a troca de senha novamente.");

            if(res.Token.Equals(req.Token))
            {
                user.Password = res.Password;
                res.IsChanged = true;

                _passwordChangeRegistryRepository.Update(res);
                _userRepository.Update(user);

                _userRepository.Commit();
            } else
            {
                throw new GenericException("O token informado é inválido!");
            }
        }

        [HttpPost("TrocarSenha")]
        public void TrocarSenha([FromBody] TrocarSenhaDto req)
        {
            var todosItens = _passwordChangeRegistryRepository.GetAll();

            if (!Regex.Match(req.Senha, "^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9])))(?=.{6,})").Success)
            {
                throw new GenericException("Sua senha não está segura o suficiente.");
            }

            req.Senha = BCrypt.Net.BCrypt.HashPassword(req.Senha);

            var usuario = _userRepository.FindUser(req.Email);
            var expiration = DateTime.Now;
            expiration = expiration.AddHours(1);

            string letters = "ABCDEFGHIJKLMNOPRSTUWXYZ";
            Random rand = new Random();
            List<char> token = new List<char>();

            for(var i =0; i < 8; i++)
            {
                var result = rand.Next(0, letters.Length);
                token.Add(letters[result]);
            }

            _passwordChangeRegistryRepository.Add(new PasswordChangeRegistry()
            {
                Expiration = expiration,
                Password = req.Senha,
                User_Id = usuario.Id,
                Token = String.Join("", token),
                IsChanged = false
            });

            _whatsAppService.Send(usuario.Cellphone, string.Join("", token));

            _passwordChangeRegistryRepository.Commit();
        }
    }
}
