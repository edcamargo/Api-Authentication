using Authentication.InfraEstrutura.Helpers;
using Authentication.Repository.Interfaces;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Authentication.Services.Services
{
    /// <summary>
    /// Classe que implementa os serviços genéricos.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Declaracao das interfaces
        /// </summary>
        protected IBaseRepository<TEntity> BaseRepository;
        protected IHttpContextAccessor Context { get; set; }

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="repositoryBase"></param>
        /// <param name="context"></param>
        public ServiceBase(IBaseRepository<TEntity> repositoryBase, IHttpContextAccessor context)
        {
            BaseRepository = repositoryBase;
            Context = context;
        }

        public TEntity Add(TEntity obj)
        {
            //var add = Atribuicoes.AtribuirLojaIdEntidade(obj, GetIdUsuarioLogado());
            //BaseRepository.Add(Atribuicoes.AtribuirUsuarioInclusaoId(add, GetIdUsuarioLogado()));

            return BaseRepository.Add(obj);
        }

        public void Update(TEntity obj)
        {
            BaseRepository.Update(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return BaseRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return BaseRepository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            BaseRepository.Remove(obj);
        }

        public void Remove(Func<TEntity, bool> predicate)
        {
            BaseRepository.Remove(predicate);
        }

        public void RemoverLogico(TEntity obj)
        {
            var atualizar = Atribuicoes.AtribuirBoolExcluido(obj, "DateInclude", true);

            BaseRepository.Update(atualizar);
        }

        public string GetIdUsuarioLogado()
        {
            var contador = Context.HttpContext.User.Claims.Count();

            if (contador > 0)
            {
                var NomeUsuario = Context.HttpContext.User.Claims.Where<Claim>(c => c.Type == "NomeUsuario").FirstOrDefault().Value;

                return (NomeUsuario == "") ? null : NomeUsuario;
            }

            return null;
        }
    }
}
