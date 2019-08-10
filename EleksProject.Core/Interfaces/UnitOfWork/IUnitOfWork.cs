using EleksProject.Core.Interfaces.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleksProject.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDataContext DataContext { get; }

        int Save();
    }
}
