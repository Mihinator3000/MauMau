using MauMau.Common.Enums.Cards;

namespace MauMau.Application.Dto.Game.Creation;

public record GameCreationDto(
    IReadOnlyCollection<Guid> PlayerIds,
    long Stake,
    Rank MinCardRank,
    int HandSize);