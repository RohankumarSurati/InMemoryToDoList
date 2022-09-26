using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = EFCoreInMemoryDemo.Model.Entities.Task;

namespace EFCoreInMemoryDemo.Service.Contracts
{
    public interface ITaskService
    {
        Task<int> ValidateUser(string UserName, string Password);
        Task<IQueryable<Task>> GetTaskByUserId(int Userid);

        Task<Task> GetTaskById(int id);
        System.Threading.Tasks.Task AddTask(Task task);
        System.Threading.Tasks.Task UpdateTask(Task task);
        Task<bool> TaskExists(int taskId);
        Task<Task> DeleteTask(int id);
        Task<Task> CompleteTask(int id);
        Task<Task> UndoTask(int id);
    }
}
