using EleksProject.Core.Interfaces.Repositories;
using EleksProject.Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EleksProject.Data.Shared
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            this.DataContext = unitOfWork.DataContext as DbContext;
        }

        protected DbContext DataContext
        {
            get;
            private set;
        }

        protected DbSet<T> Select()
        {
            return this.DataContext.Set<T>();
        }

        protected IQueryable<T> Where(Expression<Func<T, bool>> filter)
        {
            return this.Select().Where(filter);
        }
    }
}
