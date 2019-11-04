using Authentication.DataVo.Interfaces;
using Authentication.DataVo.ValueObjects;
using Authentication.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Authentication.DataVo.Converters
{
    public class GroupsConverter : IParser<GroupsVo, Groups>, IParser<Groups, GroupsVo>
    {
        private CompanyConverter _companyConverter = new CompanyConverter();

        public Groups Parse(GroupsVo origin)
        {
            if (origin == null) return new Groups();
            return new Groups
            {
                Id = origin.Id,
                CompanyId = origin.CompanyId,
                Name = origin.Name,
                DateInclude = origin.DateInclude,
                User = origin.User
            };
        }

        public GroupsVo Parse(Groups origin)
        {
            if (origin == null) return new GroupsVo();
            return new GroupsVo
            {
                Id = origin.Id,
                CompanyId = origin.CompanyId,
                //Company = _companyConverter.Parse(origin.Company),
                Name = origin.Name,
                DateInclude = origin.DateInclude,
                User = origin.User
            };
        }

        public List<Groups> ParseList(List<GroupsVo> origin)
        {
            if (origin == null) return new List<Groups>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<GroupsVo> ParseList(List<Groups> origin)
        {
            if (origin == null) return new List<GroupsVo>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
