using MauMau.Common.Enums.Cards;

namespace MauMau.Application.Dto.Game.Creation;

public record GameOptionsDto(
    long Stake,
    int PlayerCount,
    Rank MinCardRank,
    int HandSize,
    string? Password);