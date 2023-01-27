﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MauMau.DataAccess.ValueConverters;

public class TimeSpanConverter : ValueConverter<TimeSpan, long>
{
    public TimeSpanConverter()
        : base(x => x.Ticks, x => TimeSpan.FromTicks(x)) { }
}