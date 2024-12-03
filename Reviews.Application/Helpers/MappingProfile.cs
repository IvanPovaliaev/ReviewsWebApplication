using AutoMapper;
using Reviews.Application.Models;
using Reviews.Domain.Models;

namespace Reviews.Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Review, ReviewDTO>().ReverseMap();
        }
    }
}
