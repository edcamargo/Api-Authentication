using Authentication.Domain.Entities;
using Authentication.Repository.Interfaces;
using System.Collections.Generic;

namespace Authentication.Repository.Repositories
{
    public interface IGroupsRepository : IBaseRepository<Groups>
    {
        /// <summary>
        /// Return Groups by CompanyId
        /// </summary>
        /// <param name="pCompanyId"></param>
        /// <param name="pId"></param>
        /// <param name="page"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        List<Groups> GetAll(int pCompanyId, int pId = 0, int page = 1, int length = 30);
    }
}
