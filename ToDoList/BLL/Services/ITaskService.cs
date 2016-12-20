using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Services
{
    public interface ITaskService
    {
        TaskEntity Get(int id);
        IEnumerable<TaskEntity> GetAll();
        void Create(TaskEntity task);
        void Delete(int id);
        void Update(TaskEntity task);
    }
}
