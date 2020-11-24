using AutoMapper;

namespace MyAccount.MappingDTO
{
    public class RegisterMappingDTO
    {
        public MapperConfiguration GetMapperConfiguration()
        {
            var mappingConfig = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile(new UserMappingDTO());
            });

#if DEBUG
            mappingConfig.AssertConfigurationIsValid();
#endif

            return mappingConfig;
        }
    }
}