using Freela.Application.ViewModels;
using Freela.Core.Entities;
using Freela.Core.Repositories;
using Freela.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Freela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _authService = authService; 
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //USAR O MESMO ALGORITMO PARA CRIAR O HASH DESSA SENHA
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            //BUSCAR NO BD UM USER QUE TENHA O MEU E-MAIL E MINHA SENHA
            var user = await _userRepository.GetByEmailAndPasswordAsync(request.Email, passwordHash);

            // SE NÃO EXISTIR RETORNAR ERRO NO LOGIN
            if(user == null)
            {
                return null;
            }

            //SE EXISTIR GERAR O TOKEN USANDO OS DADOS DE USUARIO
            var token = _authService.GenerateJwtToken(user.Email, user.Role);
            return new LoginUserViewModel(user.Email, token);            
        }
    }
}
