using AlmaDeMalta.Common.Contracts.Contracts;
using AlmaDeMalta.Common.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmaDeMalta.Common.Contracts.DataBase;
    public interface IUnitOfWork
    {
    IRepository<Product> ProductRepository { get; }
    /// <summary>
    /// Save changes to the database.
    /// </summary>
    /// <returns>True if the changes were saved successfully, otherwise false.</returns>
    bool SaveChanges();
    /// <summary>
    /// Asynchronously save changes to the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous save operation. The task result contains true if the changes were saved successfully, otherwise false.</returns>
    Task<bool> SaveChangesAsync();
    public void Dispose();
}
