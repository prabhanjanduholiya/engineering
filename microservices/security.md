# Security Fundmentals
ASP.NET Core contains features for managing:

* Authentication and Authorization
* Data protection
* HTTPS enforcement
* App secrets
* XSRF/CSRF prevention
* Cross Origin Resource Sharing (CORS)
* Cross-Site Scripting (XSS) attacks

These security features allow you to build robust yet secure ASP.NET Core apps.

#### Common Vulnerabilities in software
* Cross-Site Scripting (XSS) attacks
* SQL injection attacks
* Cross-Site Request Forgery (XSRF/CSRF) attacks
* Open redirect attacks

There are more vulnerabilities that you should be aware of.

# Make secure .NET Microservices and Web Applications

**(Q) What are basic requirements for securing a Microservice?**

* It should Authaunticate users? 
* Authorization of roles should be done.
* Application secrets should be stored securly.  

## Authentication
Authentication is the process of reliably verifying a user’s identity.

**(Q) Where will you implement authentication in .NET microservices and web applications?**

In microservice scenarios, authentication is typically handled centrally. 

* If you’re using an API Gateway, the gateway is a good place to authenticate. If you use this approach, make sure that the individual microservices cannot be reached directly (without the API Gateway) unless additional security is in place to authenticate messages whether they come from the gateway or not.
* If services can be accessed directly, an authentication service like Azure Active directory or a dedicated authentication microservice acting as a security token service (STS) can be used to authenticate users.

**(Q) How trust decisions are shared between services?**

Trust decisions are shared between services with security tokens or cookies.

##### Cookie-based authentication
* When a user authenticates using their username and password, they're issued a token, containing an authentication ticket that can be used for authentication and authorization. The token is stored as a cookie that's sent with every request the client makes.

* Generating and validating this cookie is performed by the Cookie Authentication Middleware. The middleware serializes a user principal into an encrypted cookie. On subsequent requests, the middleware validates the cookie, recreates the principal, and assigns the principal to the HttpContext.User property.

##### Token-based authentication
* When a user is authenticated, they're issued a token (not an antiforgery token). The token contains user information in the form of claims or a reference token that points the app to user state maintained in the app. When a user attempts to access a resource that requires authentication, the token is sent to the app with an extra authorization header in the form of a Bearer token. This approach makes the app stateless. In each subsequent request, the token is passed in the request for server-side validation. This token isn't encrypted; it's encoded. On the server, the token is decoded to access its information. To send the token on subsequent requests, store the token in the browser's local storage. 

* Don't be concerned about CSRF vulnerability if the token is stored in the browser's local storage. CSRF is a concern when the token is stored in a cookie.


**(Q) What are the ways to implement authentication in .NET microservices and web applications?**

* (1) Authenticate with **ASP.NET Core Identity (see below)**
* (2) Authenticate with bearer tokens via **OAuth 2.0 flows (see below)** **or OpenID Connect (see below)**
* (3) Issue security tokens from an ASP.NET Core service using **IdentityServer4**

### (1) Authenticate with ASP.Net Core Identity: 

###### ASP.Net Core Identity
* The primary mechanism in ASP.NET Core for identifying an application’s users is the ASP.NET Core Identity membership system. 
* ASP.NET Core Identity stores user information (including sign-in information, roles, and claims) in a data store configured by the developer. 
* ASP.NET Core Identity data store is an Entity Framework store provided in the Microsoft.AspNetCore.Identity.EntityFrameworkCore package.
* However, custom stores or other third-party packages can be used to store identity information in Azure Table Storage, CosmosDB, or other locations.
* ASP.NET Core Identity also supports two-factor authentication.

Using ASP.NET Core Identity enables several scenarios:
* Create new user information using the UserManager type (userManager.CreateAsync).
* Authenticate users using the SignInManager type. You can use signInManager.SignInAsync to sign in directly, or signInManager.PasswordSignInAsync to confirm the user’s password is correct and then sign them in.
* Identify a user based on information stored in a cookie (which is read by ASP.NET Core Identity middleware) so that subsequent requests from a browser will include a signed-in user’s identity and claims.

### (2) Authenticate with bearer tokens using **OAuth 2.0 flows** or **OpenID Connect**
* Authenticating with ASP.NET Core Identity (or Identity plus external authentication providers) works well for many web application scenarios in which storing user information in a cookie is appropriate. In other scenarios, though, cookies are not a natural means of persisting and transmitting data.

For example, in an ASP.NET Core Web API that exposes RESTful endpoints that might be accessed by Single Page Applications (SPAs), by native clients, or even by other Web APIs, you typically want to use bearer token authentication instead. These types of applications do not work with cookies, but can easily retrieve a bearer token and include it in the authorization header of subsequent requests. 

To enable token authentication, ASP.NET Core supports several options for using **OAuth 2.0 and OpenID Connect**.

###### OAuth 2.0:
OAuth 2.0 is a security standard where you give one application permission to access your data in another application. The steps to grant permission, or consent, are often referred to as authorization or even delegated authorization. You authorize one application to access your data, or use features in another application on your behalf, without giving them your password. 

