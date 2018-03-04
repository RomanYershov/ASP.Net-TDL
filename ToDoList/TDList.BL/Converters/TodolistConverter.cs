using TDList.Data;
using TDList.Models;


namespace TDList.BL.Converters
{
    public class TodolistConverter : IModelEntityConverter<TodolistModel, ToDoList>
    {
        public ToDoList GetEntityByModel(TodolistModel model)
        {
            return new ToDoList
            {
                Id = model.Id,
                Date = model.Date,
                Name = model.Name,
                Description = model.Description,
                IsDone = model.IsDone,
                Tags = model.Tags
            };
        }

        public TodolistModel GetModelByEntity(ToDoList entity)
        {
            return new TodolistModel
            {
                Id = entity.Id,
                Date = entity.Date,
                Name = entity.Name,
                Description = entity.Description,
                IsDone = entity.IsDone,
                Tags = entity.Tags
            };
        }
    }
}
