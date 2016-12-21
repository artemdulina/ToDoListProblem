﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.Entities;
using BLL.Services;
using ToDoList.Configurations;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    /// <summary>
    /// Processes todo requests.
    /// </summary>
    public class ToDosController : ApiController
    {
        private readonly ToDoService todoService = new ToDoService();
        private readonly UserService userService = new UserService();

        private ITaskService taskService;
        private IQueueTask queueTask;

        public ToDosController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        /// <summary>
        /// Returns all todo-items for the current user.
        /// </summary>
        /// <returns>The list of todo-items.</returns>
        public IList<ToDoItemViewModel> Get()
        {
            var userId = userService.GetOrCreateUser();
            IEnumerable<TaskEntity> tasks = taskService.GetByUser(userId);

            IList<ToDoItemViewModel> resultTasks = tasks.Select(task => MapperDomainConfiguration.MapperInstance.
                Map<TaskEntity, ToDoItemViewModel>(task)).ToList();

            return resultTasks;
        }

        /// <summary>
        /// Updates the existing todo-item.
        /// </summary>
        /// <param name="todo">The todo-item to update.</param>
        public void Put(ToDoItemViewModel todo)
        {
            todo.UserId = userService.GetOrCreateUser();
            todoService.UpdateItem(todo);
        }

        /// <summary>
        /// Deletes the specified todo-item.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        public void Delete(int id)
        {
            todoService.DeleteItem(id);
        }

        /// <summary>
        /// Creates a new todo-item.
        /// </summary>
        /// <param name="todo">The todo-item to create.</param>
        public void Post(ToDoItemViewModel todo)
        {
            todo.UserId = userService.GetOrCreateUser();

            TaskEntity toAdd = MapperDomainConfiguration.MapperInstance.Map<ToDoItemViewModel, TaskEntity>(todo);

            //taskService.Create(toAdd);
            
            //todoService.CreateItem(todo);
        }
    }
}
