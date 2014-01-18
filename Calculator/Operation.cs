using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace CalculatorDB
{
    // класс операции
    public class Operation
    {
        public ObjectId Id { get; set; }
        public string Content { get; set; }
        public DateTime Created_at { get; set; }
    }
}