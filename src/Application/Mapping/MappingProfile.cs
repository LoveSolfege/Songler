using Application.DTO.Create;
using Application.DTO.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Artist Mappings
        CreateMap<ArtistCreateDto, Artist>();
        CreateMap<Artist, ArtistResponseDto>();
        
        //Album mappings
        CreateMap<AlbumCreateDto, Album>();
        CreateMap<Album, AlbumResponseDto>();
		
        //Song mappings
        CreateMap<SongCreateDto, Song>();
        CreateMap<Song, SongResponseDto>();
		
        //Grade Mappings
        CreateMap<GradeCreateDto, Grade>();
        CreateMap<Grade, GradeResponseDto>();
    }

}