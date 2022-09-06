using System.ComponentModel;

namespace NewCelebrities.Core
{
    public record Color
    {
        public int Index { get; }
        private readonly string name;
        public string BackgroundColor { get; }
        public string TextColor { get; }

        private Color(int index, string name, string backgroundColor, string textColor)
        {
            this.name = name;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
        }

        public override string ToString() => name;

        public static Color Bluemoon => new Color(1, "Bluemoon", "#00bfff", "#333");
        public static Color Greenfindor => new Color(2, "Greenfindor", "#00ff00", "#333");
        public static Color Passion => new Color(3, "Passion", "#ff0000", "#fff");
        public static Color Lemon => new Color(4, "Lemon", "#ffff00", "#333");
        public static Color DarkParty => new Color(5, "Dark party", "#000000", "#fff");
        public static Color PacificTeam => new Color(6, "Pacific team", "#0000ff", "#fff");

        public static IEnumerable<Color> All => new List<Color> { Bluemoon, Greenfindor, Passion, Lemon, DarkParty, PacificTeam };
    }
}
