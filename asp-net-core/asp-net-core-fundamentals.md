# ASP.NET Core
ASP.NET Core is a cross-platform, high-performance, open-source framework for building modern, cloud-enabled, Internet-connected apps. 

##### Why choose ASP.NET Core?
* A common framework for building web UI and web APIs.
* Designed for testability.
* Cross platform devlopment and deployment.
* Built-in dependency injection.
* A cloud-ready, environment-based configuration system.
* Ability to host on Kestrel, IIS, HTTP.sys, Nginx, Apache, Docker
* Razor Pages makes coding page-focused scenarios easier and more productive.
* Support for hosting Remote Procedure Call (RPC) services using gRPC.

##### What is Metapackage? 
AspNetCore package is repeatedly included as one of the usual project dependencies when opening a new ASP.NET Core project. ... By adding this package to your project, you bring in all the relevant packages along with their dlls on which it depends and it is called a metapackage. 

##### Can ASP.NET Core application work with full NET x Framework? 
The only benefit you don't have if you choose the full .NET framework over .NET Core is being cross platform. All the other benefits of deployment, modularization, docker, performance, etc... are still valid.

##### When to choose Asp.Net vs Asp.Net Core?

# Start Up
### Program.cs
The Program.cs file is where 
* Services required by the app are configured.
* The app's request handling pipeline is defined as a series of [middleware components](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-7.0).

###### * What are the types that can be injected into startup class constructor?
* IConfiguration
* IHostEnvironment
* IWebHostEnvironment

Note: Most services are not avilable until configure method is called.

###### * How to specify multiple start up files based on the environments like PROD, DEV, TEST etc?
* Using suffix of environment types

###### * How to configure services without startup file?
Call ```ConfigureServices``` and ```Configure``` methods on the host builder.
* Multiple ```ConfigureServices``` method calls append to one another.
* Multiple ```Configure``` method, the last configure method call is used.

### Extend Startup with startup filters (What is use of ```IStartupFilter``` interface?)

Provides an interface for extending the middleware pipeline with new Configure methods. Can be used to add defaults to the beginning or end of the pipeline without having to make the app author explicitly register middleware.

* `IStartupFilter` implements Configure, which receives and returns an `Action<IApplicationBuilder>`. 
* An `IApplicationBuilder` defines a class to configure an app's request pipeline. 
    
Each IStartupFilter can add one or more middlewares in the request pipeline. The filters are invoked in the order they were added to the service container. 
Filters may add middleware before or after passing control to the next filter, thus they append to the beginning or end of the app pipeline. 

Middleware execution order is set by the order of IStartupFilter registrations:
* Multiple IStartupFilter implementations may interact with the same objects. If ordering is important, order their `IStartupFilter` service registrations to match the order that their middlewares should run.
* Libraries may add middleware with one or more IStartupFilter implementations that run before or after other app middleware registered with IStartupFilter. To invoke an IStartupFilter middleware before a middleware added by a library's IStartupFilter:
  * Position the service registration before the library is added to the service container.
  * To invoke afterward, position the service registration after the library is added.
    
Example. [[see here](../Articles/Extending_Your_Startup_Class_using_IStartupFilter.md)]

###### What is use of ```IStartupFilter``` interface?
https://andrewlock.net/exploring-istartupfilter-in-asp-net-core/
https://www.linkedin.com/pulse/thats-good-know-asp-net-core-ali-rezazadeh    
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-3.1#extend-startup-with-startup-filters
https://sourceexample.com/istartupfilter-in-asp.net-core-validates-settings-when-app-launches-39948/


