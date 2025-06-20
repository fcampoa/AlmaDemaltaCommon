
using AlmaDeMalta.Common.Contracts.DataBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace AlmaDeMalta.Common.DatabaseConnection;
    public static class ExtensionMethods
    {
    public static IServiceCollection UseMongoConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["MongoDb:ConnectionString"];
        var databaseName = configuration["MongoDb:DatabaseName"];

        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String)); // Representar GUIDs como cadenas


        var mongoClientSettings = MongoClientSettings.FromConnectionString(connectionString);

        services.AddSingleton<IMongoClient>(s => new MongoClient(mongoClientSettings));
        services.AddSingleton<IDbContext>(s =>
        {
            var mongoClient = s.GetRequiredService<IMongoClient>();
            return new MongoDbContext(mongoClient, databaseName);
        });
        //services.AddScoped<IAlmaDeMaltaUnitOfWork>(s =>
        //{
        //    var dbContext = s.GetRequiredService<IDbContext>();
        //    return new AlmaDeMaltaUnitOfWork(dbContext);
        //});
        services.AddScoped<IUnitOfWork>(s =>
        {
            var dbContext = s.GetRequiredService<IDbContext>();
            return new UnitOfWork(dbContext);
        });
        return services;
    }

    public static IServiceCollection UseSandBox(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDbContext>(s =>
        {
            return new SandBoxDbContext();
        });
        services.AddScoped<IAlmaDeMaltaUnitOfWork>(s =>
        {
            var dbContext = s.GetRequiredService<IDbContext>();
            return new AlmaDeMaltaUnitOfWork(dbContext);
        });

        return services;
    }
}
