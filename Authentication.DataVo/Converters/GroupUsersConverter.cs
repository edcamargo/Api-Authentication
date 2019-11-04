using Authentication.DataVo.Interfaces;
using Authentication.DataVo.ValueObjects;
using Authentication.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Authentication.DataVo.Converters
{
    public class GroupUsersConverter : IParser<GroupUsersVo, GroupUsers>, IParser<GroupUsers, GroupUsersVo>
    {
        private GroupsConverter _groupsConverter = new GroupsConverter();

        private UsersConverter _usersConverter = new UsersConverter();

        public GroupUsers Parse(GroupUsersVo origin)
        {
            if (origin == null) return new GroupUsers();
            return new GroupUsers
            {
                Id = origin.Id,
                GroupId = origin.GroupId,
                UserId = origin.UserId
            };
        }

        public GroupUsersVo Parse(GroupUsers origin)
        {
            if (origin == null) return new GroupUsersVo();
            return new GroupUsersVo
            {
                Id = origin.Id,
                GroupId = origin.GroupId,
                //Groups = _groupsConverter.Parse(origin.Group),
                UserId = origin.UserId,
                //Users = _usersConverter.Parse(origin.User)
            };
        }

        public List<GroupUsers> ParseList(List<GroupUsersVo> origin)
        {
            if (origin == null) return new List<GroupUsers>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<GroupUsersVo> ParseList(List<GroupUsers> origin)
        {
            if (origin == null) return new List<GroupUsersVo>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
