using Authentication.DataVo.ValueObjects;
using Authentication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Services.Interfaces
{
    public interface IGroupsService : IServiceBase<Groups>
    {
        /// <summary>
        /// Return Groups by CompanyId
        /// </summary>
        /// <param name="pCompanyId"></param>
        /// <param name="pId"></param>
        /// <param name="page"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        List<GroupsVo> GetAll(int pCompanyId, int pId = 0, int page = 1, int length = 30);
    }
}
