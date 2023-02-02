using MauMau.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace MauMau.DataAccess.ValueConverters;

public class CardConverter : ValueConverter<Card, string>
{
    public CardConverter()
        : base(x => JsonConvert.SerializeObject(x),
            x => JsonConvert.DeserializeObject<Card>(x)) { }
}