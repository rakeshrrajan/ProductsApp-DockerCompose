using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductsApp.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private const string CONNECTION = "ProductConnString";
        private const string DATABASE_SECTION_NAME = "MongoConfig";
        protected MongoClient Client;
        protected IMongoDatabase Database;
        

        public BaseRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(CONNECTION);
            var mongoSettings = configuration.GetSection(DATABASE_SECTION_NAME)
                                             .GetChildren()
                                             .ToDictionary(x => x.Key, x => x.Value);
            var databaseName = mongoSettings["Database"];
            Client = new MongoClient(connectionString);
            Database = Client.GetDatabase(databaseName);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
