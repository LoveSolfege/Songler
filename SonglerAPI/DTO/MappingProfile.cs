using AutoMapper;
using SonglerAPI.DTO.Create;
using SonglerAPI.DTO.Response;
using SonglerAPI.Entities;

namespace SonglerAPI.DTO;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
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
			.ForMember(dest => dest.AlbumTitle, opt => 
				opt.MapFrom(src => src.Album.Title))
			.ForMember(dest => dest.GradeLetter, opt => 
				opt.MapFrom(src => src.Grade.Letter));
		
		//Artist Mappings
		CreateMap<ArtistCreateDto, Artist>();
		CreateMap<Artist, ArtistResponseDto>()
			.ForMember(dest => dest.Albums, opt => 
				opt.MapFrom(src => src.Albums));
		
		//Grade Mappings
		CreateMap<GradeCreateDto, Grade>();
		CreateMap<Grade, GradeResponseDto>();
		
	}
}