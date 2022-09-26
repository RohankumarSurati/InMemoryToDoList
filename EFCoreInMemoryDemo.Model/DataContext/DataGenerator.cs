using EFCoreInMemoryDemo.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreInMemoryDemo.Model.DataContext
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TasksDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<TasksDBContext>>()))
            {
                // Look for any task already in database.
                if (context.Tasks.Any())
                {
                    return;   // Database has been seeded
                }

                context.Tasks.AddRange(
                    new Task
                    {
                        ID = 1,
                        UserID = 1,
                        Name = "Task 1",
                        Description = "Call Rohan",
                        UpdateDescription = "",
                        UpdateOn = "",
                        Done = false
                    },
                    new Task
                    {
                        ID = 2,
                        UserID = 2,
                        Name = "Sorry!",
                        Description = "Hasbro",
                        UpdateDescription = "",
                        UpdateOn = "",
                        Done = true
                    },
                    new Task
                    {
                        ID = 3,
                        UserID = 1,
                        Name = "Task 2",
                        Description = "Call Surati",
                        UpdateDescription = "Update Desc",
                        UpdateOn = "26-Sep-2022 15:28:08",
                        Done = true
                    });


                context.Users.AddRange(
                    new User
                    {
                        UserID = 1,
                        UserName = "test",
                        Password = "pwd123"
                    },
                    new User
                    {
                        UserID = 2,
                        UserName = "rohan",
                        Password = "rohan"
                    });

                context.SaveChanges();
            }
        }
    }
}
