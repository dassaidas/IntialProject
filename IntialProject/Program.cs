using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

public class Program
{

    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        var app = builder.Build();

        //Adding Static Files Middleware Component to serve the static files
        app.UseStaticFiles();

        app.MapGet("/", () => "Hello World!");

        //This will Run the Application
        app.Run();
    }


    //public static void Main(string[] args)
    //{
    //    //Creating the Web Host and Configuring the Services
    //    var builder = WebApplication.CreateBuilder(args);
    //    //Building the Application

    //    var app = builder.Build();
        

    //    //Reading value form the appsettings.json
    //    //case1
    //    string? value = builder?.Configuration["MyValue"];
    //    //case 2;
    //    string? alternateValueReading = builder?.Configuration.GetValue<string>("MyValue", "empty value");


    //   // Setting Up Endpoints, Routing, and Middleware Components
    //    //app.MapGet("/", () => $"Hello World!{value} +{alternateValueReading}");

    //    //adding middle wares
    //    //https://localhost:44333/greet
    //    app.MapGet("/greet", () => "hello form greet endpoint");
    //    //https://localhost:44333/greet/sai
    //    app.MapGet("/greet/{name}", (string name) => $"hello,{name}");


    //    //configuring new inline middleware component using run extension method

    //    //app.Run(async(context)=>
    //    //{
    //    //    await context.Response.WriteAsync("Hi from run extension method");
    //    //});

    //    app.Use(async (context, next) =>
    //    {

    //        await context.Response.WriteAsync("calling first middle ware");
    //        await next();
    //    });

    //    app.Run(FirstMiddleware);

    //    //Running the Application
    //    app.Run();
    //}


    //public delegate Task RequestDelegate(HttpContext context);

    // the below method should be same signature as RequestDelegate like above line
    private static  async Task FirstMiddleware(HttpContext context)
    {

        await context.Response.WriteAsync("calling second middleware");
    }
}
/*
Step 1: Creating the Web Host and Configuring the Services
var builder = WebApplication.CreateBuilder(args);:

This is the first line of code in the Main method used to create an instance of the WebApplicationBuilder sealed class. The args parameter allows the application to process any command-line arguments passed at application startup. The WebApplicationBuilder instance is responsible for configuring essential services (like Logging, Configuration, MVC, Web API, Dependency Injection, etc.) preconfigured defaults such as:

Set up Web Server (IIS, or Kestrel)
Host the Application (InProcess or OutOfProcess)
Logging (debugging and console logging)
Configuration (How to access the Data from Configuration Files)
Dependency Injection Container (registering built-in and custom services)

Step 2: Building the Application
var app = builder.Build();:

After configuring the essential services, when the Build() method is called on the WebApplicationBuilder instance, the actual WebApplication instance is built. The result, the app, represents the application itself. From this point, the application is ready to set up routes, configure the middleware component, and start handling requests, but it isn’t running yet.

Step 3: Setting Up Endpoints, Routing, and Middleware Components
app.MapGet(“/”, () => “Hello World!”);:

This line defines a simple endpoint (or route) that handles HTTP GET requests. So, you need to remember that using the Web Application instance, app, we can set up the Middleware Component, endpoints, routing, etc. for our ASP.NET Core Application

app.MapGet(“/”, …);: This maps the root URL (“/”) of the application to a handler function.
() => “Hello World!”: This is an inline lambda function(handler function) that returns the string “Hello World!”. When a user sends a GET request to the root URL (e.g., http://localhost/), this route handler returns the string “Hello World!” as the response.
This is a basic HTTP route using the MapGet method, which allows us to handle requests with a lambda function (() => “Hello World!”).



    Step 4: Running the Application
app.Run();:

This line starts the web server and begins listening for incoming requests. Without app.Run(), the web server will not start. The Run() method keeps the application running until manually stopped, and it is responsible for handling incoming HTTP requests.

Note: Using the WebApplicationBuilder instance, we will configure the services, and using the WebApplication instance, we will configure the Middleware components required for our application.

Understanding MapGet Method in ASP.NET Core:
Routing in ASP.NET Core is responsible for matching incoming HTTP requests to defined endpoints in our application. Endpoints are executable code that runs in response to a request. The following is the default code for the Main method of the Program class when we created the ASP.NET Core Empty project.

namespace FirstCoreWebApplication
{
    public class Program
    {
        //Entry point to the application
        public static void Main(string[] args)
        {
            // Step 1: Creating the Web Host and Services
            var builder = WebApplication.CreateBuilder(args);
            //Step 2: Building the Application
            var app = builder.Build();
            //Step 3: Setting Up Endpoints, Routing and Middleware Components
            app.MapGet("/", () => "Hello World!");
            //Step 4: Running the Application
            app.Run();
        }
    }
}
The above example code configures a single endpoint using the MapGet method.With the MapGet endpoint, when an HTTP GET request is sent to the application root URL /, the request delegate executes, i.e., the statement () => “Hello World!” will execute, and Hello World! will be written to the HTTP response.Now, run the application, and you should get the following output, which is coming from the MapGet Endpoint.

    Next=> The CreateBuilder method sets the web host with default configurations, such as hosting the application with the default server (e.g., either IIS or Kestrel) and the default hosting model (e.g., InProcess or OutOfProcess). So, next, we will learn about Different Hosting Models.
*/