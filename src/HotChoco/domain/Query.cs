
using HotChoco.Domain;
using HotChocolate.Tools;
using HotChocolate.Types.Pagination;

public class Query
{
	private const int NUM_ACTORS = 1000;

	[UseOffsetPaging(IncludeTotalCount = true)]
	public CollectionSegment<Actor> GetActors(int? skip, int? take, string sortBy)
	{
		IEnumerable<Actor>	Actors = ExecuteQuery(skip,take); 

		var pageInfo = new CollectionSegmentInfo((GetActorTotalCount() > skip + take), (skip>0));

		var collectionSegment = new CollectionSegment<Actor>(
			(IReadOnlyCollection<Actor>)Actors,
			pageInfo,
			ct => ValueTask.FromResult(GetActorTotalCount())
			);

		return collectionSegment;

	}

	private int GetActorTotalCount(){
		return NUM_ACTORS;
	}

	public IEnumerable<Actor> GetActors2()
	{
		var gen = new ActorGen();
		return gen.Generate(NUM_ACTORS); 
	}

	private IEnumerable<Actor> ExecuteQuery(int? skip, int? take){
		var gen = new ActorGen();
		IEnumerable<Actor> Actors = null;

		if (skip != null && take != null)
		{ 
			Actors = gen.Generate(NUM_ACTORS).Skip(skip.Value).Take(take.Value); 
		}
		else
		{ 
			Actors = gen.Generate(NUM_ACTORS); 
		}
		return Actors;
	}
}
