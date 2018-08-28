namespace ThreeDPrinting.Tests.Mocks
{
    using AutoMapper;
    using System.Text;
    using ThreeDPrinting.Web.Mapping;

    public static class MockAutoMapper
    {
        public static IMapper GetMapper()
        {
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
            return Mapper.Instance;
        }
    }
}
