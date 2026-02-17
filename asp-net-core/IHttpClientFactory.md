
# [HTTP requests using `IHttpClientFactory`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0)

* An IHttpClientFactory can be registered and used to configure and create HttpClient instances in an app. 
* IHttpClientFactory provides a central location for naming and configuring logical HttpClient instances.
* A new HttpClient instance is returned each time CreateClient is called

### Problems with `HttpClient`

### Consumption patterns (Ways IHttpClientFactory can be used in an app)

* Basic usage
* Named clients
* Typed clients
* Generated clients

### Outgoing request middleware
HttpClient has the concept of delegating handlers that can be linked together for outgoing HTTP requests.

### Can be integrated with `Polly-based handlers` for resiliency and transient fault-handling
Polly is a comprehensive resilience and transient fault-handling library for .NET. 
It allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner.

* Dynamically select policies like for get requests POLICY A and for Other http methods RETRY POLICY B.
* Add multiple Polly handlers
* Add policies from the Polly registry

### Propagate HTTP headers from the incoming request to the outgoing HttpClient requests using `Header propagation middleware`

Header propagation is an ASP.NET Core middleware to propagate HTTP headers from the incoming request to the outgoing HttpClient requests. 

To use header propagation:
* Install the Microsoft.AspNetCore.HeaderPropagation package.
* Configure the HttpClient and middleware pipeline in Program.cs:

```
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddHttpClient("PropagateHeaders")
    .AddHeaderPropagation();

builder.Services.AddHeaderPropagation(options =>
{
    options.Headers.Add("X-TraceId");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseHeaderPropagation();

app.MapControllers();
```