# Dependency Injection: 
ASP.NET Core includes [dependency injection (DI)](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-7.0) that makes configured services available throughout an app. Services are added to the DI container with [WebApplicationBuilder.Services](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.webapplicationbuilder.services#microsoft-aspnetcore-builder-webapplicationbuilder-services), builder.Services.

# Middleware
The request handling pipeline is composed as a series of middleware components. Each component performs operations on an [HttpContext](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-context?view=aspnetcore-7.0) and either invokes the next middleware in the pipeline or terminates the request.

# Host

# Servers
An ASP.NET Core app uses an HTTP server implementation to listen for HTTP requests. The server surfaces requests to the app as a set of [request features](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/request-features?view=aspnetcore-7.0) composed into an HttpContext.

ASP.NET Core provides the following server implementations:
* Kestrel is a cross-platform web server. Kestrel is often run in a reverse proxy configuration using [IIS](https://www.iis.net/). In ASP.NET Core 2.0 or later, Kestrel can be run as a public-facing edge server exposed directly to the Internet.
* IIS HTTP Server is a server for Windows that uses IIS. With this server, the ASP.NET Core app and IIS run in the same process.
* HTTP.sys is a server for Windows that isn't used with IIS.

By convention, a middleware component is added to the pipeline by invoking a Use{Feature} extension method.

# Configuration

SP.NET Core provides a [configuration](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0) framework that gets settings as name-value pairs from an ordered set of configuration providers. Built-in configuration providers are available for a variety of sources, such as .json files, .xml files, environment variables, and command-line arguments. Write custom configuration providers to support other sources.

By [default](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0#default), ASP.NET Core apps are configured to read from appsettings.json, environment variables, the command line, and more. When the app's configuration is loaded, values from environment variables override values from appsettings.json.

# Environments
Execution environments, such as Development, Staging, and Production, are available in ASP.NET Core. Specify the environment an app is running in by setting the ASPNETCORE_ENVIRONMENT environment variable. ASP.NET Core reads that environment variable at app startup and stores the value in an IWebHostEnvironment implementation. This implementation is available anywhere in an app via dependency injection (DI).

# Logging
ASP.NET Core supports a logging API that works with a variety of built-in and third-party logging providers. Available providers include:

* Console
* Debug
* Event Tracing on Windows
* Windows Event Log
* TraceSource
* Azure App Service
* Azure Application Insights

To create logs, resolve an [ILogger<TCategoryName>](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1) service from dependency injection (DI) and call logging methods such as [LogInformation](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loggerextensions.loginformation).

# Routing
A route is a URL pattern that is mapped to a handler. The handler is typically a Razor page, an action method in an MVC controller, or a middleware. ASP.NET Core routing gives you control over the URLs used by your app.

# Error handling
ASP.NET Core has built-in features for handling errors, such as:

* A developer exception page
* Custom error pages
* Static status code pages
* Startup exception handling

# Make HTTP requests
An implementation of IHttpClientFactory is available for creating HttpClient instances. The factory:

* Provides a central location for naming and configuring logical HttpClient instances. For example, register and configure a github client for accessing GitHub. Register and configure a default client for other purposes.
* Supports registration and chaining of multiple delegating handlers to build an outgoing request middleware pipeline. This pattern is similar to ASP.NET Core's inbound middleware pipeline. The pattern provides a mechanism to manage cross-cutting concerns for HTTP requests, including caching, error handling, serialization, and logging.
* Integrates with Polly, a popular third-party library for transient fault handling.
Manages the pooling and lifetime of underlying HttpClientHandler instances to avoid common DNS problems that occur when managing HttpClient lifetimes manually.
* Adds a configurable logging experience via [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) for all requests sent through clients created by the factory.

# Content root
The content root is the base path for:
* The executable hosting the app (.exe).
* Compiled assemblies that make up the app (.dll).
* Content files used by the app, such as:
* Razor files (.cshtml, .razor)
* Configuration files (.json, .xml)
* Data files (.db)



# Web root
The web root is the base path for public, static resource files, such as:

* Stylesheets (.css)
* JavaScript (.js)
* Images (.png, .jpg)
By default, static files are served only from the web root directory and its sub-directories. The web root path defaults to {content root}/wwwroot. Specify a different web root by setting its path when [building the host](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-7.0&tabs=windows#host). For more information, see [Web root](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-7.0#webroot).


## Model Binding and Model Validation

Model binding automatically maps data from HTTP requests to action method parameters.
Model validation automatically performs client-side and server-side validation.

#### Response compression in ASP.Net core 
Network bandwidth is a limited resource. Reducing the size of the response usually increases the responsiveness of an app, often dramatically. One way to reduce payload sizes is to compress an app's responses
https://docs.microsoft.com/en-us/aspnet/core/performance/response-compression?view=aspnetcore-6.0

#### How can we do response compression in ASP.NET core? 
https://docs.microsoft.com/en-us/aspnet/core/performance/response-compression?view=aspnetcore-6.0
