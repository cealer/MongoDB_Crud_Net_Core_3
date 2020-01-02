using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ChatAggregate
{
    public interface IChatRepository
    {
        void Save(Chat obj);

        void Update(Chat obj);

        void Delete(string id);

        IEnumerable<Chat> GetAll(int skip = 0, int limit = 50);

        Chat GetById(string id);
    }
}
