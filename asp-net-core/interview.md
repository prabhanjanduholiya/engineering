# ASP.NET Core interview questions 
* What is the ASP.NET Core? 
* What are the features provided by ASP.NET Core? (Explain the advantages of ASP.NET Core over ASP.NET) 
* What is CoreCLR?  
* Where project static files are stored in ASP.NET Core?  
* Does ASP.NET Core support response compression?  a
* How can we do response compression in ASP.NET core? 
* Validate settings when app launches 
* What is Metapackages? 
* Can ASP.NET Core application work with full NET x Framework? 

#### Startup Class
* What is the use of the startup class in ASP.NET core? 
* What is the use of ConfigureServices method of startup class? 
* What is the use of the Configure method of startup class? 
* Can we configure service and request pipeline without defining Startup class?  

#### Middleware 
* What is middleware? 
* How to add middleware to the application request pipeline? 
* What is the difference between IApplicationBuilder.Use() and IApplicationBuilder.Run()? 
* What is the use of "Map" extension while adding middleware to ASP.NET Core pipeline? 
* What is the use of "MapWhen" extension while adding middleware to ASP.NET Core pipeline? 
* Wow can we configure the pipeline for middleware?  
* What is built-in middleware(s) available with ASP.NET Core? 
* Wow can you write custom middleware? 
* What is the default order of invoking middleware on requests pipeline?  
* Does Static File Middleware compress the static files?  
* What is the difference between Middleware and HttpModule 

#### Dependency Injection  
* How does dependency injection work in ASP.NET Core?  
* How many types of service containers available in ASP.NET Core?  
* How can we inject the service dependency into the controller? 
* Can we inject the dependency to individual action method of the controller?  
* Can we get a service instance without dependency injection in the controller action method? 
* How to specify a service life for register service that added as a dependency?  
* How can we inject the service dependency into the View? 
* What point you will be taken care while creating service for DI? 

#### Servers 
* What are the different techniques for hosting an ASP.NET Core application? 
* What is Kestrel? 
* What are advantages of Kestrel over HTTP.sys:
* How to add Kestrel server in ASP.NET Core application?  
* Can we bind TCP socket with Kestrel server? 
* What is HTTP.sys server? 
* What are the features are supported by HTTP.sys server? 
* How to host an application using HTTP.sys server? 
* How to host ASP.NET Core application as a Windows service?  
* What is ASP.NET Core Module?  

#### Filters in ASP.NET Core 
* What is the use of a filter in ASP.NET Core application? 
* Explain about the filter types available in ASP.NET Core application  
* In which sequence all the filters are invoked?  
* How can we create a custom filter in ASP.NET Core? 
* Does the filter support asynchronous implementation?  
* How to implement the asynchronous filter in ASP.NET Core?  
* Explain about the Filter scope?  
* How to define filter at Global level in ASP.NET Core? 
* What is the Default order of filter execution?  
*  Can we override the default order of execution of filter in ASP.NET Core?  
*  Does the built-in filter also implement the interface IOrderFilter?  
*  Can we cancel the execution of filter or short-circuiting filters? 
*  Can we inject the dependency to the filter attribute? 
*  Can you apply a filter attribute having constructor dependency to the controller or action? 
*  What is exception filter in ASP.NET Core?  
*  What is a limitation of Exception filter? 
*  How the exception filter differs from an action filter?  
*  What kind of exception can be catch using exception filter?  
* What is the use of Result Filter in ASP.NET Core? 

#### Security
*  What are Authentication and Authorization? 
*  How can we configure built-in identity service for ASP.NET Core application? 
*  What is the difference between AddIdentity and AddDefaultIdentity?  
*  How can we override default configuration for Identity? 
*  How can we configure windows authentication in ASP.NET Core application?  
*  How can we enforce Https for all requests in ASP.NET Core?  
* Is there any alternative approach for enforcing Https other than injecting middleware? 
* How can we enable CORS in ASP.NET core app?  
* How to prevent ASP.NET Core app from Cross-Site Request Forgery (CSRF)?  


#### Routing  
* What is routing in the ASP.NET Core? 
* How can we configure conventional routing? 
* What's happened MVC find two disambiguating actions through routing? 
* What is Attribute routing?  
* Does ASP.NET Core support mix routing ie both conventional and attribute routing together? 
* How can we define a route for areas?  
* How attribute routing work with Http[Verb] attribute? 
* What is route constraint and what is the use of it?  
* Is it recommended to use route constraints for input validation?  
* What are built-in constraints supported by ASP.NET Core MVC? 
* Can we define multiple route constraints for a route parameter? 
* Can we create custom route constraints? 
* Can we use ASP.NET core reserved keywords as route names? 
* What is endpoint routing? 
* How endpoint routing differs from earlier versions of routing? 
* Can we define multiple routes for single action? 

