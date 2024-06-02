using AutoMapper;
using CinemaHub.Domain.Entities;
using CinemaHub.Infrastructure.DTOs;

namespace CinemaHub.API.Helpers
{
    public class MappingProfiles: Profile 
    {
        public MappingProfiles() 
        { 
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Genre, GenreCreateDto>().ReverseMap();
            CreateMap<Genre, GenreUpdateDto>().ReverseMap();
            CreateMap<GenreDto, GenreUpdateDto>().ReverseMap();

            CreateMap<Actor, ActorDto>().ReverseMap();
            CreateMap<Actor, ActorCreateDto>().ReverseMap();
            CreateMap<Actor, ActorUpdateDto>().ReverseMap();
            CreateMap<ActorDto, ActorUpdateDto>().ReverseMap();
            
            CreateMap<Director, DirectorDto>().ReverseMap();
            CreateMap<Director, DirectorCreateDto>().ReverseMap();
            CreateMap<Director, DirectorUpdateDto>().ReverseMap();
            CreateMap<DirectorDto,DirectorUpdateDto>().ReverseMap();

            CreateMap<Cinema, CinemaDto>().ReverseMap();
            CreateMap<Cinema, CinemaCreateDto>().ReverseMap();
            CreateMap<Cinema, CinemaUpdateDto>().ReverseMap();
            CreateMap<CinemaDto, CinemaUpdateDto>().ReverseMap();

            CreateMap<ScreenSize, ScreenSizeDto>().ReverseMap();
            CreateMap<ScreenSize, ScreenSizeCreateDto>().ReverseMap();
            CreateMap<ScreenSize, ScreenSizeUpdateDto>().ReverseMap();
            CreateMap<ScreenSizeDto, ScreenSizeUpdateDto>().ReverseMap();

            CreateMap<Hall, HallDto>().ReverseMap();
            CreateMap<Hall, HallCreateDto>().ReverseMap();
            CreateMap<Hall, HallUpdateDto>().ReverseMap();
            CreateMap<HallDto, HallUpdateDto>().ReverseMap();
        }
    }
}
