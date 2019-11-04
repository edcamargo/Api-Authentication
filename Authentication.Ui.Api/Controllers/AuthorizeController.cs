using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Authentication.DataVo.ValueObjects;
using Authentication.Domain;
using Authentication.InfraEstrutura.Security;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Ui.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthorizeController : ControllerBase
    {
        protected readonly IUsersService _usersService;

        public AuthorizeController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        public object Post(
                    [FromBody]UsersVo.UserLoginVo UserLogin,
                    [FromServices]IUsersService UsersService,
                    [FromServices]SigningConfigurations signingConfigurations,
                    [FromServices]TokenConfigurations tokenConfigurations)
        {
            bool credenciaisValidas = false;

            if (UserLogin != null && !String.IsNullOrWhiteSpace(UserLogin.Login))
            {
                var userBase = UsersService.Authenticate(UserLogin);

                credenciaisValidas = (userBase != null && UserLogin.Login == userBase[0].Login && UserLogin.PassWord == userBase[0].PassWord);
            }

            // Verifica se as credenciais são validas
            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(UserLogin.Login.ToString(), "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, UserLogin.Login)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    StatusCode = 401,
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
}
