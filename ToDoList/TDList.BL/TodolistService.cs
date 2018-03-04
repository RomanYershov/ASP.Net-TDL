using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TDList.Abstractions;
using TDList.BL.Converters;
using TDList.Data;
using TDList.Models;

namespace TDList.BL
{
    public class TodolistService : ITodolist
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IModelEntityConverter<TodolistModel, ToDoList> TDconverter;

        public TodolistService(ApplicationContext applicationContext,
            IModelEntityConverter<TodolistModel, ToDoList> TDconverter)
        {
            _applicationContext = applicationContext;
            this.TDconverter = TDconverter;
        }
        public TodolistModel AddTodo(TodolistModel newTodolist, string login)
        {
            var todolist = TDconverter.GetEntityByModel(newTodolist);
            _applicationContext.Users.Include(t => t.ToDoLists)
                .FirstOrDefault(u => u.Login == login).ToDoLists.Add(todolist);

            _applicationContext.SaveChanges();
            return newTodolist;
        }

        public void Delete(int id)
        {
            var todo = _applicationContext.ToDoLists.Find(id);
            if (todo == null) return;
            _applicationContext.ToDoLists.Remove(todo);
            _applicationContext.SaveChanges();
        }

        public void Done(int id)
        {
            var todo = _applicationContext.ToDoLists.Find(id);
            if (todo == null) return;
            todo.IsDone = !todo.IsDone;
            _applicationContext.SaveChanges();
        }

        public TodolistModel Edit(int id, TodolistModel todolist)
        {
            var updatedTodo = _applicationContext.ToDoLists.Include(x => x.Tags).FirstOrDefault(t => t.Id == id);
            if (updatedTodo == null) return null;

            updatedTodo.Description = string.IsNullOrEmpty(todolist.Description)
                ? updatedTodo.Description : todolist.Description;
            updatedTodo.Name = string.IsNullOrEmpty(todolist.Name)
                ? updatedTodo.Name : todolist.Name;
            updatedTodo.Date = string.IsNullOrEmpty(todolist.Date.ToShortDateString())
                ? updatedTodo.Date : todolist.Date;
            updatedTodo.Tags = todolist.Tags == null
                ? updatedTodo.Tags : todolist.Tags;

            _applicationContext.SaveChanges();
            return todolist;
        }

        public IEnumerable<TodolistModel> GetTodolist(string login)
        {
            var todolist = _applicationContext.Users.Include(t => t.ToDoLists).ThenInclude(t => t.Tags)
                .FirstOrDefault(u => u.Login == login)
                .ToDoLists.Select(x => TDconverter.GetModelByEntity(x))
                .OrderBy(d => d.Date).OrderBy(x => x.IsDone);
            return todolist;
        }

        public TodolistModel GetTodolistById(int id)
        {
            var todo = _applicationContext.ToDoLists.Include(x => x.Tags).FirstOrDefault(x => x.Id == id);
            if (todo == null) return null;
            return TDconverter.GetModelByEntity(todo);
        }
    }
}