#### Session and Environment Settings 
* How can we enable Session in ASP.NET Core? 
* How many types of session state is supported by ASP.NET Core?  
* How to access the session in ASP.NET Core application?  
* Why Session is stored in the form of byte array in ASP.NET Core?  
* Is there any sequence to call UseSession() method in the Configure method?  
* Can we store the Complex data into the session?  
* How does ASP.NET core track user session? 
* Can we change the name of the cookie used for the session?  
* How can we maintain the app state in ASP.NET core?  
*  How can we set an environment variable?  
*  Key for environment variable is case-sensitive?  
*  How determine the value of an environment variable programmatically? 
*  What are the various JSON files available in ASP.NET Core?  
*  What is the use of “launchsettingsjson” file?  
*  What is the use of "appsettingsjson" file?  
*  What is the use of "bowerjson" file? 

#### Areas and Tag Helpers  
* What is Area in ASP.NET Core?  
* Do nested areas are supported by ASP.NET Core?  
* How to generate links for controller action under the area?  
* How to generate links for controller action under the area using tag helper? 
* How can we add Area to ASP.NET Core application? 
* How to associate the controller with an Area? 
* Can we change folder name "Areas" to any other name? 
* Explain about tag helper in ASP.NET Core? 
* What are the advantages of tag helper? 
*  What is different between HTML helper and Tag helper? 
*  How to add supports for Tag Helper to Razor view?  
*  Can we disable Tag Helper at element level? 
*  Can we specify the prefix for tag helper? 
*  Can we enable directory browsing through the code in ASP.NET Core?  
*  What is the use of "UseFileServer" in Configure method of startup class?  
*  What are built-in tag helpers provided with ASP.NET Core?  

#### Razor Pages and View Component 
* What are the Razor Pages in ASP.NET Core?  
* How can we prevent Razor pages from XSRF/CSRF attack?  
* How can we enable Razor pages for ASP.NET core app?  
* What is the handler method in Razor pages?  
* What are the handler methods available with Razor pages?  
* How can we do an automatic model binding in Razor pages? 
* How can we be binding the route data in Razor pages? 
* What is the use of ViewData attribute in Razor pages? 
* How can we apply filters in Razor pages?  
*  What is the RCL (Razor Class Library) project? 
*  What happened if view, partial view, or Razor Page found in both RCL and web application?  
*  What is the view component in ASP.NET Core? 
*  What are the features provided by the ViewComponent? 
*  How can we create ViewComponent?  
*  What is the default path of view for ViewComponent?  
*  Can we have invoked view component from the controller? 

#### Model Binding and Validations 
* What is Model binding? 
* How does model binding work in ASP.NET Core application?  
* What are the characteristics for complex type for binding the value? 
* Can we control the behaviour of Model binding using attribute? 
* Can we create a custom model binder? If yes how? 
* How can we use/register custom model binder in ASP.NET core? 
* How can apply custom model binder using ModelBinder attribute?  
* How can we register a custom model binder globally?  
* What is the use of BindProperty and BindProperties attribute?  
*  What happened when “SupportsGet” property of BindProperty attribute is set to true?  
*  How can we do model validation with ASP.NET Core?  
*  How can we check our model is valid or not at the controller level?  
*  Which part of the MVC framework responsible to set IsValid property of ModelState class?  
*  Can we validate the model manually in Controller class? 
*  How can we do Client-side validation?  

*  What are built-in validation attributes provided with ASP.NET Core?  
*  How can we create a custom validation attribute?  
*  How can we disable client-side validation? 

####  Globalization and Localization  
* What is Internationalization in ASP.NET Core?  
* What is a resource file naming convention?  
* How can we achieve localization in view?  
* How can we access a localized resource string in Controller?  
* Can we localize error messages defined in Data Annotation? 
* How does culture fallback mechanism work in ASP.NET Core? 
* What happens when resource not found in a culture resource file?  
* How can we return the resource key when resource not found in culture file?  
* Can we add Content-Language header With ASP.NET core? If yes, how? 
*  What is Neutral culture?  

