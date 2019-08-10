using EleksProject.Core.Interfaces.DbContext;
using EleksProject.Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleksProject.Data.Shared
{
    public class UnitOfWorkBase : IUnitOfWork
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private DbContext context;

        /// <summary>
        /// The disposed flag.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The transactions count.
        /// </summary>
        private int transactionsCount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkBase"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <exception cref="System.ArgumentException">Entity Database Context instance is expected as a database Context parameter.</exception>
        public UnitOfWorkBase(IDataContext context)
        {
            this.context = context as DbContext;

            if (context == null)
            {
                throw new ArgumentException("Entity.DbContext instance is expected as a dbContext parameter.");
            }

            this.context.Configuration.LazyLoadingEnabled = false;
            this.context.Configuration.ProxyCreationEnabled = false;
            this.context.Configuration.ValidateOnSaveEnabled = false;
        }

        /// <summary>
        /// Gets the data context.
        /// </summary>        
        public IDataContext DataContext
        {
            get
            {
                return (IDataContext)this.context;
            }
        }

        public int Save()
        {
            int result = 0;

            try
            {
                result = this.context.SaveChanges();
            }
            catch (DbUpdateException updateEx)
            {
                throw new Exception("Updating database error.", updateEx);
            }

            return result;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}
