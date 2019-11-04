using Authentication.Domain.Entities;
using Authentication.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Authentication.Repository.Repositories
{
    public class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        /// <summary>
        /// Constructor Method
        /// </summary>
        /// <param name="context"></param>
        public UsersRepository(AuthContext context) : base(context)
        { }

        public IList<UserLogin> Authenticate(string pLogin)
        {
            using (var db = new AuthContext())
            {
                var lQuery = (from User in db.Users.AsNoTracking()
                              where User.Login == pLogin
                              select new
                              {
                                  User.Id,
                                  User.Login,
                                  User.PassWord,
                                  User.Name,
                                  User.CompanyId,
                                  User.Company
                              }).ToList().Take(1);

                List<UserLogin> userLogins = new List<UserLogin>();

                foreach (var item in lQuery)
                {
                    UserLogin userLogin = new UserLogin();
                    userLogin.Id = item.Id;
                    userLogin.Login = item.Login;
                    userLogin.PassWord = item.PassWord;

                    userLogins.Add(userLogin);
                }

                // Return for list
                return userLogins;
            }
        }
    }
}
