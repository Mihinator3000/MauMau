namespace MauMau.Application.Dto.Game;

public record GameDto(
    Guid Id,
    long WinMoney,
    CardsDto Deck,
    CardsDto Pile,
    IReadOnlyCollection<HandDto> Hands,
    IReadOnlyCollection<MoveDto> Moves,
    int CurrentHandNumber,
    bool IsRotationClockWise,
    int MovesLeftCount);