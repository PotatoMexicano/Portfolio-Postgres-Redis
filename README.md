## Portfólio: Console C# + Redis + Postgres

This application was developed solely to apply studies concepts. In it, the following where applied:

### Clean Architecture

Write a code with a simple structure and easy maintenance. Perform the separation of models, database, services and interfaces.

### Postgres

The Postgres was chosen as the database to perform tests involving Redis. I opted for it because it is lightweight and easy to configure in Docker.

### Redis (cache)

Redis was one of the main objects of study in this case, saving values and retieving values from cache.

### Dependency Injection

Dependency Injection was too one of principal study objects, it was applied because I was implemented Clean architecture.

### Docker

Docker was used for create a container for Redis and Postgres, reducing development time and workspace setup configuration. 

## Running

The application is extremely simples, focusing only on understanding the operation and integration between the technologies.

Once the Docker is set up, two containers will be started, one for Postgres, with a table named `Produto` with eight pre-registered items, and another container for Redis.

After firts execution oof the `ConsoleApp` the application will search for IDs of the Products, when found, it will save the product in cache (using Json serializer for convert object to json), its will stay on cache for next 60 seconds.

After second execution of the application, the items will not retrieved from database, but rather from cache formed by first execution, eliminating processing time and time waiting for database response.