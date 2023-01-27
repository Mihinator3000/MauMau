using MauMau.Common.Enums;
using RichEntity.Annotations;

namespace MauMau.Core.Identity;

public partial class Friendship : IEntity
{
    public Friendship(
        User sender,
        User receiver,
        FriendRequestStatus status = FriendRequestStatus.InProgress)
        : this(receiver.Id, sender.Id)
    {
        Sender = sender;
        Receiver = receiver;
        Status = status;
    }

    [KeyProperty]
    public User Sender { get; protected init; }

    [KeyProperty]
    public User Receiver { get; protected init; }

    public FriendRequestStatus Status { get; protected init; }

    public override string ToString()
        => $"Sender: {Sender}, Receiver: {Receiver}";
}