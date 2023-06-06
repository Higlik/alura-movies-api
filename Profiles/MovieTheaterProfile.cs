using alura_movies_api.Data.Dtos;
using alura_movies_api.Models;
using AutoMapper;

namespace alura_movies_api.Profiles
{
    public class MovieTheaterProfile : Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<CreateMovieTheaterDto, MovieTheater>();
            CreateMap<MovieTheater, ReadMovieTheaterDto>();
            CreateMap<UpdateMovieTheaterDto, MovieTheater>();

        }
    }
}