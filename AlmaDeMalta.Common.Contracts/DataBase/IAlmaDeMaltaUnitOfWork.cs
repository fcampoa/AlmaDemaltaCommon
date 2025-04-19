using AlmaDeMalta.Common.Contracts.Contracts;
using AlmaDeMalta.Common.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmaDeMalta.Common.Contracts.DataBase
{
    public interface IAlmaDeMaltaUnitOfWork: IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
    }
}
