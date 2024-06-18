
using HotChoco.Domain;
using HotChocolate.Tools;
using HotChocolate.Types.Pagination;

public class Query
{
	private const int _NUM_PLANETS = 1000;

	[UseOffsetPaging(IncludeTotalCount = true)]
	public CollectionSegment<Planet> GetPlanets(int? skip, int? take, string sortBy)
	{
		IEnumerable<Planet>	planets = ExecuteQuery(skip,take); 

		var pageInfo = new CollectionSegmentInfo((GetPlanetTotalCount() > skip + take), (skip>0));

		var collectionSegment = new CollectionSegment<Planet>(
			(IReadOnlyCollection<Planet>)planets,
			pageInfo,
			ct => ValueTask.FromResult(GetPlanetTotalCount())
			);

		return collectionSegment;

	}

	private int GetPlanetTotalCount(){
		return _NUM_PLANETS;
	}

	public IEnumerable<Planet> GetPlanets2()
	{
		var gen = new PlanetGen();
		return gen.Generate(_NUM_PLANETS); 
	}

	private IEnumerable<Planet> ExecuteQuery(int? skip, int? take){
		var gen = new PlanetGen();
		IEnumerable<Planet> planets = null;

		if (skip != null && take != null)
		{ 
			planets = gen.Generate(_NUM_PLANETS).Skip(skip.Value).Take(take.Value); 
		}
		else
		{ 
			planets = gen.Generate(_NUM_PLANETS); 
		}
		return planets;
	}
}
