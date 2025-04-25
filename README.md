# Movies.Api

Movie API based on a movies dataset [https://www.kaggle.com/datasets/asaniczka/tmdb-movies-dataset-2023-930k-movies]

## Setup

**1. Configure the database connection**

You start by opening the ```appsettings.json``` file located at ```Movies.Api\appsettings.json``` and  update the DefaultConnection string with your SQL Server instance datais: 
```
 "ConnectionStrings": {
    "DefaultConnection":"Data Source=YOUR_PC_NAME\\SQLEXPRESS;Initial Catalog=moviedb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  }
```

**2. Apply the database migrations**

In the terminal, run:
```
 dotnet ef database update
```
**3. Start the application**

To run the API with hot reload:
```
 dotnet watch run
 ```

## Database Schema

![DB Schema](/docs/images/dbschema.png)

## Seed Database
To import our CVS file into the database using the built-in CSV importer, run the following command from the project root:

```
 dotnet run -- --import-csv "file_path"
```

## Endpoints

![Swagger UI](/docs/images/swagger.png)

### Get All
Returns a paginated list of all movies with simplified information. Also allows to search by movie title.
![Get All](/docs/images/getall.png)

### Post
Creates a new movie entry.

### Get by ID
Returns a single movie by its ID with all it's info.
![Get By Id](/docs/images/byid.png)

### Put
Update an existing movie.

### Delete
Deletes a movie by its ID.

