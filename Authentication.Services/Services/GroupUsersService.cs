using Authentication.Domain.Entities;
using Authentication.Repository.Repositories;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Authentication.Services.Services
{
    public class GroupUsersService : ServiceBase<GroupUsers>, IGroupUsersService
    {
        /// <summary>
        /// Declaracao das Interfaces
        /// </summary>
        private readonly IGroupUsersRepository _groupsUsersRepository;

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="groupsUsersRepository"></param>
        /// <param name="context"></param>
        public GroupUsersService(IGroupUsersRepository groupsUsersRepository, IHttpContextAccessor context) : base(groupsUsersRepository, context)
        {
            _groupsUsersRepository = groupsUsersRepository;
        }
    }
}
