using EFCoreInMemoryDemo.Model.DataContext;
using EFCoreInMemoryDemo.Model.Entities;
using EFCoreInMemoryDemo.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestEFCoreMemDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_UserIdNot0()
        {
            var newTask = new Task
            {
                UserID = 10,
                Name = "Unit Test",
                Description="Rohan test"
            };

            //var sut = CreateSUT();

            ////Act
            //sut.AddTask(newTask);

            ////Assert
            //Assert.IsTrue(newTask.UserID != 0);
        }

        //private TaskRepository CreateSUT()
        //{
        //    var options = new DbContextOptionsBuilder<TasksDBContext>().UseInMemoryDatabase(databaseName: "ToDoTask").Options;


        //    var dbOptions = new DbContextOptionsBuilder<TasksDBContext>().Options()
        //       .UseInMemoryDatabase(databaseName: "ToDoDb")
        //       .Options;

        //    var context = new TasksDBContext(dbOptions);

        //    return new ToDoListRepository(context);
        //}

    }
}
