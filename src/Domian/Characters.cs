namespace startrekdemo.Domain;

public class CharacterList
{
	public List<Character> value { get; set; } = new List<Character>();
}

public class Character
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int ActorId { get; set; }
	public double Stardate { get; set; }
}