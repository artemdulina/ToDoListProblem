using System.Collections.Generic;
using DAL.DataTransferObject;

namespace DAL.Repository
{
    public interface ITaskRepository : IRepository<DalTask>
    {
        IEnumerable<DalTask> GetByUser(int id);
    }
}
