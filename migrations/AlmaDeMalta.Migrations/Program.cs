

using AlmaDeMalta.Common.DatabaseConnection;
using AlmaDeMalta.Migrations.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var servicesCollection = new ServiceCollection();

servicesCollection.UseMongoConfig(config);
var provider = servicesCollection.BuildServiceProvider();
var migrations = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsAssignableTo(typeof(IMigration)) && !t.IsAbstract);
foreach (var migration in migrations)
{
    var migrationInstance = ActivatorUtilities.CreateInstance(provider, migration);
    if (migrationInstance is IMigration migrationToExecute)
    {
        await migrationToExecute.Execute();
    }
}
Console.WriteLine("Migrations executed successfully.");



