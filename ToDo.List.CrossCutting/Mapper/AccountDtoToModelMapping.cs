using AutoMapper;
using ToDo.List.Domain.Domain;
using ToDo.List.Domain.DTOs;

namespace ToDo.List.CrossCutting.Mapper;

public class AccountDtoToModelMapping : Profile
{
    public AccountDtoToModelMapping()
    {
        CreateMap<AccountRequestDTO, Account>()
            .ForMember(dest => dest.Nome, map => map.MapFrom(src => src.Nome))
            .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Email))
            .ForMember(dest => dest.Senha, map => map.MapFrom(src => HashPassword(src.Senha)))
        ;
    }

    private string HashPassword(string password)
        => BCrypt.Net.BCrypt.HashPassword(password, 10);
}