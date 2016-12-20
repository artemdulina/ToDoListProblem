using AutoMapper;
using DAL.DataTransferObject;

namespace DAL.Configurations
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
                cfg.CreateMap<ORM.Task, DalTask>().ReverseMap();
            }).CreateMapper();
        }
    }
}
