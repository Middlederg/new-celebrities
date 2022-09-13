namespace NewCelebrities.Core
{
    public class Popularity
    {
        private readonly int? wikipediaReaders;

        public bool Unknown => !wikipediaReaders.HasValue;

        public Popularity(int? wikipediaReaders)
        {
            this.wikipediaReaders = wikipediaReaders;
        }

        public static Popularity FromStars(int stars)
        {
            return stars switch
            {
                0 => new Popularity(0),
                5 => new Popularity(004500000),
                10 => new Popularity(05500000),
                15 => new Popularity(06500000),
                20 => new Popularity(07500000),
                25 => new Popularity(08500000),
                30  => new Popularity(9500000),
                35 => new Popularity(10500000),
                40 => new Popularity(11500000),
                45 => new Popularity(12500000),
                50 => new Popularity(13500000),
                _ => throw new NotImplementedException()
            };
        }

        public int Stars
        {
            get
            {
                return wikipediaReaders switch
                {
                    null => 0,
                    < 5000000 => 5,
                    < 6000000 => 10,
                    < 7000000 => 15,
                    < 8000000 => 20,
                    < 9000000 => 25,
                    < 10000000 => 30,
                    < 11000000 => 35,
                    < 12000000 => 40,
                    < 13000000 => 45,
                    _ => 50,
                };
            }
        }

        public string Text => (Stars / 10.0m).ToString();
        public override string ToString() => string.Join("", Enumerable.Range(0, Stars / 10).Select(x => "⭐"));
        public int FullStars() => Enumerable.Range(0, Stars / 10).Count();
        public int HalfStars() => Stars % 10 != 0 ? 1 : 0;
        public int EmptyStars() => 5 - FullStars() - HalfStars();

        public string ToPrimitive() => wikipediaReaders?.ToString() ?? "";

        public bool Easy => Stars == 50;
        public bool Intermediate => Stars > 30 && Stars < 50;
        public bool Hard => Stars <= 30;

        public static implicit operator int?(Popularity popularity)
        {
            return popularity.wikipediaReaders;
        }

        public static explicit operator Popularity(int? wikipediaReaders)
        {
            return new Popularity(wikipediaReaders);
        }
    }
}