namespace MauMau.Core.ValueObjects;

public readonly struct Cards
{
    public Cards()
    {
        Value = new List<Card>();
    }

    public Cards(ICollection<Card> cards)
    {
        Value = cards;
    }

    public ICollection<Card> Value { get; }
}