namespace startrekdemo.Domain;

public class SeriesList
{
	public List<Series> value { get; set; } = new List<Series>();
}

public class Series
{
	public int Id { get; set; }
	public string Name { get; set; }
	public CharacterList Characters { get; set; } = new CharacterList();
	
}