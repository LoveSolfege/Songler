using Application.DTO.Create;
using Application.DTO.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
        //Artist Mappings
        CreateMap<ArtistCreateDto, Artist>();
        CreateMap<Artist, ArtistResponseDto>()
            .ForMember(dest => dest.Albums, opt => 
                opt.MapFrom(src => src.Albums));
        
        //Album mappings
        CreateMap<AlbumCreateDto, Album>();
        CreateMap<Album, AlbumResponseDto>()
            .ForMember(dest => dest.ArtistName,
                opt => opt.MapFrom(src => src.Artist.Name))
            .ForMember(dest => dest.Songs,
                opt => opt.MapFrom(src => src.Songs));
		
        //Song mappings
        CreateMap<SongCreateDto, Song>();
        CreateMap<Song, SongResponseDto>()
            .ForMember(dest => dest.ArtistName, opt =>
                opt.MapFrom(src => src.Artist.Name))
            .ForMember(dest => dest.AlbumTitle, opt => 
                opt.MapFrom(src => src.Album.Title))
            .ForMember(dest => dest.GradeLetter, opt => 
                opt.MapFrom(src => src.Grade.Letter));
		
        //Grade Mappings
        CreateMap<GradeCreateDto, Grade>();
        CreateMap<Grade, GradeResponseDto>();
    }

}