using MauMau.Abstractions.Application.Providers;

namespace MauMau.Application.Providers;

public class UtcDateTimeProvider : IDateTimeProvider
{
    public DateTime GetCurrentDateTime()
        => DateTime.UtcNow;
}