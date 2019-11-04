using Authentication.DataVo.Interfaces;
using Authentication.DataVo.ValueObjects;
using Authentication.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Authentication.DataVo.Converters
{
    public class CompanyConverter : IParser<CompanyVo, Company>, IParser<Company, CompanyVo>
    {
        public Company Parse(CompanyVo origin)
        {
            if (origin == null) return new Company();
            return new Company
            {
                Id = origin.Id,
                Name = origin.Name,
                Cnpj = origin.Cnpj,
                DateInclude = origin.DateInclude,
                User = origin.User
            };
        }

        public CompanyVo Parse(Company origin)
        {
            if (origin == null) return new CompanyVo();
            return new CompanyVo
            {
                Id = origin.Id,
                Name = origin.Name,
                Cnpj = origin.Cnpj,
                DateInclude = origin.DateInclude,
                User = origin.User
            };
        }

        public List<Company> ParseList(List<CompanyVo> origin)
        {
            if (origin == null) return new List<Company>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<CompanyVo> ParseList(List<Company> origin)
        {
            if (origin == null) return new List<CompanyVo>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
