namespace NewCelebrities.Shared
{
    public class Location
    {
        public string Country { get; init; }
        public string Citizenship { get; init; }
        public string Place { get; init; }
        public string Subregion { get; init; }
        public Coordinates BirthPlaceCoordinates { get; init; }
        public Coordinates DeathPlaceCoordinates { get; init; }
    }
}
