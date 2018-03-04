using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDList.Data
{
   public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
           

            builder.Entity<User>()
                .HasMany(u => u.ToDoLists)
                .WithOne();

            builder.Entity<ToDoList>()
               .HasMany(t => t.Tags)
               .WithOne();



            builder.Entity<User>()
                 .HasIndex(u => u.Login)
                 .IsUnique();
        }
    }
}
