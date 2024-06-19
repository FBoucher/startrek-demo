
using HotChoco.Domain;
using HotChocolate.Types.Pagination;
using System.Data.Common;
using System.Data.SqlClient;

public class Query
{
	private readonly IConfiguration Configuration;
	string conn = string.Empty;

	public Query(IConfiguration configuration)
    {
        Configuration = configuration;
    }
	private string ConnTrekDB{
		get{
			if (string.IsNullOrEmpty(conn)){
				conn = Configuration["ConnectionStrings:trekDB"];
			}
			return conn;
		}
	}

	[UseOffsetPaging(IncludeTotalCount = true)]
	public CollectionSegment<Actor> GetActors(int? skip, int? take, string sortBy)
	{
		IEnumerable<Actor> Actors = GetDBActors(skip, take);

		var pageInfo = new CollectionSegmentInfo((GetActorTotalCount() > skip + take), (skip > 0));

		var collectionSegment = new CollectionSegment<Actor>(
			(IReadOnlyCollection<Actor>)Actors,
			pageInfo,
			ct => ValueTask.FromResult(GetActorTotalCount())
			);

		return collectionSegment;

	}

	private IEnumerable<Actor> GetDBActors(int? skip, int? take = null)
	{
		var actors = new List<Actor>();

		SqlConnection dbConn = new SqlConnection(ConnTrekDB);

		SqlCommand myCommand = dbConn.CreateCommand();
		string limitSection = (take is null) ? "" : $"FETCH NEXT {take} ROWS ONLY"; 
		string offsetSection = (skip is null) ? "OFFSET 0 ROWS" : $"OFFSET {skip} ROWS"; 
		myCommand.CommandText = $"SELECT id, Name, [BirthYear] FROM Actor ORDER BY Name {offsetSection} {limitSection}";
		dbConn.Open();
		using (var myReader = myCommand.ExecuteReader())
		{
			while (myReader.Read())
			{
				actors.Add(new Actor
				{
					Id = myReader.GetInt32(0),
					Name = myReader.GetString(1),
					BirthYear = myReader.GetInt32(2)
				});
			}
		}
		dbConn.Close();
		return actors;
	}

	private int GetActorTotalCount()
	{
		SqlConnection dbConn = new SqlConnection(ConnTrekDB);

		SqlCommand myCommand = dbConn.CreateCommand(); 
		myCommand.CommandText = $"SELECT COUNT(1) FROM Actor";
		dbConn.Open();
		int result = Convert.ToInt32(myCommand.ExecuteScalar());
		dbConn.Close();
		return result;
	}
}
