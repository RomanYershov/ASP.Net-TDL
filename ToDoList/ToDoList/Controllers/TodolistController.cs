using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TDList.Abstractions;
using TDList.Models;

namespace ToDoList.Controllers
{
    [Produces("application/json")]
    [Route("api/Todolist")]
    [Authorize]
    public class TodolistController : Controller
    {
        private readonly ITodolist _ITodolist;

        public TodolistController(ITodolist todolist)
        {
            _ITodolist = todolist;
        }

        // GET: api/Todolist
        [HttpGet]
        public IEnumerable<TodolistModel> Get()
        {           
            return _ITodolist.GetTodolist(User.Identity.Name);
        }


        // GET: api/Todolist/5
        [HttpGet("{id}", Name = "Get")]
        public TodolistModel Get(int id)
        {
            return _ITodolist.GetTodolistById(id);
        }
        
        // POST: api/Todolist
        [HttpPost]
        public TodolistModel Post([FromBody] TodolistModel todolist)
        {
          return    _ITodolist.AddTodo(todolist, User.Identity.Name);
        }
        
        // PUT: api/Todolist/5
        [Route("/api/edit/{id}")]
        public TodolistModel Edit(int id, [FromBody] TodolistModel todolist)
        {        
            return _ITodolist.Edit(id, todolist); 
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpGet]
        [Route("/api/delete/{id}")]
        public void Delete(int id)
        {
            _ITodolist.Delete(id);
        }

        [HttpGet]
        [Route("/api/toggle/{id}")]
        public void Toggle(int id)
        {
            _ITodolist.Done(id);
        }
    }
}
