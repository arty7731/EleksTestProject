using EleksProject.Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleksProject.Business
{
    public class ManagerBase
    {
        /// <summary>
        /// The unit of work.
        /// </summary>
        protected readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerBase"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public ManagerBase(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
    }
}
