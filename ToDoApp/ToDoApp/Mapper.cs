using AutoMapper;

namespace ToDoApp
{
    public class Mapper
    {
        public IMapper Build() =>
            new MapperConfiguration(
                expr =>
                {
                }).CreateMapper();
    }
}
