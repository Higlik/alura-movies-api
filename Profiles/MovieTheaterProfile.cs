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
            CreateMap<MovieTheater, ReadMovieTheaterDto>()
            .ForMember(movieTheaterDto => movieTheaterDto.Address,
                opt => opt.MapFrom(movieTheater => movieTheater.Address))
            .ForMember(movieTheaterDto => movieTheaterDto.Sessions,
                opt => opt.MapFrom(movieTheater => movieTheater.Sessions));
            CreateMap<UpdateMovieTheaterDto, MovieTheater>();

        }
    }
}