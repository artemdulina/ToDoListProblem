using System.Data.Entity;
using DAL.Repository;
using DAL.RepositoryImplementations;
using Ninject.Modules;
using ORM;

namespace DAL.DependencyModules
{
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ToDoContext>();
            Bind<ITaskRepository>().To<TaskRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
