using Authentication.DataVo.Converters;
using Authentication.DataVo.ValueObjects;
using Authentication.Domain.Entities;
using Authentication.Repository.Repositories;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Authentication.Services.Services
{
    public class GroupsService : ServiceBase<Groups>, IGroupsService
    {
        /// <summary>
        /// Declaration of Interfaces
        /// </summary>
        private readonly IGroupsRepository _groupsRepository;
        private readonly GroupsConverter _groupsConverter;

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="groupsRepository"></param>
        /// <param name="context"></param>
        public GroupsService(IGroupsRepository groupsRepository, GroupsConverter groupsConverter, IHttpContextAccessor context) : base(groupsRepository, context)
        {
            _groupsRepository = groupsRepository;
            _groupsConverter = groupsConverter;
        }

        /*
         
        public object GetAllAtivos(int pIdEmpresa, int page, int length)
        {
            var EventoContaEntity = _leiloeiroRepository.GetAllAtivos(pIdEmpresa, page, length);
            var Registros = _leiloeiroConverter.ParseList(EventoContaEntity);
            var TotalRegistros = _leiloeiroRepository.Count(pIdEmpresa);
            return new { Registros, TotalRegistros };
        }     
             
        */

        /// <summary>
        /// Return Groups by CompanyId
        /// </summary>
        /// <param name="pCompanyId"></param>
        /// <param name="pId"></param>
        /// <param name="page"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public List<GroupsVo> GetAll(int pCompanyId, int pId = 0, int page = 1, int length = 30) =>
            _groupsConverter.ParseList(_groupsRepository.GetAll(pCompanyId, pId, page, length));
    }
}
