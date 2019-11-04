using Authentication.Domain.Entities;
using Authentication.Repository.Context;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repository.Repositories
{
    public class GroupsRepository : BaseRepository<Groups>, IGroupsRepository
    {
        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="context"></param>
        public GroupsRepository(AuthContext context) : base(context)
        { }

        /// <summary>
        /// Return Groups by CompanyId
        /// </summary>
        /// <param name="pCompanyId"></param>
        /// <param name="pId"></param>
        /// <param name="page"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public List<Groups> GetAll(int pCompanyId, int pId = 0, int page = 1, int length = 30)
        {
            using (var db = new AuthContext())
            {
                var lQuery = (from Groups in db.Groups.AsNoTracking()
                              //.Include("Company")
                              where Groups.CompanyId == pCompanyId
                              && (pId == 0 || Groups.Id == pId)
                              select Groups)
                              .Skip((page - 1) * length)
                              .Take(length)
                              .ToList();

                return lQuery;
            }
        }
    }
}
