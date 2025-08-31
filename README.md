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