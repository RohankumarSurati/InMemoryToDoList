using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EFCoreInMemoryDemo.Model.DataContext
{
    public class TasksDBContext : DbContext
    {
        public TasksDBContext(DbContextOptions<TasksDBContext> options)
            : base(options)
        {
        }

        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Entities.User> Users { get; set; }
    }
}
