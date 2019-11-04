using Authentication.Domain.Entities;
using Authentication.Repository.Repositories;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Authentication.Services.Services
{
    public class CompanyService : ServiceBase<Company>, ICompanyService
    {
        /// <summary>
        /// Declaracao das Interfaces
        /// </summary>
        private readonly ICompanyRepository _companyRepository;

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="companyRepository"></param>
        /// <param name="context"></param>
        public CompanyService(ICompanyRepository companyRepository, IHttpContextAccessor context) : base(companyRepository, context)
        {
            _companyRepository = companyRepository;
        }
    }
}
