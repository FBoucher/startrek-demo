# startrek-demo

1. dotnet new tool-manifest
1. dotnet tool install StrawberryShake.Tools -l
1. dotnet add package StrawberryShake.Blazor
2. dotnet graphql init https://localhost:5001/graphql/ -n StartrekClient


```csharp
	IEnumerable<IGetRooms_Rooms_Items> result = new List<IGetRooms_Rooms_Items>();

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		var temp = await dungeonDemoClient.GetRooms.ExecuteAsync();

		result = temp.Data.Rooms.Items;
		
	}
```


## Console

dotnet new console -n txt-startrek -o console

cd .\console\

dotnet new tool-manifest

dotnet tool install StrawberryShake.Tools --local

dotnet add package StrawberryShake.Server     

dotnet graphql init http://localhost:5000/graphql -n StartrekClient 

add namespace RC file