1) You, the Resource Owner, want to allow “Terrible Pun of the Day,” the Client, to access your contacts so they can send invitations to all your friends.
2) The Client redirects your browser to the Authorization Server and includes with the request the Client ID, Redirect URI, Response Type, and one or more Scopes it needs.
3) The Authorization Server verifies who you are, and if necessary prompts for a login.
4) The Authorization Server presents you with a Consent form based on the Scopes requested by the Client. You grant (or deny) permission.
5) The Authorization Server redirects back to Client using the Redirect URI along with an Authorization Code.
6) The Client contacts the Authorization Server directly (does not use the Resource Owner’s browser) and securely sends its Client ID, Client Secret, and the Authorization Code.
7) The Authorization Server verifies the data and responds with an Access Token.
8) The Client can now use the Access Token to send requests to the Resource Server for your contacts.

##### Client ID and Secret (How an Authorization Server identifies a client?)
Long before you gave permission toclient to access your contacts, the Client and the Authorization Server established a working relationship. The Authorization Server generated a Client ID and Client Secret, sometimes called the App ID and App Secret, and gave them to the Client to use for all future OAuth exchanges.

As the name implies, the Client Secret must be kept secret so that only the Client and Authorization Server know what it is. This is how the Authorization Server can verify the Client.


###### OpenID Connect:
OAuth 2.0 is designed only for authorization, for granting access to data and features from one application to another. OpenID Connect (OIDC) is a thin layer that sits on top of OAuth 2.0 that adds login and profile information about the person who is logged in. Establishing a login session is often referred to as authentication, and information about the person logged in (i.e. the Resource Owner) is called identity. When an Authorization Server supports OIDC, it is sometimes called an identity provider, since it provides information about the Resource Owner back to the Client.

OpenID Connect enables scenarios where one login can be used across multiple applications, also known as single sign-on (SSO). 
The OpenID Connect flow looks the same as OAuth. The only differences are, in the initial request, a specific scope of openid is used, and in the final exchange the Client receives both an Access Token and an ID Token.

As with the OAuth flow, the OpenID Connect Access Token is a value the Client doesn’t understand. As far as the Client is concerned, the Access Token is just a string of gibberish to pass with any request to the Resource Server, and the Resource Server knows if the token is valid. The ID Token, however, is very different.

##### An ID Token is a JWT
An ID Token is a specifically formatted string of characters known as a JSON Web Token, or JWT. JWTs are sometimes pronounced “jots.” A JWT may look like gibberish to you and me, but the Client can extract information embedded in the JWT such as your ID, name, when you logged in, the ID Token expiration, and if anything has tried to tamper with the JWT. The data inside the ID Token are called claims.

https://developer.okta.com/blog/2019/10/21/illustrated-guide-to-oauth-and-oidc


If user information is stored in Azure Active Directory or another identity solution that supports OpenID Connect or OAuth 2.0, you can use the Microsoft.AspNetCore.Authentication.OpenIdConnect package to authenticate using the OpenID Connect workflow.

### (3) Issue security tokens from an ASP.NET Core service using **IdentityServer4**
* If you prefer to issue security tokens for local ASP.NET Core Identity users rather than using an external identity provider, you can take advantage of some good third-party libraries.
* IdentityServer4 and OpenIddict are OpenID Connect providers that integrate easily with ASP.NET Core Identity to let you issue security tokens from an ASP.NET Core service.

###### IdentityServer4
IdentityServer4 is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core. IdentityServer4 enables the following security features:
* Authentication as a Service (AaaS)
* Single sign-on/off (SSO) over multiple application types
* Access control for APIs
* Federation Gateway

### JWT


## Authorization 
Authorization refers to the process that determines what a user is able to do. For example, an administrative user is allowed to create a document library, add documents, edit documents, and delete them.

Authorization is orthogonal and independent from authentication. However, authorization requires an authentication mechanism. Authentication is the process of ascertaining who a user is. Authentication may create one or more identities for the current user.

### Authorization types 
* Simple Authorization
* Role Based Authorization
* Claim Based Authorization
* Policy Based Authorization

#### Simple authorization in ASP.NET Core
Authorization in ASP.NET Core is controlled with AuthorizeAttribute and its various parameters. In its most basic form, applying the [Authorize] attribute to a controller, action, or Razor Page, limits access to that component authenticated users.

```
[Authorize]
public class AccountController : Controller
{
    public ActionResult Login()
    {
    }

    public ActionResult Logout()
    {
    }
}
``` 

* AllowAnonymous Attribute allow access by non-authenticated users to individual actions. For example: 
```
[Authorize]
public class AccountController : Controller
{
    [AllowAnonymous]
    public ActionResult Login()
    {
    }

    public ActionResult Logout()
    {
    }
}
```

#### Role-based authorization in ASP.NET Core


## More

* [ASP.NET Core Security](Docs/Asp.Net_Core/Security/Security_Fundamentals.md)  
* [Common Vulnerabilities](Docs/Asp.Net_Core/Security/Common_vulnerabilities_in_application.md)

