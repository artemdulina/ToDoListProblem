using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ToDoList.Models
{
    public class QueueTasks : IQueueTask
    {
        private SemaphoreSlim semaphore;

        public QueueTasks()
        {
            semaphore = new SemaphoreSlim(1);
        }

        /*public async Task Enqueue(Func<ToDoItemViewModel,Task> taskGenerator)
        {
            await semaphore.WaitAsync();
            try
            {
                await taskGenerator();
            }
            finally
            {
                semaphore.Release();
            }
        }*/

        public async Task<object> Enqueue(Func<ToDoItemViewModel, Task<object>> taskGenerator, ToDoItemViewModel item)
        {
            await semaphore.WaitAsync();
            try
            {
                return await taskGenerator(item);
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}