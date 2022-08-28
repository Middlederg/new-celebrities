using NewCelebrities.Core.File;

namespace NewCelebrities.Core
{
    public record Coordinates
    {
        const float EarthRadiusInKilometers = 6378.0F;
        private readonly Latitude latitude;
        private readonly Longitude longitude;

        public Coordinates(Latitude latitude, Longitude longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public float StraightDistanceInKilometersTo(Coordinates position)
        {
            /// Haversine formula
            var latitudeInRadian = ToRadian(position.latitude - latitude);
            var longitudeInRadian = ToRadian(position.longitude - longitude);
            var a = Math.Pow(Math.Sin(latitudeInRadian / 2), 2) +
                    Math.Cos(ToRadian(latitudeInRadian)) *
                    Math.Cos(ToRadian(position.latitude)) *
                    Math.Pow(Math.Sin(longitudeInRadian / 2), 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusInKilometers * Convert.ToSingle(c);
        }

        private static float ToRadian(float value) => Convert.ToSingle(Math.PI / 180) * value;

        public string ToPrimitives() => $"{latitude}{Writer.Separator}{longitude}";

        public Shared.Coordinates ToDto()
        {
            return new Shared.Coordinates()
            {
                Latitude = latitude,
                Longitude = longitude,
            };
        }
    }
}