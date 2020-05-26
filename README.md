# NetLabGamesProject

The project was made to learn basic things in WebApi, Asp.Net MVC Framework, .Asp.Net MVC Core and Entity Framework Core. It contains simple entities like 'Game', 'Award' and 'Review' which are stored in In-Memory or Database repositories, and are accessed by the corresponding services. In the first stage the usage was provided by Web API (which I tested by the Postman application), then .Net MVC Core was added. I didn't work much on the .Net MVC Framework version and added it just to remember difference in file structures and to try non-built-in(like in the Core) Dependency Injection, Ninject in that case. In the WebApi project there's also used a cache with the help of IMemoryCache interface. In the main project - MVC Core - asynchronous methods are provided for the EntityFramework Data Access.

p.s. The project may contain some conceptual errors which I don't undestand yet, but I will do my best to learn better practices in future projects.
