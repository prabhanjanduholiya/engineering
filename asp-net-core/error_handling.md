# Handling errors in ASP.NET Core apps
**In how many ways Exception can be handled in ASP.NET Core?**

* Using `Developer exception page` in dev environment
* Using `Exception handler page` or `Exception handler lambda`
* Using `Status code pages`
* Using Exception Filters

**How to handle `Startup exceptions`?**
**How to handle model state errors?**

#### Using `Developer exception page` in dev environment
 
The Developer Exception Page displays detailed information about unhandled request exceptions. ASP.NET Core apps enable the developer exception page by default when running in the Development environment.

The developer exception page runs early in the middleware pipeline, so that it can catch unhandled exceptions thrown in middleware that follows.

The Developer Exception Page can include the following information about the exception and the request:

* Stack trace
* Query string parameters, if any
* Cookies, if any
* Headers

#### Using `Exception handler page` 

#### Using `Exception handler lambda` instead of `Exception handler page` 


#### Using `Status code pages`
