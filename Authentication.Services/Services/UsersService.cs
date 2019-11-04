using Authentication.DataVo.ValueObjects;
using Authentication.Domain.Entities;
using Authentication.InfraEstrutura.Security;
using Authentication.Repository.Repositories;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Authentication.Services.Services
{
    public class UsersService : ServiceBase<Users>, IUsersService
    {
        /// <summary>
        /// Declaration of Interfaces
        /// </summary>
        private readonly IUsersRepository _usersRepository;

        /// <summary>
        /// Constructor Method
        /// </summary>
        /// <param name="usersRepository"></param>
        /// <param name="context"></param>
        public UsersService(IUsersRepository usersRepository, IHttpContextAccessor context) : base(usersRepository, context)
        {
            _usersRepository = usersRepository;
        }

        public IList<UserLogin> Authenticate(UsersVo.UserLoginVo UserLogin)
        {
            IList<UserLogin> userLogins = new List<UserLogin>(_usersRepository.Authenticate(UserLogin.Login));

            // Compar password
            if(userLogins.Count == 0)
            {
                return userLogins = null;
            }else if (UserLogin.PassWord.Equals(Encryption.Decrypt(userLogins[0].PassWord))) {
                userLogins[0].PassWord = UserLogin.PassWord;

                return userLogins;
            }

            // Return User Login
            return userLogins;
        }
    }
}
