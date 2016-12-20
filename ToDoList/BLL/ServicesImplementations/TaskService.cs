using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Configurations;
using BLL.Entities;
using BLL.Services;
using DAL.DataTransferObject;
using DAL.Repository;

namespace BLL.ServicesImplementations
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork uow;
        private readonly ITaskRepository taskRepository;

        public TaskService(IUnitOfWork uow, ITaskRepository repository)
        {
            this.uow = uow;
            taskRepository = repository;
        }

        public void Create(TaskEntity test)
        {
            DalTask testToCreate = MapperBusinessConfiguration.MapperInstance.Map<TaskEntity, DalTask>(test);
            taskRepository.Create(testToCreate);
            uow.Commit();
        }

        public void Delete(int id)
        {
            taskRepository.Delete(id);
            uow.Commit();
        }

        public void Update(TaskEntity task)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return MapperBusinessConfiguration.MapperInstance.
                Map<IEnumerable<DalTask>, IEnumerable<TaskEntity>>(taskRepository.GetAll()); ;
        }

        public TaskEntity Get(int id)
        {
            return MapperBusinessConfiguration.MapperInstance.Map<DalTask, TaskEntity>(taskRepository.Get(id));
        }
    }
}
