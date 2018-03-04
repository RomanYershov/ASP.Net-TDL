using System;
using System.Collections.Generic;
using System.Text;

namespace TDList.Data
{
    public class ToDoList
    {
        public ToDoList()
        {
            Date = DateTime.Today.Date;
            Tags = new List<Tag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
        public virtual List<Tag> Tags { get; set; }

    }
}
