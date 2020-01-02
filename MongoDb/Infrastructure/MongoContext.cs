using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.IO;
using Domain;
using MongoDb.Model;

namespace MongoDb.Infrastructure
{
    public class MongoContext
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase database;
        public IConfigurationRoot Configuration { get; }

        public MongoContext()
        {
            Configuration = new ConfigurationBuilder().
                
                SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            mongoClient = new MongoClient(Configuration["MongoDB:ConnectionString"]);
            database = mongoClient.GetDatabase(Configuration["MongoDB:Database"]);
        }

        public IMongoCollection<Chat> Chat
        {
            get
            {
                return database.GetCollection<Chat>(nameof(Chat));
            }
        }
    }
}
