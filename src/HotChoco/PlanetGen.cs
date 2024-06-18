using Bogus;
using HotChoco.Domain;

namespace HotChocolate.Tools;

public class PlanetGen
{
	private Faker<Planet> fPlanet;

	public PlanetGen()
	{
		Randomizer.Seed = new Random(97630865);
		fPlanet = new Faker<Planet>()
			.RuleFor(p => p.Id, f => f.IndexVariable++)
			.RuleFor(p => p.Name, f => f.Name.LastName())
			.RuleFor(p => p.Coordinates, f => string.Concat(f.Random.Number(1, 999999),
																",", f.Random.Number(1, 999999), 
																",", f.Random.Number(1, 999999))
															);
		
	}
	public List<Planet> Generate(int count)
	{
		return fPlanet.Generate(count);	
	}
}