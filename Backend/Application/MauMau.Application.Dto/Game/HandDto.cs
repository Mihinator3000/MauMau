namespace MauMau.Application.Dto.Game;

public record HandDto(Guid Id, Guid PlayerId, IReadOnlyCollection<CardDto> Cards);