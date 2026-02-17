ASP.NET Core supports the dependency injection software design pattern, which is a technique for achieving Inversion of Control (IoC) between classes and their dependencies.

##### Why Code dependencies are problematic and should be avoided?

* To replace MyDependency with a different implementation.
* If MyDependency has dependencies, they must also be configured.
* This implementation is difficult to unit test. 

##### How Dependency injection addresses these problems?

* The use of an interface or base class to abstract the dependency implementation.
* Registration of the dependency in a service container. ASP.NET Core provides a built-in service container, IServiceProvider. Services are typically registered in the app's Startup.ConfigureServices method.
* Injection of the service into the constructor of the class where it's used. The framework takes on the responsibility of creating an instance of the dependency and disposing of it when it's no longer needed.

The container resolves `ILogger<TCategoryName>` by taking advantage of (generic) open types, eliminating the need to register every (generic) constructed type.

## Services injected into Startup

Services can be injected into the Startup constructor and the Startup.Configure method.

Only the following services can be injected into the Startup constructor when using the Generic Host (IHostBuilder):

* IWebHostEnvironment
* IHostEnvironment
* IConfiguration  

## Register groups of services with extension methods
The ASP.NET Core framework uses a convention for registering a group of related services. The convention is to use a single Add{GROUP_NAME} extension method to register all of the services required by a framework feature. For example, the AddControllers extension method registers the services required for MVC controllers.

## Service lifetimes
Services can be registered with one of the following lifetimes:

##### Transient:
* Transient objects are always different.
* Transient lifetime services are created each time they're requested from the service container. This lifetime works best for lightweight, stateless services. Register transient services with AddTransient.
  
##### Scoped:
* Scoped objects are the same for a given request but differ across each new request.
* Scoped lifetime indicates that services are created once per client request (connection). Register scoped services with AddScoped.
In apps that process requests, scoped services are disposed at the end of the request.

##### Singleton:
Singleton lifetime services are created either:
* The first time they're requested.
* By the developer, when providing an implementation instance directly to the container. This approach is rarely needed.

## Disposal of services
The container calls Dispose for the IDisposable types it creates. Services resolved from the container should never be disposed by the developer. If a type or factory is registered as a singleton, the container disposes the singleton automatically.

Services not created by the service container: 
* The service instances aren't created by the service container.
* The framework doesn't dispose of the services automatically.
* The developer is responsible for disposing the services.

## Default service container replacement
The built-in service container is designed to serve the needs of the framework and most consumer apps. We recommend using the built-in container unless you need a specific feature that it doesn't support, such as:

* Property injection
* Injection based on name
* Child containers
* Custom lifetime management
* `Func<T>` support for lazy initialization
* Convention-based registration

  The following third-party containers can be used with ASP.NET Core apps:

* Autofac
* Unity
* Simple Injector


## Types of service containers available in ASP.NET Core?  
There are two type of service container provided by the ASP.net core: 
* Framework Services -The framework services are service that are provided by the ASP.net core such as ILoggerFactory etc.
* Application Services - The application services are the custom services created base on our requirement.

## Inject the dependency to individual action method of the controller.  
Some time, we required dependency to the particular controller action method not to throughout controller. ASP.net core MVC allows us to inject the dependency to particular action using "FromServices" attribute. This attribute tell the ASP.net core framework that parameter should be retrieve from the service container.

```
public class DemoController : Controller
 {
     public IActionResult Index([FromServices] IHelloWorldService helloWorldService)
     {
         ViewData["MyText"] = helloWorldService.SaysHello() + "Jignesh!";
         return View();
     }
 }
```

## Inject the service dependency into the View? 
ASP.net core can also able to inject the dependency to View. This is very useful to inject service related view such as localization. This method will bypass the controller call and fetch data directly from the service. We can inject the service dependency into the view using @inject directive.

`@inject <type> <instance name>`
