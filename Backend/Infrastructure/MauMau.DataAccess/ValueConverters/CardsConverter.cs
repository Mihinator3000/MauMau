using MauMau.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace MauMau.DataAccess.ValueConverters;

public class CardsConverter : ValueConverter<Cards, string>
{
    public CardsConverter()
        : base(x => JsonConvert.SerializeObject(x),
            x => JsonConvert.DeserializeObject<Cards>(x)) { }
}