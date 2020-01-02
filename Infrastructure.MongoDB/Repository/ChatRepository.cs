using Domain;
using Domain.ChatAggregate;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MongoDB.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly MongoContext _mongoContext;

        public ChatRepository()
        {
            _mongoContext = new MongoContext();

        }

        public void Delete(string id)
        {
            _mongoContext.Chat.DeleteOne(x => x.Id == id);
        }

        public IEnumerable<Chat> GetAll(int skip = 0, int limit = 50)
        {
            return _mongoContext.Chat.Find(x => true).Skip(skip).Limit(limit).ToList();
        }

        public Chat GetById(string id)
        {
            return _mongoContext.Chat.Find(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public void Save(Chat obj)
        {
            _mongoContext.Chat.InsertOne(obj);
        }

        public void Update(Chat obj)
        {
            _mongoContext.Chat.ReplaceOne(x => x.Id.Equals(obj.Id), obj);
        }
    }
}
