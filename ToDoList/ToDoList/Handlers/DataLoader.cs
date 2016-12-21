using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using BLL.Entities;
using BLL.Services;
using BLL.ServicesImplementations;
using Ninject;
using ToDoList.Configurations;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Handlers
{
    public class DataLoader : DelegatingHandler
    {
        private List<int> userIds = new List<int>();
        private readonly UserService userService;
        private readonly ToDoService toDoService;

        public DataLoader(HttpConfiguration httpConfiguration, UserService userService, ToDoService toDoService)
        {
            InnerHandler = new HttpControllerDispatcher(httpConfiguration);
            this.userService = userService;
            this.toDoService = toDoService;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            ITaskService taskService = (ITaskService)request.GetDependencyScope().GetService(typeof(ITaskService));
            int userId = userService.GetOrCreateUser();
            if (!userIds.Contains(userId))
            { 
                IList<ToDoItemViewModel> tasks = toDoService.GetItems(userId);
                foreach (ToDoItemViewModel task in tasks)
                {
                    TaskEntity taskEntity = MapperDomainConfiguration.MapperInstance.Map<ToDoItemViewModel, TaskEntity>(task);
                    taskService.Create(taskEntity);
                }

                userIds.Add(userId);
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}