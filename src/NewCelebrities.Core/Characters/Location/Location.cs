using NewCelebrities.Core.File;

namespace NewCelebrities.Core
{
    public record Location
    {
        public string Country { get; init; }
        public string Citizenship { get; init; }
        public string Place { get; init; }
        public string Subregion { get; init; }
        public Coordinates BirthPlaceCoordinates { get; init; }
        public Coordinates DeathPlaceCoordinates { get; init; }

        public static Location FromDto(Shared.Location dto)
        {
            return new Location(country: dto.Country,
                   citizenship: dto.Citizenship,
                   place: dto.Place,
                   subregion: dto.Subregion,
                   birthplaceLatitude: dto.BirthPlaceCoordinates?.Latitude,
                   birthplaceLongitude: dto.BirthPlaceCoordinates?.Longitude,
                   deathPlaceLatitude: dto.DeathPlaceCoordinates?.Latitude,
                   deathPlaceLongitude: dto.DeathPlaceCoordinates?.Longitude);
        }

        public Shared.Location ToDto()
        {
            return new Shared.Location()
            {
                BirthPlaceCoordinates = BirthPlaceCoordinates?.ToDto(),
                Citizenship = Citizenship,
                Country = Country,
                DeathPlaceCoordinates = DeathPlaceCoordinates?.ToDto(),
                Place = Place,
                Subregion = Subregion
            };
        }

        public Location(string country, string citizenship, string place, string subregion, float? birthplaceLongitude, 
            float? deathPlaceLongitude, float? birthplaceLatitude, float? deathPlaceLatitude)
        {
            Country = country;
            Citizenship = citizenship;
            Place = place;
            Subregion = subregion;

            if (Latitude.IsValid(birthplaceLatitude) && Longitude.IsValid(birthplaceLongitude))
            {
                BirthPlaceCoordinates = new Coordinates(Latitude.FromScalar(birthplaceLatitude.Value), Longitude.FromScalar(birthplaceLongitude.Value));
            }

            if (Latitude.IsValid(deathPlaceLatitude) && Longitude.IsValid(deathPlaceLongitude))
            {
                DeathPlaceCoordinates = new Coordinates(Latitude.FromScalar(deathPlaceLatitude.Value), Longitude.FromScalar(deathPlaceLongitude.Value));
            }
        }

        public override string ToString() => Country ?? "";

        public string ToPrimitive()
        {
            var items = new string[]
            {
                Country ?? "",
                Citizenship ?? "",
                Place ?? "",
                Subregion ?? "",
                BirthPlaceCoordinates?.ToPrimitives() ?? Writer.Separator.ToString(),
                DeathPlaceCoordinates?.ToPrimitives() ?? Writer.Separator.ToString(),
            };
            return string.Join(Writer.Separator, items);
        }
    }
}