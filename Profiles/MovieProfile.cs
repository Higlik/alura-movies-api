using alura_movies_api.Data.Dtos;
using alura_movies_api.Models;
using AutoMapper;

namespace alura_movies_api.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<UpdateMovieDto, Movie>();
        CreateMap<Movie, UpdateMovieDto>();
        CreateMap<Movie, ReadMovieDto>()
            .ForMember(movieDto => movieDto.Sessions,
                opt => opt.MapFrom(movie => movie.Sessions));
    }
}