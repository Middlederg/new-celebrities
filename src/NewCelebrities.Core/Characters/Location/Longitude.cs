namespace NewCelebrities.Core
{
    public record Longitude
    {
        private readonly float value;

        private Longitude(float value)
        {
            if (!IsValid(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "Longitude must be in range [-180; 180]");
            }

            this.value = value;
        }

        public static Longitude FromScalar(float value)
        {
            return new Longitude(value);
        }

        public static implicit operator float(Longitude longitude)
        {
            return longitude.value;
        }

        public static explicit operator Longitude(float value)
        {
            return new Longitude(value);
        }

        public override string ToString() => value.ToText();

        public static bool IsValid(float? longitude) => longitude.HasValue && longitude >= -180 && longitude <= 180;
    }
}