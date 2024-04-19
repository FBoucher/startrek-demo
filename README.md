# startrek-demo

1.dotnet new tool-manifest
1. dotnet tool install StrawberryShake.Tools
1. dotnet add package StrawberryShake.Blazor
1. ~~dotnet add package StrawberryShake.CodeGeneration.CSharp.Analyzer~~
1. dotnet graphql init http://localhost:5000/graphql/ -n DungeonDemoClient


```csharp
	IEnumerable<IGetRooms_Rooms_Items> result = new List<IGetRooms_Rooms_Items>();

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		var temp = await dungeonDemoClient.GetRooms.ExecuteAsync();

		result = temp.Data.Rooms.Items;
		
	}
```
