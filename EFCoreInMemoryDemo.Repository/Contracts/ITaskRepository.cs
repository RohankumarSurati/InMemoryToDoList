using EFCoreInMemoryDemo.Model.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = EFCoreInMemoryDemo.Model.Entities.Task;

namespace EFCoreInMemoryDemo.Repository.Contracts
{
    public interface ITaskRepository
    {
        Task<int> ValidateUser(string UserName, string Password);
        Task<IQueryable<Task>> GetTaskByUserId(int Userid);
        Task<Task> GetTaskById(int id);
        System.Threading.Tasks.Task AddTask(Task task);
        System.Threading.Tasks.Task UpdateTask(Task task);
        Task<bool> TaskExists(int taskId);
        System.Threading.Tasks.Task DeleteTask(Task task);
    }
}
