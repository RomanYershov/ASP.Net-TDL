using System;
using System.Collections.Generic;
using System.Text;
using TDList.Models;

namespace TDList.Abstractions
{
    public interface ITodolist
    {
        IEnumerable<TodolistModel> GetTodolist(string login);
        TodolistModel GetTodolistById(int id);
        TodolistModel AddTodo(TodolistModel todolist, string login);
        TodolistModel Edit(int id, TodolistModel todolist);
        void Delete(int id);
        void Done(int id);

    }
}
