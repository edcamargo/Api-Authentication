using Authentication.Domain.Entities;
using Authentication.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Repository.Repositories
{
    public class GroupUsersRepository : BaseRepository<GroupUsers>, IGroupUsersRepository
    {
        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="context"></param>
        public GroupUsersRepository(AuthContext context) : base(context)
        { }
    }
}
