# Learn ASP.NET Core Web API Project

This project is a guide to learning the basic and advanced concepts of ASP.NET Core Web API. The topics are ordered from simple to complex. You can check the commit of any subject to see code modifications done for that subject.

## 1. Controllers and Actions

In ASP.NET Core Web API, a **controller** is a class that handles incoming HTTP requests and sends back responses. Each public method in a controller is called an **action**. When the application receives a request, it routes it to an action on a specific controller. The action then performs some logic and returns a response.

Controllers are typically placed in the `Controllers` folder and inherit from the `ControllerBase` class. The `[ApiController]` attribute provides features to make building web APIs more convenient.

Commit: https://github.com/csokmen/learn-asp.net-core-web-api/commit/b695a5ad6dd55c11de5623d77e79c4ced5288052

## 2. Routing

Routing is the mechanism that maps incoming HTTP requests to controller actions. ASP.NET Core uses middleware to examine the URL of a request and match it to a predefined route template.

-   **`[Route("api/[controller]")]`**: This is an attribute placed on the controller. It defines a template for all routes within that controller. The `[controller]` token is a placeholder that is replaced with the controller's name (e.g., "Simple" for `SimpleController`).
-   **`[HttpGet]`, `[HttpPost]`, etc.**: These are HTTP method attributes that specify which HTTP verb an action will respond to.
-   **Route Parameters**: You can define parameters in your route templates, such as `[HttpGet("{id}")]`. This allows you to capture values from the URL and use them in your action methods.

Commit: https://github.com/csokmen/learn-asp.net-core-web-api/commit/168f2a19b7aefce39734a3251d3198461aa6fecd

## 3. Action Results

Action results are the return types of controller actions. They are responsible for generating the HTTP response. While an action can return a simple type or object (which ASP.NET Core wraps in a 200 OK response), using `ActionResult` provides more control.

-   **Specific Action Results**: Methods like `Ok()`, `NotFound()`, `BadRequest()`, and `CreatedAtAction()` return specific HTTP status codes. For example, `NotFound()` produces a 404 status code.
-   **`ActionResult<T>`**: This return type allows an action to return either a specific type `T` (which results in a 200 OK) or any other action result. This provides type safety for your API's response while maintaining flexibility.

Commit: https://github.com/csokmen/learn-asp.net-core-web-api/commit/5ce6b6514c570a69e38ecb6a7f2a3eee39af57be

## 4. Model Binding

Model binding is the process where ASP.NET Core automatically maps data from an HTTP request to the parameters of an action method. This allows you to work directly with strongly-typed objects.

-   **`[FromBody]`**: For a `[HttpPost]` or `[HttpPut]` request, the `[FromBody]` attribute tells the framework to deserialize the request body (typically JSON) into a complex object. With the `[ApiController]` attribute, `[FromBody]` is often inferred for complex type parameters.
-   **`[FromRoute]`**, **`[FromQuery]`**: These attributes explicitly specify that a parameter should be bound from the route or the query string, respectively.

When you create a `POST` action that takes a `Product` object as a parameter, the framework handles the work of converting the incoming JSON into a `Product` instance for you.

Commit: https://github.com/csokmen/learn-asp.net-core-web-api/commit/c505ddea1df12dbfb7fa14a90878f38ea44c2ce2

## 5. Dependency Injection

Dependency Injection (DI) is a design pattern used to achieve Inversion of Control (IoC). Instead of a component creating its own dependencies, the dependencies are "injected" from an external source. ASP.NET Core has a built-in DI container.

-   **Service Lifetime**: When registering a service, you define its lifetime:
    -   **Singleton**: A single instance is created for the entire application lifetime.
    -   **Scoped**: A new instance is created for each client request (connection).
    -   **Transient**: A new instance is created every time it is requested.
-   **Usage**: We will create an interface (`IProductService`) and a concrete implementation (`ProductService`). We then register the service in `Program.cs` and inject the interface into our controller's constructor. This decouples the controller from the specific data implementation.

Commit: https://github.com/csokmen/learn-asp.net-core-web-api/commit/07a339c5e7297f4490bcd66e3263f857e41d3150

## 6. Using Entity Framework Core

To persist data, we use Entity Framework (EF) Core. It's an object-relational mapper (O/RM) that simplifies database interactions.

-   **`DbContext`**: This class represents a session with the database and is used to query and save data. You create a class that inherits from `DbContext` and contains `DbSet<T>` properties for each entity (table) in your model.
-   **In-Memory Database**: For development and testing, EF Core can use an in-memory database. This is useful because it doesn't require setting up a real database server.
-   **Async Operations**: Database operations are I/O-bound and should be performed asynchronously using `async` and `await` to avoid blocking threads. This means our service and controller methods will return `Task<T>`.

Commit: https://github.com/csokmen/learn-asp.net-core-web-api/commit/f566f04b543de1e55f9cc5bd2c5d0a6c99f87e3a

## 7. Adding Dapper for High-Performance Data Access

To complement our EF Core implementation, we will add a new controller that uses **Dapper**, a high-performance micro-ORM. This allows for direct execution of raw SQL queries, which can be beneficial for performance-critical operations.

-   **New Controller**: A `DapperProductsController` will be created to handle requests using Dapper.
-   **Dapper Context**: A separate context class will manage the database connection for Dapper.
-   **Separate Service**: To maintain a clean architecture, a new service layer (`IDapperProductService` and `DapperProductService`) will be created specifically for Dapper-based operations.

Commit: https://github.com/csokmen/learn-asp.net-core-web-api/commit/183736116839aff27cc183e94334b1240d4b7c33

## 8. DTOs and Manual Mapping

A **Data Transfer Object (DTO)** is an object that carries data between processes. In Web APIs, we use DTOs to shape the data that is sent to and from the client. This decouples our internal database models from the public API contract.

-   **Manual Mapping**: Instead of using a library like AutoMapper, we will perform the object-to-object mapping manually. This can be done with simple methods or directly within the controller and service layers.
-   **Controller Update**: The `DapperProductsController` will be updated to receive and return DTOs, while the service layer will handle mapping from DTOs to the internal `Product` entity.

Commit: https://github.com/csokmen/learn-asp.net-core-web-api/commit/a67eccb3534dbddefac935b4e87ce6de9c895fae

## 9. Handling PUT and DELETE Requests

To complete our CRUD (Create, Read, Update, Delete) functionality, we need to handle `PUT` and `DELETE` requests.

-   **`[HttpPut("{id}")]`**: This attribute is used for update operations. A `PUT` request should contain the full updated resource. The action typically returns `NoContent()` (204) on success, `BadRequest()` if the URL ID and body ID don't match, or `NotFound()` if the resource doesn't exist.
-   **`[HttpDelete("{id}")]`**: This attribute is used for delete operations. The action takes the ID of the resource to delete and returns `NoContent()` (204) on success or `NotFound()` if the resource doesn't exist.
-   **Update DTO**: It's good practice to use a specific DTO for update operations (e.g., `UpdateProductDto`) to control which fields can be modified.

Commit: https://github.com/csokmen/learn-asp.net-core-web-api/commit/68b5a7cc9827341ba002ca14be0d72701301b3b4
