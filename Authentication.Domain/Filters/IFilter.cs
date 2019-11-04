using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Authentication.Domain.Filters
{
    public abstract class IFilter<TEntity> where TEntity : class
    {
        public int RecordsPerPage { get; set; }

        public int Page { get; set; }

        public virtual Expression<Func<TEntity, bool>> Predicate { get; }
    }
}
