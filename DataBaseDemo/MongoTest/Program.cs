using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MongoTest
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //1.连接数据库
            // 使用连接字符串连接
            var client = new MongoClient("mongodb://192.168.130.133:27017");
            // 制定多个地址和端口，让程序自动选择一个进行连接。
            //var client = new MongoClient("mongodb://localhost:27017,localhost:27018,localhost:27019");

            //2.获取数据库
            var database = client.GetDatabase("test");

            //3.获取数据集collection
            var collection = database.GetCollection<BsonDocument>("bar");

            //4.插入数据
            var document = new BsonDocument
            {
                { "name", "MongoDB" },
                { "type", "Database" },
                { "count", 1 },
                { "info", new BsonDocument
                    {
                        { "x", 203 },
                        { "y", 102 }
                    }}
            };
            //collection.InsertOne(document);//InsertOneAsync异步插入

            //5.插入多条数据
            //var documents = Enumerable.Range(0, 100).Select(i => new BsonDocument("counter", i));
            //InsertMany(同步插入：)
            //collection.InsertMany(documents);
            //InsertManyAsync（异步插入：）
            //await collection.InsertManyAsync(documents)

            //6.查询插入文件个数
            //同步获取
            var count = collection.CountDocuments(new BsonDocument()); //产生一个空BsonDocument的过滤器，指对该类型的文档进行计数。
            //异步获取
            var count2 = await collection.CountDocumentsAsync(new BsonDocument());//产生一个空BsonDocument的过滤器，指对该类型的文档进行计数。

            //7.查询数据 分三种进行叙述，第一种，获取第一条数据，第二种，获取所有数据，第三种，获取指定条件下的数据
            //7.1查询集合中的第一条数据 查询集合中的第一条数据，需要用到的是FistOrDefault方法或者FistOrDefaultAsync方法，当有数据时，返回数据的第一条或者默认的那条，当没有数据时，返回null
            var documentSelect = collection.Find(new BsonDocument()).FirstOrDefault();//或者 FirstOrDefaultAsync

            //7.2查询数据集中的所有数据
            //var documentSelectAll = collection.Find(new BsonDocument()).ToList();//或者ToListAsync
            //获取到了数据后，我们可以使用foreach的方法遍历得到每一个数据的值。 如果返回的数据预期很大，建议采用以下异步的迭代的方法处理。
            //await collection.Find(new BsonDocument()).ForEachAsync(d => Console.WriteLine(d));

            //7.3使用过滤器筛选单个数据
            //创建筛选器
            var filterBuilder = Builders<BsonDocument>.Filter;
            var filter = filterBuilder.Eq("count", 2);//查询count列为2的
            //var filter = filterBuilder.Gt("count", 0);//查询count列大于0的
            //通过同步或者异步方法来查找符合该条件的数据
            var document7_3 = collection.Find(filter).ToList();

            //查询0<count<2,可以设计这样子的筛选器
            //var filterBuilder = Builders<BsonDocument>.Filter;
            //var filter = filterBuilder.Gt("i", 50) & filterBuilder.Lte("i", 100);




            Console.WriteLine("Hello World!");
        }
    }
}
