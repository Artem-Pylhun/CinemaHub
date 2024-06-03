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
            CreateMap<DirectorDto, DirectorUpdateDto>().ReverseMap();
            
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

            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => new GenreDto { Id = g.Id, Title = g.Title })))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(a => new ActorDto { Id = a.Id, FullName = a.FullName })))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(d => new DirectorDto { Id = d.Id, FullName = d.FullName })))
                .ReverseMap()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => new Genre { Id = g.Id, Title = g.Title })))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(a => new Actor { Id = a.Id, FullName = a.FullName })))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(d => new Director { Id = d.Id, FullName = d.FullName })));

            CreateMap<Movie, MovieCreateDto>().ReverseMap();
            CreateMap<Movie, MovieUpdateDto>().ReverseMap();
            CreateMap<MovieDto, MovieUpdateDto>().ReverseMap();

            CreateMap<MovieDto, MovieDetailsDto>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => g.Title)))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(a => a.FullName)))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(d => d.FullName)))
                .ReverseMap()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(name => new GenreDto { Title = name })))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(name => new ActorDto { FullName = name })))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(name => new DirectorDto { FullName = name })));


            CreateMap<Screening, ScreeningDto>().ReverseMap();
            CreateMap<Screening, ScreeningCreateDto>().ReverseMap();
            CreateMap<Screening, ScreeningUpdateDto>().ReverseMap();
            CreateMap<ScreeningDto, ScreeningUpdateDto>().ReverseMap();
        }
    }
}
