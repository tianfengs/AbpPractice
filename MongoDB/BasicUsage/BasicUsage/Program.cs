using MongoDB.Bson;
using MongoDB.Driver;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicUsage
{
    class Program
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _db;
        static void Main(string[] args)
        {
            #region Connect to Mongodb 
            _client = new MongoClient();
            _db = _client.GetDatabase("test");
            #endregion

            InsertToMongoDb();
            QueryData(_db).Wait();

            ReadLine();
        }

        private static void InsertToMongoDb()
        {
            #region Insert Data[InsertOneAsync,InsertManyAsync]
            var document = new BsonDocument
            {
                { "address" , new BsonDocument
                    {
                        { "street", "2 Avenue" },
                        { "zipcode", "10075" },
                        { "building", "1480" },
                        { "coord", new BsonArray { 73.9557413, 40.7720266 } }
                    }
                },
                { "borough", "Manhattan" },
                { "cuisine", "Italian" },
                { "grades", new BsonArray
                    {
                        new BsonDocument
                        {
                            { "date", new DateTime(2014, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "A" },
                            { "score", 11 }
                        },
                        new BsonDocument
                        {
                            { "date", new DateTime(2014, 1, 6, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "B" },
                            { "score", 17 }
                        }
                    }
                },
                { "name", "Vella" },
                { "restaurant_id", "41704620" }
            };

            var collection = _db.GetCollection<BsonDocument>("restaurants");
            collection.InsertOneAsync(document).Wait();
            #endregion
        }

        /// <summary>
        /// Find or Query Data
        /// </summary>
        private async static Task QueryData(IMongoDatabase db)
        {
            //Query for All Documents in a Collection
            var collection = db.GetCollection<BsonDocument>("restaurants");
            var filter = new BsonDocument();
            var count = 0;
            using (var cursor =await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        // process document
                        count++;
                    }
                }
            }

            //var filter = Builders<BsonDocument>.Filter.Eq(< field >, < value >);

            var collection2 = db.GetCollection<BsonDocument>("restaurants");
            var filter2 = Builders<BsonDocument>.Filter.Eq("borough", "Manhattan");
            var result = await collection.Find(filter).ToListAsync();

            //Query by a Field in an Embedded Document
            var collection3 = db.GetCollection<BsonDocument>("restaurants");
            var filter3 = Builders<BsonDocument>.Filter.Eq("address.zipcode", "10075");
            var result3 = await collection.Find(filter).ToListAsync();
        }
    }
}
