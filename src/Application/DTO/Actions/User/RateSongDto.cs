namespace Application.DTO.Actions.User;

public record RateSongDto(Guid UserId, Guid SongId, int Rating);