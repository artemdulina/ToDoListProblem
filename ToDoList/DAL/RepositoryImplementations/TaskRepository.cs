using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Configurations;
using DAL.DataTransferObject;
using DAL.Repository;
using EntityFramework.Extensions;
using Task = ORM.Task;

namespace DAL.RepositoryImplementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbContext context;

        public TaskRepository(DbContext context)
        {
            this.context = context;
            MapperDomainConfiguration.Configure();
        }

        public IEnumerable<DalTask> GetAll()
        {
            IEnumerable<DalTask> tasks = context.Set<Task>().ToList().Select(form =>
                MapperDomainConfiguration.MapperInstance.Map<Task, DalTask>(form)
                );

            return tasks;
        }

        public DalTask Get(int id)
        {
            Task found = context.Set<Task>().FirstOrDefault(form => form.Id == id);

            return found == null ? null : MapperDomainConfiguration.MapperInstance.Map<Task, DalTask>(found);
        }

        public void Create(DalTask entity)
        {
            Task task = MapperDomainConfiguration.MapperInstance.Map<DalTask, Task>(entity);
            context.Set<Task>().Add(task);
        }

        public void Delete(int id)
        {
            Task task = new Task { Id = id };
            context.Set<Task>().Attach(task);
            context.Set<Task>().Remove(task);
        }

        public void Update(DalTask entity)
        {
            Task toDoForm = MapperDomainConfiguration.MapperInstance.Map<DalTask, Task>(entity);

            context.Set<Task>()
                .Where(form => form.Id == toDoForm.Id)
                .Update(updated => toDoForm);
        }
    }
}
