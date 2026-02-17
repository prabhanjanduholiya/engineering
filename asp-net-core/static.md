# Serve static files
* Static files are stored within the project's web root directory. The default directory is {content root}/wwwroot, but it can be changed with the `UseWebRoot` method.
* Static files are accessible via a path relative to the web root. For example, the Web Application project templates contain several folders within the wwwroot folder:
    - css  
    - js
    - lib

Consider creating the wwwroot/images folder and adding the wwwroot/images/MyImage.jpg file. The URI format to access a file in the images folder is `https://<hostname>/images/<image_file_name>`. For example, https://localhost:5001/images/MyImage.jpg

#### Serve files in web root
The default web app templates call the `UseStaticFiles` method in Program.cs, which enables static files to be served.

#### Serve files outside of web root

```
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")),
    RequestPath = "/StaticFiles"
});
```

In the preceding code, the MyStaticFiles directory hierarchy is exposed publicly via the StaticFiles URI segment. A request to  `ttps://<hostname>/StaticFiles/images/red-rose.jpg` serves the red-rose.jpg file.

###### Set HTTP response headers
A StaticFileOptions object can be used to set HTTP response headers. In addition to configuring static file serving from the web root, the following code sets the Cache-Control header.

```
var cacheMaxAgeOneWeek = (60 * 60 * 24 * 7).ToString();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append(
             "Cache-Control", $"public, max-age={cacheMaxAgeOneWeek}");
    }
});
```

### Static file authorization

To serve static files based on authorization:

* Store them outside of wwwroot.
* Call UseStaticFiles, specifying a path, after calling UseAuthorization.
* Set the fallback authorization policy.
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-6.0#static-file-authorization

### Directory browsing
Directory browsing allows directory listing within specified directories.

Directory browsing is disabled by default for security reasons.

###### Enabling directory browsing through Middleware

Let’s consider an example where we want to allow the list of images in the browser under the images folder in wwwroot. UseDirectoryBrowser middleware can handle and serve those images for that request and then short-circuit the rest of the pipeline.

Enable directory browsing with `AddDirectoryBrowser` and `UseDirectoryBrowser`.

```
app.UseDirectoryBrowser(new DirectoryBrowserOptions  
{  
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),  
    RequestPath = "/images"  
}); 
```

### Serve default documents
Setting a default page provides visitors a starting point on a site. To serve a default file from wwwroot without requiring the request URL to include the file's name, call the UseDefaultFiles method
UseDefaultFiles must be called before UseStaticFiles to serve the default file. 
UseDefaultFiles is a URL rewriter that doesn't serve the file.

```
var options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("mydefault.html");
app.UseDefaultFiles(options);
```

###### UseFileServer for default documents
UseFileServer combines the functionality of UseStaticFiles, UseDefaultFiles, and optionally UseDirectoryBrowser.

`app.UseFileServer(enableDirectoryBrowsing: true);`

AddDirectoryBrowser must be called when the EnableDirectoryBrowsing property value is true.

###### Serve files from multiple locations
UseStaticFiles and UseFileServer default to the file provider pointing at wwwroot. Additional instances of UseStaticFiles and UseFileServer can be provided with other file providers to serve files from other locations.

```
app.UseStaticFiles(); // Serve files from wwwroot
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "static"))
});
```

##### Security considerations for static files
UseDirectoryBrowser and UseStaticFiles can leak secrets. Disabling directory browsing in production is highly recommended. Carefully review which directories are enabled via UseStaticFiles or UseDirectoryBrowser. The entire directory and its sub-directories become publicly accessible. Store files suitable for serving to the public in a dedicated directory, such as <content_root>/wwwroot. Separate these files from MVC views, Razor Pages, configuration files, etc.

###### Does Static File Middleware compress the static files?

###### Where project static files are stored in ASP.NET Core?  
Static files are stored within the project's web root directory. The default directory is {content root}/wwwroot, but it can be changed with the UseWebRoot method.
