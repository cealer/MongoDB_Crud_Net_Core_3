using MongoDb.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb.Infrastructure.Repositories
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

        public IEnumerable<Chat> GetAllByName(string name, int skip = 0, int limit = 50)
        {
            return _mongoContext.Chat.Find(x => x.From == name).Skip(skip).Limit(limit)
                .ToList();
        }

        public Chat GetById(string id)
        {
            return _mongoContext.Chat
                .Find(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public async Task<bool> Save(Chat obj)
        {
            try
            {
                await _mongoContext.Chat.InsertOneAsync(obj);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Chat obj)
        {
            var filter = Builders<Chat>.Filter.Eq(x => x.Id, obj.Id);
            var update = Builders<Chat>.Update.
                Set(x => x.Description, obj.Description)
               .Set(x => x.Date, DateTime.Now.ToShortDateString());

            var result = await _mongoContext.Chat.
                UpdateOneAsync(filter, update);

            if (result.ModifiedCount > 0)
            {
                return true;
            }
            return false;
        }
    }
}
