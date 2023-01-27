using MauMau.Common.Enums.Cards;
using MauMau.Common.Exceptions;
using RichEntity.Annotations;

namespace MauMau.Core.GameComponents.Options;

public partial class GameOptions : IEntity<Guid>
{
    private readonly List<PlayerPosition> _playerPositions;

    public GameOptions(
        long stake,
        int playerCount,
        Rank minCardRank,
        int handSize,
        string? password = null)
        : this(Guid.NewGuid())
    {
        Stake = stake;
        PlayerCount = playerCount;
        MinCardRank = minCardRank;
        HandSize = handSize;
        Password = password;

        _playerPositions = new List<PlayerPosition>();
    }

    public long Stake { get; protected init; }

    public int PlayerCount { get; protected init; }
    public Rank MinCardRank { get; protected init; }
    public int HandSize { get; protected init; }

    public string? Password { get; protected init; }

    public bool IsOpen => string.IsNullOrEmpty(Password);

    public IReadOnlyCollection<PlayerPosition> PlayerPositions => _playerPositions;

    public bool IsFull => PlayerCount == _playerPositions.Count;

    public void AddPlayerPosition(PlayerPosition playerPosition)
    {
        if (playerPosition.Position < 0 || playerPosition.Position > PlayerCount)
            throw new DomainInvalidOperationException($"Position of player {playerPosition.Player} is incorrect");

        _playerPositions.Add(playerPosition);
    }

    public void RemovePlayerPosition(PlayerPosition playerPosition)
    {
        if (!_playerPositions.Remove(playerPosition))
            throw new DomainInvalidOperationException($"Position of player {playerPosition.Player} could not be removed");
    }

    public override string ToString()
        => $"Id: {Id}";
}