# Learn ASP.NET Core Web API Project

This project is a guide to learning the basic and advanced concepts of ASP.NET Core Web API. The topics are ordered from simple to complex. You can check the commit of any subject to see code modifications done for that subject.

This project is deployed. You can visit it at: https://learn-asp-net-core-web-api.azurewebsites.net/swagger/index.html

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
