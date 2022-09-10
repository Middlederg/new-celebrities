using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace NewCelebrities.Shared
{
    public enum Age
    {
        [Description("¿?")]
        Unknown,

        [Description("Begining of writing - 476")]
        Ancient,

        [Description("476 - 1453")]
        Medieval,

        [Description("1453 - 1789")]
        Modern,

        [Description("1789 - Today")]
        Contemporary
    }

    public static class AgesExtensions
    {
        public static IEnumerable<Age> AgeList(this Age age) => Age.GetValues<Age>();
        
    }
}