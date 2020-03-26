using Common.Mongo;
using System;

namespace MongoModel
{
    public class StudentModel:BaseModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
