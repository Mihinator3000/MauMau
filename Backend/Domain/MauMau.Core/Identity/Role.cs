using RichEntity.Annotations;

namespace MauMau.Core.Identity;

public partial class Role : IEntity<Guid>
{
    public Role(string name) : this(Guid.NewGuid())
    {
        Name = name;
    }

    public string Name { get; protected init; }
}