#### Exception Handling and Logging Framework  
* What is "Developer Exception Page" in ASP.NET Core? 
* How can we configure custom exception handling page in ASP.NET Core? 
* Can we define custom exception without using defining error page?  
* How to configure the logging framework in ASP.NET Core? 
* What are the possible values for Log level enum for the Logging framework? 
* How many built-in extension methods provided by the logging framework of ASP.NET Core?  
* What is the use of enum value LogLevelNone?  
* How to set default minimum log level for Logging Framework?  
* How to define filter rule for the Logging framework in ASP.NET Core?  
*  What is log scope in the Logging framework? 
*  What are third party logging frameworks supported by ASP.NET Core? 
*  What are built-in logging providers supported by ASP.NET Core?  



#### Unit Testing  
* What Unit Testing frameworks can be used with ASP.NET Core?  
* How can we write a unit test with the MSTest framework? 
* Can we create an MSTest project using command line interface (CLI)? 
* How can we verify the test in MSTest?  
* How to run the unit test?  
* Can we write a data-driven test using MSTest? 
* How can we write a unit test with xUnit framework?  
* How can we verify the test in xUnit? 
* Can we write a data-driven test using xUnit?  
*  How can we write a unit test with NUnit framework? 
*  How can we verify the test in NUnit? 
*  Can we write a data-driven test using NUnit? 
*  What is the use of setup attribute in NUnit framework? 
*  How can we create a test for the controller that has service dependency?  
*  What is a Mock (or moq) object in a unit test? 
*  What are the Integration tests?  
*  How Integration tests different from a unit test? 
*  What is the load test and stress test?  
*  What are the tools used for web performance testing? 

# API/WebAPI/Microservice
* What is difference between SOAP vs REST Services?
* Difference between Claims and Roless?
* What are Six architectural constraints of REST?
* How we can achieve security in Web API?
* Features of Web API?
* Versioning in Web API?
* What is the mean by Stateless in Web API?
* Difference between RequestContext vs HttpContext
* How we can apply Dependency Injections in web api.
* Idempotent in apis
* PUT and PATCH in Web API
* Model Binders in WEB API
* Model Validations in WEB API
* Content negotiation 
* what is OData, OpenId and OAuth
* Rest Constrains discussion
* WebAPI Caching
* Model Binders
* Authentication types and flow 
* Different HTTP Verbs uses and limitations
* HTTP Response status codes and categories
* Difference between 400 and 500 series of HTTP response code.
* How to pass complex object in GET Request. fromuri, fromquery, typeconverter, modelbinder
* Message handler, its use and how to create custom message handler
* Action Result in MVC vs API
* Difference between rest and soap service
* Web api filters
* How we can make complex type to simple type i.e. I don't want to use [FromUri] attribute.
*  : We will make TypeConverter for that class and provide as attribute to class. After this class will be treated as simple type and don't need to use [FromUri] attribute.
* How to Enable Cors?
* Web api vs mvc
* get and post calls to controller
* Microservices – implementation
* Microservice SAGA pattern
* Asp.net MVC Life Cycle
* Action Filters 
* Global Exception Handling
* MVC Routing
* Authorization and Authentication in MVC
* What are Action Methods, Child action methods
* What are Partial Views
* Action Result Types
* Security Concepts (OWASP)
* How to enable Get/Put/Post in IIS.

# MVC:
* Exception filter in MVC
* MVC lifecycle
* Diff between Html.BeginForm vs @Ajax.BeginForm
* Auth vs Autherization
* How we can apply Dependency Injections in MVC architecture.
* Child Action
* How to redirece request direct to view instead on controller
* Ans: services.AddRazorPages(); endpoint.MapRazorPages();
* Action method having Parent Object(Employee) as parameter and in ajax call child type is passed.
* Would action be called.
  If called what will happen to extra properties, how to pass extra properties in such scenarios.
* Can we have two form elements in HTML Page.
* div vs span

# Fundamental interview questions.

#### What is Swagger?  
## What are REST and SOAP?

https://restfulapi.net/http-methods/

#### How would you store passwords in your application for users?
#### What is hashing approach for storing passwords and what are the issues in it?
#### How to overcome drawback of `Hashing` approach of storing passwords?
#### What is `Hashing and salting the passwords?`

---------------------------------------------------------------------------------
## CORS - Cross Origin resource sharing
CORS is a browser security feature that restricts cross origin resource sharing. 

##### What qualifies a CORS request? 
* A different domain
* A different sub domain
* A different port
* A different protocol

##### How cross oriin resource sharing origin works?
* Before making actual HTTP call, browser makes a preflight call with OPTIONS request.
* Server responds back with some HTTP headers about resouces that can make requests and what HTTP calls are suppprted like 'GET', 'PUT'
* Browser verifies and makes actual call.



