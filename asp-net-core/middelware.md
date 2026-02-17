Middleware is software that's assembled into an app pipeline to handle requests and responses. 

Each component:
* Chooses whether to pass the request to the next component in the pipeline.
* Can perform work before and after the next component in the pipeline.

#### How to add middleware to the application request pipeline?
#### How can we configure the pipeline for middleware?
* `Request delegates` are used to build the request pipeline. The request delegates handle each HTTP request.
* Request delegates are configured using Run, Map, and Use extension methods. 
* When a delegate doesn't pass a request to the next delegate, it's called short-circuiting the request pipeline. 


#### Use delegate: (What is the difference between IApplicationBuilder.Use() and IApplicationBuilder.Run()?)
* Chain multiple request delegates together with Use. The next parameter represents the next delegate in the pipeline. 
* You can short-circuit the pipeline by not calling the next parameter. You can typically perform actions both before and after the next delegate, as the following example demonstrates:

```
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    // Do work that doesn't write to the Response.
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from 2nd delegate.");
});

app.Run();
```
#### Run delegate:
* Run delegates don't receive a next parameter. The first Run delegate is always terminal and terminates the pipeline. 
* Run is a convention. Some middleware components may expose Run[Middleware] methods that run at the end of the pipeline:

```
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    // Do work that doesn't write to the Response.
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from 2nd delegate.");
});

app.Run();

```
#### Branch the middleware pipeline using `Map` delegate (What is the use of "Map" extension while adding middleware to ASP.NET Core pipeline?)
* Map extensions are used as a convention for branching the pipeline. 
* Map branches the request pipeline based on matches of the given request path. If the request path starts with the given path, the branch is executed.

```
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/map1", HandleMapTest1);

app.Map("/map2", HandleMapTest2);

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from non-Map delegate. <p>");
});

app.Run();

static void HandleMapTest1(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test 1");
    });
}

static void HandleMapTest2(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test 2");
    });
}
```

### Middleware order: 
#### What is the default order of invoking middleware on requests pipeline?
#### What are built-in middleware(s) available with ASP.NET Core?
Middleware components are executed in the order they are added to the pipeline and care should be taken to add the middleware in the right order otherwise the application may not function as expected. This ordering is critical for security, performance, and functionality.
![2](https://user-images.githubusercontent.com/31764786/143410274-42ccfcc4-80f8-4f00-9192-60b393c29167.png)

#### What is the use of "MapWhen" extension while adding middleware to ASP.NET Core pipeline?
#### How can you write custom middleware?


https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0
###### What is the difference between Middleware and HttpModule

### Rate Limiting Middleware
https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?view=aspnetcore-8.0
