using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;
using BLL.ServicesImplementations;
using DAL.DependencyModules;
using Ninject;
using Ninject.Modules;

namespace BLL.DependencyModules
{
    public class BllModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Load(new DalModule());
            Bind<ITaskService>().To<TaskService>();
        }
    }
}
