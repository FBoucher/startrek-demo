using Bogus;
using HotChoco.Domain;

namespace HotChocolate.Tools;

public class ActorGen
{
	private Faker<Actor> fActor;

	public ActorGen()
	{
		Randomizer.Seed = new Random(97630865);
        var ActorId = 100;
        fActor = new Faker<Actor>()
			.RuleFor(p => p.Id, f => ActorId++)
			.RuleFor(p => p.Name, f => f.Name.FullName())
			.RuleFor(p => p.BirthYear, f => f.Random.Number(1920, 2018));

    }
	public List<Actor> Generate(int count)
	{
		return fActor.Generate(count);	
	}
}