using EFCoreInMemoryDemo.Repository.Contracts;
using EFCoreInMemoryDemo.Model.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task = EFCoreInMemoryDemo.Model.Entities.Task;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EFCoreInMemoryDemo.Model.Entities;

namespace EFCoreInMemoryDemo.Repository.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksDBContext _context;

        public TaskRepository(TasksDBContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Task>> GetTaskByUserId(int Userid)
        {
            return _context.Tasks.Where(m=>m.UserID == Userid);
        }

        public async Task<int> ValidateUser(string UserName, string Password)
        {
            if (_context.Users.Where(t => t.UserName == UserName && t.Password == Password).Count() > 0)
            {
                return _context.Users.Where(t => t.UserName == UserName && t.Password == Password).FirstOrDefaultAsync().Result.UserID;
            }
            return 0;
        }

        public Task<Task> GetTaskById(int id)
        {            
            return _context.Tasks          
            .SingleOrDefaultAsync(m => m.ID == id);
        }

        public System.Threading.Tasks.Task AddTask(Task task)
        {
            var newID = _context.Tasks.Select(x => x.ID).Max() + 1;
            task.ID = newID;           

            _context.Tasks.Add(task);
            return _context.SaveChangesAsync();
        }

        public System.Threading.Tasks.Task UpdateTask(Task task)
        {
            task.UpdateOn = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
            _context.Update(task);
            return _context.SaveChangesAsync();
        }

        public Task<bool> TaskExists(int taskId)
        {
            return _context.Tasks.AnyAsync(x => x.ID == taskId);
        }

        public System.Threading.Tasks.Task DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            return _context.SaveChangesAsync();
        }
    }
}
