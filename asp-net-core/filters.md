Filters in ASP.NET Core allow code to run before or after specific stages in the request processing pipeline.

* Built-in filters handle tasks such as: Authorization,Response caching, short-circuiting the request pipeline to return a cached response etc.
* Custom filters can be created to handle cross-cutting concerns. like error handling, caching, configuration, authorization, and logging. 
* Filters avoid duplicating code. For example, an error handling exception filter could consolidate error handling.

### How/When filter works?
* Filters run within the ASP.NET Core action invocation pipeline called `filter pipeline`.
* The filter pipeline runs after ASP.NET Core selects the action to execute
![filter-pipeline-1](https://user-images.githubusercontent.com/31764786/143577860-20b7cf08-85a2-4041-ac02-8066c3fb1d9a.png)

### Types of filter and their execution order? 
* Authorization filters
* Resource filters
* Action filters
* Exception filters
* Result filters

Each filter type is executed at a different stage in the filter pipeline:

##### Authorization filters:
* Run first.
* Determine whether the user is authorized for the request.
* Short-circuit the pipeline if the request is not authorized.

##### Resource filters:
* Run after authorization.
* `OnResourceExecuting`  runs code before the rest of the filter pipeline. 
* `OnResourceExecuting` runs code before model binding.
* `OnResourceExecuted` runs code after the rest of the pipeline has completed.

##### Action filters:
* Run immediately before and after an action method is called.
* Can change the arguments passed into an action.
* Can change the result returned from the action.
* Are not supported in Razor Pages.

##### Exception filters 
apply global policies to unhandled exceptions that occur before the response body has been written to.

##### Result filters:
* Run immediately before and after the execution of action results.
* Run only when the action method executes successfully.
* Are useful for logic that must surround view or formatter execution.

The following diagram shows how filter types interact in the filter pipeline:
![filter-pipeline-2](https://user-images.githubusercontent.com/31764786/143578742-12c8ef0a-c357-4b73-9980-50b1de36bfa1.png)

### Filter scopes
A filter can be added to the pipeline at one of three scopes:
* Using an attribute on a controller or Razor Page.
* Using an attribute on a controller action. Filter attributes cannot be applied to Razor Pages handler methods.
* Globally for all controllers, actions, and Razor Pages as shown in the following code:
```
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<GlobalSampleActionFilter>();
});
```

### Order of execution
When there are multiple filters for a particular stage of the pipeline, scope determines the default order of filter execution. Global filters surround class filters, which in turn surround method filters.

As a result of filter nesting, the after code of filters runs in the reverse order of the before code. The filter sequence:

* The before code of global filters.
   - The before code of controller filters.
       -The before code of action method filters.
       -The after code of action method filters.
   - The after code of controller filters.
* The after code of global filters.


### Overriding default order of execution
The default sequence of execution can be overridden by implementing IOrderedFilter. IOrderedFilter exposes the Order property that takes precedence over scope to determine the order of execution. A filter with a lower Order value:

Runs the before code before that of a filter with a higher value of Order.
Runs the after code after that of a filter with a higher Order value.
In the Controller level filters example, GlobalSampleActionFilter has global scope so it runs before SampleActionFilterAttribute, which has controller scope. To make SampleActionFilterAttribute run first, set its order to int.MinValue:

```
[SampleActionFilter(Order = int.MinValue)]
public class ControllerFiltersController : Controller
{
    // ...
}

```
### Cancellation and short-circuiting
The filter pipeline can be short-circuited by setting the Result property on the ResourceExecutingContext parameter provided to the filter method. For example, the following Resource filter prevents the rest of the pipeline from executing:

```
public class ShortCircuitingResourceFilterAttribute : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        context.Result = new ContentResult
        {
            Content = nameof(ShortCircuitingResourceFilterAttribute)
        };
    }

    public void OnResourceExecuted(ResourceExecutedContext context) { }
}
```


### What is filter pipline? 
### Real examples of filters?
###### What is Real example of Resource filter?
###### What is Real example of Action filter?
<img width="927" alt="Usage of filters" src="https://user-images.githubusercontent.com/31764786/145979411-36482931-55bd-4ee7-b0c0-0e4df90e8372.png">
https://www.youtube.com/watch?v=4cP9Vf8rKQQ
------------------------------------------------------------------------------------------------------------
https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-6.0#how-filters-work
