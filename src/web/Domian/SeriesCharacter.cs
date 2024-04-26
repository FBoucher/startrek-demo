namespace startrekdemo.Domain;

public class SeriesCharacterList
{
	public List<SeriesCharacter> value { get; set; } = new List<SeriesCharacter>();
}

public class SeriesCharacter
{
	public int SeriesId { get; set; }
	public int CharacterId { get; set; }
	public string Role { get; set; }
	
}