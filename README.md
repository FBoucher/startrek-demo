# Star Trek Demo

This repository contains simple demo projects to show how to use Data API Builder (DAB) to create REST & GrapQL APIs to access data from a SQL Server database, and how to use [Strawberry Shake](https://chillicream.com/docs/strawberryshake) to generate a GraphQL client for different .NET applications.

Those demos were used in videos and blog posts. 
- Azure Developers .NET Days: 
  - [Auto-Generate and Host Data API Builder on Azure Static Web Apps](https://www.youtube.com/watch?v=GO2R7IW6s3k&list=PLI7iePan8aH4cuFgP9YbRODrSEwXNA8Yq&index=13) 
  - [The most minimal API code of all... none](https://www.youtube.com/watch?v=A1H1kVPHs3w&list=PLI7iePan8aH4cuFgP9YbRODrSEwXNA8Yq&index=15).
  
- more soon...

## The different demos

### Database and APIs in Containers

The folder [database-api](database-api/) contains a simple `docker-compose` that deploys an SQL Server in a first container and Data API Builder (DAB) in a second one. When the database container starts, it runs a SQL script `startrek.sql` to create the database tables and populate the Star Trek tables. Finally the DAB container starts and connects to the SQL Server database to expose a REST API and a GraphQL API.

### Simple .NET Console App using GraphQL

The folder [src/console/](src/console/) contains a console application the uses the GraphQL client generated with the StrawberryShake package to query the GraphQL API exposed by DAB. The application is a simple console application that queries the GraphQL API to get the list of Star Trek characters by series.

### Blazor WebAssembly App using GraphQL and QuickGrid

The folder [src/startrek-wasm/](src/startrek-wasm/) contains a Blazor WebAssembly website to demonstrate how to use GraphQL with QuickGrid. The website uses the generated component and client, using the StrawberryShake.Blazor package to query the GraphQL API to display the list of Actors. A second page shows how to use QuickGrid with the `virtualize` feature to display a large list of actors.


### Blazor website App using GraphQL and QuickGrid (same as above but with a server-side Blazor)

The folder [src/web/](src/web/) contains a Blazor website to demonstrate how to use GraphQL with QuickGrid. The website uses the generated component and client, using the StrawberryShake.Blazor package to query the GraphQL API to display the list of Actors. A second page shows how to use QuickGrid with the `virtualize` feature to display a large list of actors.

### chocoSpock is a custom GraphQL endpoint

The folder [src/chocoSpock/](src/chocoSpock/) contains a simple GraphQL endpoint that implements the required `skip` and `take` arguments to allow virtualization with Blazor QuickGrid. The minimal API uses `HotChocolate` nuget package.