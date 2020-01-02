using MongoDb.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDb.Infrastructure.Repositories
{
    public interface IChatRepository
    {
        Task<bool> Save(Chat obj);

        Task<bool> UpdateAsync(Chat obj);

        void Delete(string id);

        IEnumerable<Chat> GetAll(int skip = 0, int limit = 50);

        IEnumerable<Chat> GetAllByName(string name,int skip = 0, int limit = 50);

        Chat GetById(string id);
    }
}
