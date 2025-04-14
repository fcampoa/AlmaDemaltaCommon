using AlmaDeMalta.Common.Contracts.Attributes;
using MongoDB.Driver;
using System.Reflection;

namespace AlmaDeMalta.Common.Contracts.Repositories;
public class RepositoryBase<T>(IMongoDatabase _database) : IRepository<T> where T : class
{
    private readonly IMongoCollection<T> _collection = _database.GetCollection<T>(typeof(T).GetCustomAttribute<CollectionName>().Name);
}
