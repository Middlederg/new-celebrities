using System.ComponentModel;

namespace NewCelebrities.Core
{
    public record Color
    {
        private readonly string name;
        public string Hex { get; }

        private Color(string name, string hex)
        {
            this.name = name;
            Hex = hex;
        }

        public override string ToString() => name;

        public static Color Bluemoon => new Color("Bluemoon", "#00bfff");
        public static Color Greenfindor => new Color("Greenfindor", "#00ff00");
        public static Color Passion => new Color("Passion", "#ff0000");
        public static Color Lemon => new Color("Lemon", "#ffff00");
        public static Color DarkParty => new Color("Dark party", "#000000");
        public static Color PacificTeam => new Color("Pacific team", "#0000ff");
    }
}
