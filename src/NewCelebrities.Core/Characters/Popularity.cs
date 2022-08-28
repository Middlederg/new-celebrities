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

        public int Stars
        {
            get
            {
                return wikipediaReaders switch
                {
                    null => 0,
                    < 100 => 0,
                    < 1000 => 5,
                    < 5000 => 10,
                    < 10000 => 15,
                    < 50000 => 20,
                    < 100000 => 25,
                    < 500000 => 30,
                    < 1000000 => 35,
                    < 5000000 => 40,
                    < 10000000 => 45,
                    _ => 50,
                };
            }
        }

        public string Text => (Stars / 10.0m).ToString();
        public override string ToString() => String.Join("", Enumerable.Range(0, Stars / 10).Select(x => "⭐"));

        public string ToPrimitive() => wikipediaReaders?.ToString() ?? "";

        public bool Easy => Stars == 50;
        public bool Intermediate => Stars == 45;
        public bool Hard => Stars <= 40;

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