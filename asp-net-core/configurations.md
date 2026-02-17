Application configuration in ASP.NET Core is performed using one or more [configuration providers](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0#cp). Configuration providers read configuration data from key-value pairs using a variety of configuration sources:

* Settings files, such as appsettings.json
* Environment variables
* Azure Key Vault
* Azure App Configuration
* Command-line arguments
* Custom providers, installed or created
* Directory files
* In-memory .NET objects


### Application and Host Configuration
ASP.NET Core apps configure and launch a host. The host is responsible for app startup and lifetime management. The ASP.NET Core templates create a [WebApplicationBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.webapplicationbuilder) which contains the host. While some configuration can be done in both the host and the application configuration providers, generally, only configuration that is necessary for the host should be done in host configuration.

The initialized WebApplicationBuilder (builder) provides default configuration for the app in the following order, from highest to lowest priority:

* Command-line arguments using the [Command-line configuration provider](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0#command-line).
* Non-prefixed environment variables using the [Non-prefixed environment variables configuration provider](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0#evcp).
* [User secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0) when the app runs in the Development environment.
* appsettings.{Environment}.json using the [JSON configuration provider](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0#jcp). For example, appsettings.Production.json and appsettings.Development.json.
* [appsettings.json](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0#appsettingsjson) using the [JSON configuration provider](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0#jcp).
* A fallback to the host configuration described in the [next section](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0#host).

# Options pattern in ASP.NET Core

* Options pattern binds classes to configuration sections in config file and those classes gets available for dependency injections
* The options pattern uses classes to provide strongly typed access to groups of related settings.
* Bind hierarchical configuration

## Options Interfaces and their use cases 

### IOptions

#### Does not support
* Reading of configuration data after the app has started.
* Named options
* Is registered as a Singleton and can be injected into any service lifetime.

https://dotnetdocs.ir/Post/42/difference-between-ioptions-ioptionssnapshot-and-ioptionsmonitor
#### IOptionsSnapshot
* Is useful in scenarios where options should be recomputed on every request. For more information, see Use IOptionsSnapshot to read updated data.
* Is registered as Scoped and therefore cannot be injected into a Singleton service.
* Supports named options

#### IOptionsMonitor
* Is used to retrieve options and manage options notifications for TOptions instances.
* Is registered as a Singleton and can be injected into any service lifetime.
Supports:
    - Change notifications
    - Named options
    - Reloadable configuration
    - Selective options invalidation (IOptionsMonitorCache)
  
## Named options support using IConfigureNamedOptions

Named options:
* Are useful when multiple configuration sections bind to the same properties.
* Are case sensitive.

```
{
  "TopItem": {
    "Month": {
      "Name": "Green Widget",
      "Model": "GW46"
    },
    "Year": {
      "Name": "Orange Gadget",
      "Model": "OG35"
    }
  }
}
```

```
public class TopItemSettings
{
    public const string Month = "Month";
    public const string Year = "Year";

    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
}
```

```
builder.Services.Configure<TopItemSettings>(TopItemSettings.Month,
    builder.Configuration.GetSection("TopItem:Month"));
builder.Services.Configure<TopItemSettings>(TopItemSettings.Year,
    builder.Configuration.GetSection("TopItem:Year"));
```

## Options validation

```
{
  "MyConfig": {
    "Key1": "My Key One",
    "Key2": 10,
    "Key3": 32
  }
}
```

```
public class MyConfigOptions
{
    public const string MyConfig = "MyConfig";

    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
    public string Key1 { get; set; }
    [Range(0, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Key2 { get; set; }
    public int Key3 { get; set; }
}
```

```
builder.Services.AddOptions<MyConfigOptions>()
            .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig))
            .ValidateDataAnnotations();

```

Reference - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0#bind-hierarchical-configuration
