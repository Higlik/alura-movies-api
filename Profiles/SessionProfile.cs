using alura_movies_api.Data.Dtos;
using alura_movies_api.Models;
using AutoMapper;

namespace alura_movies_api.Profiles;

public class SessionProfile : Profile
{
    public SessionProfile()
    {
        CreateMap<CreateSessionDto,Session>();
        CreateMap<Session, ReadSessionDto>();
    }
}