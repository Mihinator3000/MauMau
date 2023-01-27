using System.Text.Json;
using MauMau.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MauMau.DataAccess.ValueConverters;

public class CardsConverter : ValueConverter<Cards, string>
{
    public CardsConverter()
        : base(x => Serialize(x), x => Deserialize(x)) { }

    public static string Serialize(Cards cards)
        => JsonSerializer.Serialize(cards);

    public static Cards Deserialize(string s)
        => JsonSerializer.Deserialize<Cards>(s);
}