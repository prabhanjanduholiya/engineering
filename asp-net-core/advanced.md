
### Performance
* [Response Compression](performance/Response_Compression.md)
* Health Check

### OWIN - Open web interface for .Net
OWIN is short form for Open Web Interface for .NET. It is not a framework, but rather a specification that belongs to the community. OWIN proposes a simple delegate structure to help decouple web servers and applications through an interface specification.

###### Application Server Dependencies in ASP.NET
ASP.NET has huge dependence on IIS. This limits the deployment of ASP.NET applications only in IIS. The portability of ASP.NET applications was impossible because of this heavy IIS dependency. Most ASP.NET applications rely on the System.Web assembly, which in turn is built on top of IIS and its myriad of web infrastructure features, including request/response filtering, logging, and more.

Even if they are not utilized in the application, System.Web assembly includes many pre-configured components that are automatically plugged into the HTTP pipeline. The existence of certain unwanted features in the pipeline for every request results in poor performance.

###### Katana
Katana is implementation of OWIN specifications for .Net.
Katana is a flexible set of components for building and hosting Open Web Interface for .NET (OWIN)-based web apps. New development should use [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core). The Microsoft.Owin.* libraries are not available for .NET Core because ASP.NET Core has equivalent replacements for them.

https://www.dotnetstuffs.com/owin-asp-net-core/

### Advanced

* Url Redirect vs Url Rewriting

### More
* [Validate settings when app launches](https://sourceexample.com/istartupfilter-in-asp.net-core-validates-settings-when-app-launches-39948/)

