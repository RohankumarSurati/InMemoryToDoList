using EFCoreInMemoryDemo.Model.Entities;
using EFCoreInMemoryDemo.Repository.Contracts;
using EFCoreInMemoryDemo.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = EFCoreInMemoryDemo.Model.Entities.Task;


namespace EFCoreInMemoryDemo.Service.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        public Task<int> ValidateUser(string UserName, string Password)
        {
            return _taskRepository.ValidateUser(UserName, Password);
        }

        public Task<IQueryable<Task>> GetTaskByUserId(int Userid)
        {
            return _taskRepository.GetTaskByUserId(Userid);
        }

        public System.Threading.Tasks.Task<Task> GetTaskById(int id)
        {
            return _taskRepository.GetTaskById(id);
        }

        public System.Threading.Tasks.Task AddTask(Task task)
        {
            return _taskRepository.AddTask(task);
        }

        public System.Threading.Tasks.Task UpdateTask(Task task)
        {
            return _taskRepository.UpdateTask(task);
        }

        public Task<bool> TaskExists(int taskId)
        {
            return _taskRepository.TaskExists(taskId);
        }

        public async Task<Task> DeleteTask(int id)
        {
            var task = await GetTaskById(id);

            await _taskRepository.DeleteTask(task);

            return task;
        }

        public async Task<Task> CompleteTask(int id)
        {
            var task = await GetTaskById(id);

            task.Done = true;

            await UpdateTask(task);

            return task;
        }

        public async Task<Task> UndoTask(int id)
        {
            var task = await GetTaskById(id);

            task.Done = false;

            await UpdateTask(task);

            return task;
        }
    }
}