using Authentication.Domain.Entities;
using Authentication.Domain.Filters;
using Authentication.Repository.Context;
using Authentication.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Authentication.Repository.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="context"></param>
        public CompanyRepository(AuthContext context) : base(context)
        { }
    }
}
