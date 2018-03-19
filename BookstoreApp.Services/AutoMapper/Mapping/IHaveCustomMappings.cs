using AutoMapper;

namespace BookstoreApp.Services.AutoMapper.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}