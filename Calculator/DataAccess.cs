using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CalculatorDB
{
    public class DataAccess
    {   
        // метод для получения коллекции из базы данных
        private MongoCollection<Operation> GetCollection()
        {
            string connectionString =
                "mongodb://user:qwerty@ds053728.mongolab.com:53728/calculator";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var db = server.GetDatabase("calculator");
            var collection = db.GetCollection<Operation>("operation");
            return collection;
        }

        // метод для добавления в коллекцию
        public void Insert(Operation operation)
        {
            var collection = GetCollection();
            collection.Insert(operation);
        }

        // метод для получения из коллекции всех объектов
        public List<Operation> GetOperation()
        {
            var collection = GetCollection();
            return collection.FindAllAs<Operation>().ToList();
        }

        // метод для удаления всех объектов из коллекции
        public void Remove()
        {
            var collection = GetCollection();
            collection.RemoveAll();
        }
    }
}