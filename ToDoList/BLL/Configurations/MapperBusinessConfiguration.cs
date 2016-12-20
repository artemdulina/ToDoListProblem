using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Entities;
using DAL.DataTransferObject;

namespace BLL.Configurations
{
    public class MapperBusinessConfiguration
    {
        public static IMapper MapperInstance { get; private set; }

        static MapperBusinessConfiguration()
        {
            Configure();
        }

        private static void Configure()
        {
            MapperInstance = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskEntity, DalTask>().ReverseMap();
            }).CreateMapper();
        }
    }
}
