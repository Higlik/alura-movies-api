using alura_movies_api.Data.Dtos;
using alura_movies_api.Models;
using AutoMapper;

namespace alura_movies_api.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDto, Address>();
        CreateMap<UpdateAddressDto, Address>();
        CreateMap<Address, ReadAddressDto>();

        
    }
}