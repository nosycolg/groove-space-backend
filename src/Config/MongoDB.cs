using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDB.Entities;

namespace Configs;

public static class MongoConfig
{
    public static async Task Init(IConfiguration configuration)
    {
        var pack = new ConventionPack { new EnumRepresentationConvention(BsonType.String) };
        ConventionRegistry.Register("EnumStringConvention", pack, t => true);

        await DB.InitAsync(configuration["DB_NAME"]!,
            MongoClientSettings.FromConnectionString(configuration.GetConnectionString("mongoConnection")!
        ));

        // await DB.MigrateAsync(); // Remova ou comente essa linha se não houver migrações
    }
}
