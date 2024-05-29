using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.database
{
    public static class Database
    {
        public static void connect()
        {
            string connectionString = "mongodb://localhost:27017";

            var client = new MongoClient(connectionString);

            var database = client.GetDatabase("fingerprint");
            
            var collections = database.ListCollectionNames().ToList();

            // Create collections identity
            if (!collections.Contains("identity"))
            {
                database.CreateCollection("identity");
                Console.WriteLine("Collection identity created");
            }
            else
            {
                Console.WriteLine("Collection 'samples' already exists.");
            }

            if (!collections.Contains("fingerprint"))
            {
                database.CreateCollection("fingerprint");
                Console.WriteLine("Collection fingerprint created");
            } else
            {
                Console.WriteLine("Fingerprint already exist!");
            }

            // Print database names
            Console.WriteLine("Databases:");
            foreach (var db in collections)
            {
                Console.WriteLine(db);
            }
        }

    }
}
