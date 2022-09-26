using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreInMemoryDemo.Service.Contracts;
//using EFCoreInMemoryDemo.Web.DataContext;
using EFCoreInMemoryDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Task = EFCoreInMemoryDemo.Model.Entities.Task;

namespace EFCoreInMemoryDemo.Web.Controllers
{
    public class TasksController : Controller
    {

        private readonly ITaskService _taskService;


        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
            checkLogin();
        }


        private int UserSession = 0;
        private string username = "test", Password = "pwd123";

        //private TasksDBContext _context;
        //public TasksController(TasksDBContext context)
        //{
        //    _context = context;
        //    checkLogin();
        //}

        public void checkLogin()
        {
            UserSession = _taskService.ValidateUser(username, Password).Result;
        }


        [HttpGet]
        public IActionResult Index()
        {            
            if (UserSession == 0)
            {
                ViewData["Error"] = "Username/Password is wrong. Change value at code level.";
            }
            var tasks = _taskService.GetTaskByUserId(UserSession).Result.ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Task task)
        {
            //Determine the next ID            
            task.UserID = UserSession;
            _taskService.AddTask(task);            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _taskService.DeleteTask(id);            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _taskService.GetTaskById(id).Result;
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {            
            _taskService.UpdateTask(task);            
            return RedirectToAction("Index");
        }
    }
}