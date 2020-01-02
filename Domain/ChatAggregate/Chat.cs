using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Chat
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public Chat(string from, string to, string description, string date)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
            To = to ?? throw new ArgumentNullException(nameof(to));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Date = date ?? throw new ArgumentNullException(nameof(date));
        }
    }
}
