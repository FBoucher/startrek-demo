# Star Trek Demo

This repository contains simple demo .NET 8 projects to show how to use Data API Builder (DAB) to create REST & GrapQL APIs to access data from a SQL Server database, and how to use [Strawberry Shake](https://chillicream.com/docs/strawberryshake) to generate a GraphQL client for different .NET applications. 

Those demos were used in videos and blog posts. 
- Azure Developers .NET Days: 
  - [Auto-Generate and Host Data API Builder on Azure Static Web Apps](https://www.youtube.com/watch?v=GO2R7IW6s3k&list=PLI7iePan8aH4cuFgP9YbRODrSEwXNA8Yq&index=13) 
  - [The most minimal API code of all... none](https://www.youtube.com/watch?v=A1H1kVPHs3w&list=PLI7iePan8aH4cuFgP9YbRODrSEwXNA8Yq&index=15).
  
- [Why and How to Execute GraphQL Queries in .NET](https://devblogs.microsoft.com/dotnet/why-and-how-to-execute-graph-ql-queries-in-dotnet/)
  - To reproduce the demo of this post, you will need to create a file `.env` in the folder [database-api](database-api/) (see the file `.env.sample` for an example) to set the password of the the database user **sa**. Then execute the command `docker-compose up` from that same folder to start the SQL Server database and APIs containers. This should take a moment to download the container images and start everything. Then you can run follow the instructions of the post to build the .NET Console Application.


## How to run

### Prerequisites

- Docker with Docker Compose
- .NET 8 SDK

### Start the database and APIs

1. Create `.env` in [database-api/](database-api/) from `.env.sample`, with `SA_PWD=<password>`.
2. Run `docker-compose up` in [database-api/](database-api/).

This starts the GraphQL API at `http://localhost:5000/graphql` and REST API at `http://localhost:5000/api`.

### Run the console app

1. Run `dotnet run` in [src/console/](src/console/).

### Run the Blazor WebAssembly app

1. Run `dotnet run` in [src/startrek-wasm/](src/startrek-wasm/).

Open `http://localhost:5188`.

### Run the chocoSpock API

1. Set `SA_PWD` to the database password.
2. Run `dotnet run` in [src/chocoSpock/](src/chocoSpock/).

The GraphQL API is at `http://localhost:5041/graphql`.

### Run the Blazor website app

1. Run `dotnet run` in [src/web/](src/web/) with the chocoSpock API running.

Open `http://localhost:5037`.

## The different demos

### Database and APIs in Containers

The folder [database-api](database-api/) contains a simple `docker-compose up` that deploys an SQL Server in a first container and Data API Builder (DAB) in a second one. When the database container starts, it runs automatically a SQL script `startrek.sql` to create the database tables and populate the Star Trek tables. Finally the DAB container starts and connects to the SQL Server database to expose a REST API and a GraphQL API.

To run it locally, create a file `.env` in the folder [database-api](database-api/) (see the file `.env.sample` for an example) to set the password of the the database user **sa**. Then execute the command `docker-compose up` from that same folder to start the SQL Server database and APIs containers. This should take a moment to download the container images and start everything. The GraphQL API will be available at `http://localhost:5000/graphql`.

### Simple .NET Console App using GraphQL

The folder [src/console/](src/console/) contains a console application the uses the GraphQL client generated with the StrawberryShake package to query the GraphQL API exposed by DAB. The application is a simple console application that queries the GraphQL API to get the list of Star Trek characters by series. To run it locally you need to have the [database and APIs](#database-and-apis-in-containers) containers running.

### Blazor WebAssembly App using GraphQL and QuickGrid

The folder [src/startrek-wasm/](src/startrek-wasm/) contains a Blazor WebAssembly website to demonstrate how to use GraphQL with QuickGrid. The website uses the generated component and client, using the StrawberryShake.Blazor package to query the GraphQL API to display the list of Actors. A second page shows how to use QuickGrid with the `virtualize` feature to display a large list of actors. To run it locally you need to have the [database and APIs](#database-and-apis-in-containers) containers running.


### Blazor website App using GraphQL and QuickGrid (same as above but with a server-side Blazor)

The folder [src/web/](src/web/) contains a Blazor website to demonstrate how to use GraphQL with QuickGrid. The website uses the generated component and client, using the StrawberryShake.Blazor package to query the GraphQL API to display the list of Actors. A second page shows how to use QuickGrid with the `virtualize` feature to display a large list of actors. To run it locally you need to have the [chocoSpock](#chocospock-is-a-custom-graphql-endpoint) GraphQL API running.

### chocoSpock is a custom GraphQL endpoint

The folder [src/chocoSpock/](src/chocoSpock/) contains a simple GraphQL endpoint that implements the required `skip` and `take` arguments to allow virtualization with Blazor QuickGrid. The minimal API uses `HotChocolate` nuget package.

To run it locally, you need to have the startrek database up and running. Create a file `.env` in the folder [database-api](database-api/) (see the file `.env.sample` for an example) to set the password of the the database user **sa**. Then execute the command `docker-compose up` from that same folder to start the SQL Server database and APIs containers. This should take a moment to download the container images and start everything.

Now that the database is running, you can start the chocoSpock API by running the command `dotnet run` in a second terminal from the folder [src/chocoSpock/](src/chocoSpock/). The GraphQL API will be available at `http://localhost:5041/graphql`.