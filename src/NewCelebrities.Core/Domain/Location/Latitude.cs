namespace NewCelebrities.Core
{
    public record Latitude
    {
        private readonly float value;

        private Latitude(float value)
        {
            if (!IsValid(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "Latitude must be in range [-90; 90]");
            }

            this.value = value;
        }

        public static Latitude FromScalar(float value)
        {
            return new Latitude(value);
        }

        public static implicit operator float(Latitude latitude)
        {
            return latitude.value;
        }

        public static explicit operator Latitude(float value)
        {
            return new Latitude(value);
        }

        public override string ToString() => value.ToString();

        public static bool IsValid(float? latitude) => latitude.HasValue && latitude >= -90 && latitude <= 90;
    }
}