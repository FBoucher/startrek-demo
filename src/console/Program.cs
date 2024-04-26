using System;
using Microsoft.Extensions.DependencyInjection;
using Startrek.Graphql;
using StrawberryShake;

class Program
{
	static  async Task Main(string[] args)
	{
		var serviceCollection = new ServiceCollection();

		serviceCollection.AddStartrekClient().ConfigureHttpClient(client =>
		{
			client.BaseAddress = new Uri("http://localhost:5000/graphql");
		});

		var services = serviceCollection.BuildServiceProvider();
		var client = services.GetRequiredService<IStartrekClient>();


		var result = await client.GetCharacterbySeries.ExecuteAsync();
		result.EnsureNoErrors();

		Console.WriteLine("🖖, World!");
	

		foreach (var show in result.Data.Series.Items)
		{
			Console.WriteLine($"- Series: {show.Name}");
			foreach (var character in show.Character.Items)
			{
				Console.WriteLine($"  . {character.Name}");
			}
		}
	}
}
