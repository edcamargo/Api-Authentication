using Authentication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static Authentication.DataVo.ValueObjects.UsersVo;

namespace Authentication.Services.Interfaces
{
    public interface IUsersService : IServiceBase<Users>
    {
        /// <summary>
        /// User Authentication Method
        /// </summary>
        /// <param name="UsuarioLogin"></param>
        /// <returns></returns>
        IList<UserLogin> Authenticate(UserLoginVo UserLogin);
    }
}
