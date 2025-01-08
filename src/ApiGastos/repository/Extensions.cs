using ApiGastos.Entities;
using ApiGastos.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace ApiGastos.Repository;

public static class Extension
{
    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
        // ServiceSettings serviceSettings;
        // Configurar la serealizaci�n de id y de la fecha.
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

        // Add mongodb client
        services.AddSingleton(serviceProvide =>
        {
            var configuration = serviceProvide.GetService<IConfiguration>()!;

            // Mongo db settings
            var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>()!;
            var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>()!;
            Console.WriteLine(mongoDbSettings.ConnectionString);
            var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
            return mongoClient.GetDatabase(serviceSettings.ServiceName);
        });

        return services;
    }

    public static IServiceCollection AddMongoRespository<T>(this IServiceCollection services, string collectionName)
        where T : IEntity
    {
        services.AddSingleton<IRepository<T>>(ServiceProvider =>
        {
            var database = ServiceProvider.GetService<IMongoDatabase>();
            return new MongoRepository<T>(database, collectionName);
        });
        return services;
    }
}