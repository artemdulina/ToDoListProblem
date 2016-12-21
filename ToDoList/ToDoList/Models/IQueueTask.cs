using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public interface IQueueTask
    {
        Task<object> Enqueue(Func<ToDoItemViewModel,Task<object>> taskGenerator, ToDoItemViewModel item);
    }
}
