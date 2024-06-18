namespace startrekdemo.Domain
{
    public class PlanetList
    {
        public List<Planet> value { get; set; } = new List<Planet>();
        public string? nextLink { get; set; }
    }
}
