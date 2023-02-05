using MauMau.Abstractions.GameLogic.Providers;

namespace MauMau.GameLogic.Providers;

public class RandomProvider : IRandomProvider
{
    private readonly Random _random;

    public RandomProvider() : this(new Random()) { }

    public RandomProvider(Random random)
    {
        _random = random;
    }

    public Random GetRandom()
        => _random;
}