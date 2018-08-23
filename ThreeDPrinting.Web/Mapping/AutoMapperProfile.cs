namespace ThreeDPrinting.Web.Mapping
{
    using AutoMapper;
    using ThreeDPrinting.Models;
    using ThreeDPrinting.Web.Areas.Admin.Models.ViewModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<User, UserConciseViewModel>();
            this.CreateMap<User, UserDetailsViewModel>();
        }
    }
}
