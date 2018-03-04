using System;
using System.Collections.Generic;
using System.Text;
using TDList.Data;

namespace TDList.Models
{
    public class TodolistModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}
