using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDb.Model
{
    public class Chat
    {
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public Chat(string from, string to, string description)
        {
            From = from;
            To = to;
            Description = description;
            Date = DateTime.Now.ToShortDateString();
        }

        public void Modificar(string descripcion)
        {
            Description = descripcion;
        }

    }
}
