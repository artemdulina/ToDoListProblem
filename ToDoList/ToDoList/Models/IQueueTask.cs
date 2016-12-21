using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public interface IQueueTask
    {
        Task Enqueue(Func<ToDoItemViewModel,Task<object>> taskGenerator);
    }
}
