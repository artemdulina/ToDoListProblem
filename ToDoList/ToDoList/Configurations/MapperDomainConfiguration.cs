using System.Collections.Generic;
using AutoMapper;
using BLL.Entities;
using ToDoList.Models;

namespace ToDoList.Configurations
{
    public static class MapperDomainConfiguration
    {
        public static IMapper MapperInstance { get; private set; }

        static MapperDomainConfiguration()
        {
            Configure();
        }

        public static void Configure()
        {
            MapperInstance = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskEntity, ToDoItemViewModel>()
                .ForMember(dest => dest.ToDoId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Content));

                cfg.CreateMap<ToDoItemViewModel, TaskEntity>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ToDoId));

                cfg.CreateMap<IEnumerable<TaskEntity>, IEnumerable<ToDoItemViewModel>>().ReverseMap();
            }).CreateMapper();
        }
    }
}
