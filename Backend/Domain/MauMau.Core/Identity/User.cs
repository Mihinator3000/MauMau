using MauMau.Common.Exceptions;
using MauMau.Core.Players;
using RichEntity.Annotations;

namespace MauMau.Core.Identity;

public partial class User : IEntity<Guid>
{
    private readonly List<Friendship> _friendships;

    private readonly List<Friendship> _outgoingFriendRequests;
    private readonly List<Friendship> _incomingFriendRequests;

    public User(string name, string email, string password, Role role, UserPlayer player)
        : this(Guid.NewGuid())
    {
        Name = name;
        Email = email;
        Password = password;
        Role = role;
        Player = player;

        _friendships = new List<Friendship>();

        _outgoingFriendRequests = new List<Friendship>();
        _incomingFriendRequests = new List<Friendship>();
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

    public byte[]? ProfileImage { get; set; }

    public UserPlayer Player { get; protected init; }

    public AccessToken? AccessToken { get; set; }

    public IReadOnlyCollection<Friendship> Friendships => _friendships;

    public IReadOnlyCollection<Friendship> OutgoingFriendRequests => _outgoingFriendRequests;
    public IReadOnlyCollection<Friendship> IncomingFriendRequests => _incomingFriendRequests;

    public void AddFriendship(Friendship friendship)
    {
        if (_friendships.Contains(friendship))
            throw new DomainInvalidOperationException($"Friendship {friendship} is already in the list");

        _friendships.Add(friendship);
    }

    public void RemoveFriendship(Friendship friendship)
    {
        if (!_friendships.Remove(friendship))
            throw new DomainInvalidOperationException($"Friendship {friendship} was not removed");
    }

    public void AddOutgoingFriendRequest(Friendship friendRequest)
    {
        if (_outgoingFriendRequests.Contains(friendRequest))
            throw new DomainInvalidOperationException($"Friend request {friendRequest} is already exists");

        _outgoingFriendRequests.Add(friendRequest);
    }

    public void RemoveOutgoingFriendRequest(Friendship friendRequest)
    {
        if (!_outgoingFriendRequests.Remove(friendRequest))
            throw new DomainInvalidOperationException($"Friend request {friendRequest} was not removed");
    }

    public void AddIncomingFriendRequest(Friendship friendRequest)
    {
        if (_incomingFriendRequests.Contains(friendRequest))
            throw new DomainInvalidOperationException($"Friend request {friendRequest} is already exists");

        _incomingFriendRequests.Add(friendRequest);
    }

    public void RemoveIncomingFriendRequest(Friendship friendRequest)
    {
        if (!_incomingFriendRequests.Remove(friendRequest))
            throw new DomainInvalidOperationException($"Friend request {friendRequest} was not removed");
    }

    public override string ToString()
        => $"Username: {Name}";
}