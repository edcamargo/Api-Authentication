using Authentication.DataVo.Interfaces;
using Authentication.DataVo.ValueObjects;
using Authentication.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Authentication.DataVo.Converters
{
    public class UsersConverter : IParser<UsersVo.UserVo, Users>, IParser<Users, UsersVo.UserVo>
    {
        private CompanyConverter _companyConverter = new CompanyConverter();

        public Users Parse(UsersVo.UserVo origin)
        {
            if (origin == null) return new Users();
            return new Users
            {
                Id = origin.Id,
                CompanyId = origin.CompanyId,
                Name = origin.Name,
                Login = origin.Login,
                PassWord = origin.PassWord,
                Email = origin.Email,
                DateInclude = origin.DateInclude,
                Status = origin.Status,
                User = origin.User
            };
        }

        public UsersVo.UserVo Parse(Users origin)
        {
            if (origin == null) return new UsersVo.UserVo();
            return new UsersVo.UserVo
            {
                Id = origin.Id,
                CompanyId = origin.CompanyId,
                Company = _companyConverter.Parse(origin.Company),
                Name = origin.Name,
                Login = origin.Login,
                PassWord = origin.PassWord,
                Email = origin.Email,
                DateInclude = origin.DateInclude,
                Status = origin.Status,
                User = origin.User
            };
        }

        public List<Users> ParseList(List<UsersVo.UserVo> origin)
        {
            if (origin == null) return new List<Users>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<UsersVo.UserVo> ParseList(List<Users> origin)
        {
            if (origin == null) return new List<UsersVo.UserVo>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
