using Authentication.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Authentication.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Method that inserts a record.
        /// </summary>
        /// <param name="obj"></param>
        TEntity Add(TEntity obj);

        /// <summary>
        /// Method that search a object Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(object id);

        /// <summary>
        /// Método que retorna uma lista com todos registros de uma tabela.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Realiza a atualização de um registro.
        /// </summary>
        /// <param name="obj"></param>
        void Update(TEntity obj);

        /// <summary>
        /// Remove um registro do DB.
        /// </summary>
        /// <param name="obj"></param>
        void Remove(TEntity obj);

        /// <summary>
        /// Remove varios registros
        /// </summary>
        /// <param name="predicate"></param>
        void Remove(Func<TEntity, bool> predicate);

        /// <summary>
        /// Retorna uma lista de acordo com o predicado informado.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Retorna uma lista de acordo com o filtro
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// KeyValuePair<int, IEnumerable<TEntity>> Filter(IFilter<TEntity> filter);
    }
}
