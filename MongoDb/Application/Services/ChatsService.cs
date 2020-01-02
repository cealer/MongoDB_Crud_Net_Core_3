using System;
using System.Collections.Generic;
using System.Linq;
using MongoDb.Dto;
using MongoDb.Infrastructure.Repositories;
using MongoDb.Model;
using MongoDb.ViewModel;

namespace MongoDb.Services
{
    public class ChatsService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        public ChatsService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
        public void Delete(string id)
        {
            _chatRepository.Delete(id);
        }

        public IEnumerable<ChatViewModel> GetAll(int skip = 0, int limit = 50)
        {
            return _chatRepository.GetAll(skip, limit)
                 .Select(x => new ChatViewModel
                 {
                     Description = x.Description,
                     To = x.To
                 });
        }

        public IEnumerable<ChatViewModel> GetAllByName(string name, int skip = 0, int limit = 50)
        {
            return _chatRepository.GetAllByName(name, skip, limit)
                 .Select(x => new ChatViewModel
                 {
                     Description = x.Description,
                     To = x.Description
                 });
        }

        public void Save(ChatDTO obj)
        {
            var chat = new Chat(obj.From, obj.To, obj.Description);
            _chatRepository.Save(chat);
        }

        public void Update(ChatUpdateDTO obj)
        {
            var chat = _chatRepository.GetById(obj.Id);
            chat.Modificar(obj.Description);
            _chatRepository.UpdateAsync(chat);
        }
    }
}
