using RichEntity.Annotations;

namespace MauMau.Core.Identity;

public partial class AccessToken : IEntity<Guid>, IEntity
{
    public AccessToken(User user, string value, DateTime expirationDateTime)
        : this(user.Id, Guid.NewGuid())
    {
        User = user;
        Value = value;
        ExpirationDateTime = expirationDateTime;
    }

    [KeyProperty]
    public User User { get; protected init; }

    public string Value { get; protected init; }

    public DateTime ExpirationDateTime { get; protected init; }

    public override string ToString()
        => $"Id: {Id}, User: {User}";
}