using System.ComponentModel;

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
}