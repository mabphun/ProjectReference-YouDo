using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserWorkLog, UserWorkLogDto>();
        }
    }
}
