I have developed an API, which handles SMS sending to three different vendors. It consists of one endpoint, which routes the incoming message to the appropriate vendor, based on its input. The API also persists  all messages delivered to an MSSQL server.
Technology and design patterns used:

- Polymorphism
- Dependency Injection
- Repository Pattern
- AutoMapper
- Entity Framework Core
