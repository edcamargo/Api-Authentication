using Authentication.Domain.Entities;
using Authentication.Repository.Interfaces;
using System.Collections.Generic;

namespace Authentication.Repository.Repositories
{
    public interface IUsersRepository : IBaseRepository<Users>
    {
        /// <summary>
        /// User Authentication Method
        /// </summary>
        /// <param name="UserLogin"></param>
        /// <returns></returns>
        IList<UserLogin> Authenticate(string pNomeUsuario);
    }
}
