using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDb.Dto;
using MongoDb.Model;
using MongoDb.Services;
using MongoDb.ViewModel;

namespace MongoDb.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatsController(IChatService chatService)
        {
            _chatService = chatService;
        }

        //GET: api/Chats
        [HttpGet]
        public IEnumerable<ChatViewModel> Get(int skip = 0, int limit = 50)
        {
            return _chatService.GetAll(skip, limit);
        }

        //// GET api/Chats/user/5
        [HttpGet("user/{name}")]
        public IEnumerable<ChatViewModel> Get(string name)
        {
            return _chatService.GetAllByName(name);
        }

        // POST api/Chats
        [HttpPost]
        public IActionResult Post(ChatDTO model)
        {
            try
            {
                _chatService.Save(model);
                return Ok("Creado correctamente");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //// PUT api/chats
        [HttpPut]
        public IActionResult Put(ChatUpdateDTO model)
        {
            try
            {
                _chatService.Update(model);
                return Ok("Actualizado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //// DELETE api/chats/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _chatService.Delete(id);
                return Ok("Borrado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}