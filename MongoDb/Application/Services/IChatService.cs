using MongoDb.Dto;
using MongoDb.ViewModel;
using System.Collections.Generic;

namespace MongoDb.Services
{
    public interface IChatService
    {
        void Save(ChatDTO obj);

        void Update(ChatUpdateDTO obj);

        void Delete(string id);

        IEnumerable<ChatViewModel> GetAll(int skip = 0, int limit = 50);

        IEnumerable<ChatViewModel> GetAllByName(string name, int skip = 0, int limit = 50);

    }
}
