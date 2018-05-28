using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoToDoApp.Server.Logic;
using DemoToDoApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoToDoApp.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/ToDoes")]
    public class ToDoesController : Controller
    {
        private IToDoRepository _currentToDoRepository;

        public ToDoesController(IToDoRepository toDoRepository)
        {
            _currentToDoRepository = toDoRepository;
        }

        // GET: api/ToDoes
        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            return _currentToDoRepository.Data;
        }

        // GET: api/ToDoes/5
        [HttpGet("{id}", Name = "Get")]
        public ToDo Get(int id)
        {
            return _currentToDoRepository.Data.FirstOrDefault(x=>x.ID==id);
        }
        
        // POST: api/ToDoes
        [HttpPost]
        public void Post([FromBody]ToDo value)
        {
            value.ID = _currentToDoRepository.Data.Max(x => x.ID) + 1;
            _currentToDoRepository.Data.Add(value);
        }
        
        // PUT: api/ToDoes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ToDo value)
        {
            var myToDo = _currentToDoRepository.Data.FirstOrDefault(x => x.ID == id); 
            if( myToDo != null)
            {
                myToDo.Title = value.Title;
                myToDo.Date = value.Date;
                myToDo.Description = value.Description;
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var myToDo = _currentToDoRepository.Data.FirstOrDefault(x => x.ID == id);
            if (myToDo != null)
                _currentToDoRepository.Data.Remove(myToDo);
        }
    }
}
