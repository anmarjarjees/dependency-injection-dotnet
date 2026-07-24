# Dependency Injection in .NET
A beginner-friendly guide to Dependency Injection (DI) in C# and ASP.NET Core using industry best practices and real-world development patterns.

---

## What is Dependency Injection?
Dependency Injection (DI) is a software design pattern where an object does not create its own dependencies. Instead, those dependencies are provided (or "injected") from the outside. So we can think of a dependency as a tool or service that a class needs to perform its tasks. Dependency Injection is the process of providing those dependencies from the outside.

**This helps make code:**
- easier to test
- easier to maintain
- more flexible
- less tightly coupled

**DI is widely used in modern software development and is not specific to .NET.**

---

## Dependency Injection Across Different Platforms
Dependency Injection is a general software design pattern used across many programming languages and frameworks:

| Language / Platform | Dependency Injection Support |
|-|-|
| .NET (C#) | Built-in DI container (ASP.NET Core) |
| Java | Spring Framework |
| Python | dependency-injector, injector |
| JavaScript / TypeScript | NestJS, InversifyJS |
| PHP | Laravel, Symfony, CodeIgniter |
| C++ | Various libraries, often manual implementation |
| Kotlin | Koin, Dagger, Hilt |
| Android | Hilt, Dagger |
| Angular | Built-in DI system |

---

## Goal of This Repository
This repository is designed to explain Dependency Injection in .NET step by step, starting from the basics and gradually moving toward more advanced concepts.

We will follow a structured learning path:
- What a "dependency" actually means in software development
- Why Dependency Injection exists and what problems it solves
- Constructor Dependency Injection (the recommended approach for required dependencies in .NET)
- Setter (Property) Dependency Injection and its limited use cases
- Interface-based Dependency Injection and why interfaces are important
- How ASP.NET Core uses built-in Dependency Injection internally
- How to write clean, testable, and maintainable code using DI

By the end of this repository, you should not only understand how Dependency Injection works, but also why it is designed this way and how to apply it in real-world .NET applications.

---

## Microsoft Best Practices

This repository follows key Dependency Injection guidelines recommended by Microsoft:

- Avoid creating external service dependencies inside classes using `new`. Instead, prefer injecting them when appropriate.
- Prefer constructor injection for required dependencies
- Use abstractions (such as interfaces) to reduce tight coupling between classes
- Keep classes small and focused on a single responsibility
- Avoid static/global state where possible
- Design services to be testable and modular
- Program to abstractions (interfaces) instead of concrete implementations whenever practical
- Register services in the DI container with appropriate lifetimes

> Note: More advanced topics such as service lifetimes in depth, scopes, and disposal behavior will be explored in future learning stages.

## Application Parts/Folders Topics
This tutorial is divided into 7 parts:
- Part 1: Understanding Dependencies
    - Introducing the concept using simple classes (Musician + Guitar + Amplifier + Mic):
        - Musician depends on:
            - Guitar
            - Amplifier
            - Mic
- Part 2 (recommended in .NET): Constructor Injection
    - How dependencies are passed through constructors
    - Reusing the dependencies from part 1 
    - The Musician:
        - does not create dependencies
        - receives its dependencies from outside
    - NOTE => Constructor injection makes dependencies available when the object is created, which is ideal for required dependencies. Changing them later usually requires creating a new object. 
- Part 3: Setter (Property) Injection (less common in .NET)
    - Dependencies are provided through properties/setters instead of constructor parameters
    - Dependencies can be changed after object creation
        - Showing property-based injection and its risks
    - Used when dependencies are optional or need to be changed after object creation.
    - NOTE => Dependencies might not be set at object creation time which may lead to potential **"NullReferenceException"**
- Part 4: Interface-Based Dependency Injection (Educational Example)
    - Demonstrating dependency injection through interface-defined methods
    - Understanding contracts and abstractions
    - Comparing it with constructor injection
    - Providing dependencies through an interface
        - Interface will be implemented by the consumer class "Musician"
        - Interface will define the methods
    - A clear contract for DI through interfaces
    - NOTE: => Requires additional interfaces to be defined for setting the dependencies
- Part 5: ASP.NET Core Built-in Dependency Injection
    - IServiceCollection service registration
    - Service registration methods:
        - AddTransient
        - AddScoped
        - AddSingleton
    - Constructor Injection managed by the ASP.NET Core DI container
- Part 6: Service Lifetimes (future section)
    - Transient
    - Scoped
    - Singleton
    - Visual demonstrations
    - Common lifetime mistakes
- Part 7: Real-World Example (future section)
    - Repository pattern
    - Logging (ILogger<T>)
    - Configuration (IOptions<T>)
    - Best practices and Common DI mistakes
    - Microsoft recommendations
    - Best Practices and Common Mistakes

**NOTE:
Dependency Injection is a design pattern, not a framework.
.NET and ASP.NET Core provide built-in support for implementing this pattern through their dependency injection container.**

# Project (Repository) Structure:
- Folder (Main Container/The repo name): **"dependency-injection-dotnet"** 
    - Project => DependencyInjectionDemo
        - Program.cs => the entrypoint to our application + demo for running all parts (1,2,3, and 4)
        - /Part1 => What is dependency?
            - Guitar.cs
            - Amplifier.cs
            - Mic.cs
            - Musician.cs
        - /Part2 => Constructor Injection
            - Musician.cs
        - /Part3 => Setter Injection
            - Musician.cs
        - /Part4 => Interface Injection
    - Project => AspNetCoreDIDemo (covering Part 5,6, and 7)
        - Controllers
        - Services
            - IMusicService.cs
            - MusicService.cs
            - IGuitarService.cs
            - GuitarService.cs
        - *Interfaces => is optional (not used in this repo) if we want to place interface files here*
        - Views
            - Music
                - Index.cshtml
        - Program.cs
---

## Program.cs Usage
First:
```C#
// PART 1
var musician1 = new DependencyInjectionDemo.Part1.Musician();
musician.Perform();
```

Then:
```C#
// PART 2
var musician2 = new DependencyInjectionDemo.Part2.Musician();
musician.Perform();
```

*Continue in the same way for the remaining parts. Each part demonstrates the evolution from tightly coupled dependencies toward different Dependency Injection approaches, ending with ASP.NET Core's built-in Dependency Injection container.*

---

# Project Part Folders Explained:
## Part 1: Understanding dependencies (Musician creates dependencies) **(tight coupling)**
The **Musician** class is doing this:
- creating Guitar
- creating Amplifier
- creating Mic

**So the rule is: The class is responsible for both doing work and creating its tools**

## Part 2: Improved design (dependencies injected) 
In this part we cover the "Constructor Injection" type.
Instead of: **`Musician creates its own tools`**
We move to: **`Musician receives tools from outside`**

## Part 3: Setter Injection
This part demonstrates property-based dependency injection.
The Musician receives dependencies after object creation through public properties.
It also demonstrates why constructor injection is usually preferred for required dependencies.

## Part 4: Interface Injection
This part demonstrates an educational example of dependency injection through interface-defined methods.
It helps explain abstraction and contracts, although it is less common in modern .NET applications where constructor injection with interfaces is the preferred approach.

## Part 5: ASP.NET Core Built-in Dependency Injection
This part demonstrates how ASP.NET Core manages dependencies using its built-in DI container.

Topics:
- IServiceCollection
- Service registration
- Constructor injection managed by ASP.NET Core
- Multiple service dependencies
- MVC Controller injection

## Part 6: Service Lifetimes (Future)
Planned topics:
- AddTransient
- AddScoped
- AddSingleton
- Scope behavior
- Disposal

## Part 7: Real-World DI Examples (Future)
Planned topics:
- Repository pattern
- ILogger<T>
- Configuration
- Options pattern
- Testing

# Starting the ASP.NET Core Project
We will now practice tha actual implementation of the "Dependency Injection" using ASP.NET Core. 
ASP.NET Core provides several project templates. The following are some of the most common templates used in Visual Studio:
- **ASP.NET Core Web App (MVC)**:
 Builds web applications using the **Model-View-Controller (MVC)** pattern. Best suited for applications with controllers, views, routing, and server-side rendering.
- **ASP.NET Core Web App (Razor Pages)**:
 Builds page-focused web applications using **Razor Pages**. Provides a page-focused programming model where each Razor Page contains its UI and associated page logic.
- **ASP.NET Core Web API**:
Builds **HTTP REST APIs** that return data (such as JSON) for browsers, mobile apps, desktop applications, or other services. Builds HTTP APIs that return data (commonly JSON) for clients such as browsers, mobile apps, desktop applications, or other services.

# Our ASP.NET Core (MVC) Project Structure:
Our new project should look approximately like this:
- AspNetCoreDIDemo:
    - Controllers
        - HomeController.cs
    - Models
        - ErrorViewModel.cs
    - Views
        - Home
        - Shared
    - wwwroot
    - appsettings.json
    - appsettings.Development.json
    - Program.cs
    - AspNetCoreDIDemo.csproj

> Note: The exact files and folders may vary depending on the .NET version and selected options when creating the project.

# Project Building and Coding Sequence:
### Step1:
You can review the details comments and explanations in **Program.cs** file. 

### Step2:
Creating a new folder **"Services"** to store our application services. Then creating the interface file **"IMusicService.cs"**. We create the interface first because the consumer class (later, an ASP.NET Core Controller) should depend on an abstraction (interface), not directly on a concrete implementation.

    > Controller ==> IMusicService

Notice that we are no longer using Musician in this ASP.NET Core project, instead, we are using a "Controller".

The same principle is used in real ASP.NET Core applications.

**For example:**
- Instead of a Controller depending directly on the concrete class **MusicService**:
    - Controller ==> MusicService
- we make it depend on the abstraction:
    - Controller ==> IMusicService

**Then ASP.NET Core's built-in Dependency Injection container is responsible for providing the correct implementation.
The final relationship will be:**
```text
    Controller == depends on ==> IMusicService (Contract)
                             ==> implemented by ==> MusicService (Implementation)
```

At this stage, we have created the abstraction and its implementation. The service is not managed by ASP.NET Core DI yet.
The DI registration step will happen later in Program.cs.

The final folder structure:
```bash
- Services
    - IMusicService.cs (Contract / Abstraction)
    - MusicService.cs (Concrete Implementation)
```

### Step3:
- Modifying the "Program.cs" by adding one line which is the first real Dependency Injection line in ASP.NET Core:
```C#
builder.Services.AddTransient<IMusicService, MusicService>();
```
This line uses "builder.Services" because the Services property is an "IServiceCollection", which is the collection where framework services, application services, and third-party services are registered for the built-in ASP.NET Core Dependency Injection container.

We followed this progression:
```bash
builder.Services (IServiceCollection): A collection of service registrations
    => ASP.NET Core framework service registrations
    => Logging service registrations
    => Configuration service registrations
    => Our custom service registrations
```
So our custom service is treated exactly like Microsoft's framework services.

**NOTE:**
The DI container does not treat our custom services differently. Once registered, our services can be injected in the same way as built-in ASP.NET Core services.

By this stage, we have completed three things:

1. Created the contract (IMusicService)
2. Created the implementation (MusicService)
3. Registered the service mapping with the DI container

The registration tells ASP.NET Core:
    > IMusicService => MusicService

But nothing is using it yet.

### Step4:
Creating a Controller because this project uses the ASP.NET Core Web App (MVC) template. Instead of using the default controller "HomeController", we will use another dedicated controller because it makes our DI example more clear.

Adding a new Controller:
```bash
    > Controllers/
        > MusicController.cs
```

The controller is the consumer of our service.

The dependency flow is now:
```bash
    > IMusicService (contract)
        >> implemented by >>
            > MusicService (implementation)
                
    > ASP.NET Core DI Container
        >> resolves IMusicService
            >> creates MusicService
                >> injects it into >> MusicController (consumer)
                    >> depends on IMusicService
```

At this stage, our controller "MusicController" only depends on one service:
    > MusicController == depends on ==> IMusicService == implemented by ==> MusicService

In real ASP.NET Core applications, controllers often depend on multiple services, for example:
- Framework services:
    - ILogger<T>
    - IConfiguration
- Application services:
    - IProductService
    - IEmailService

**Please review the code and the detailed comments in "MusicController.cs".**

### Step5:
For more practice, and to demonstrate the idea from Step 4 that an ASP.NET Core application can depend on multiple services, let's add a second service and see how the DI container resolves multiple dependencies automatically.

```bash
                        ASP.NET Core DI Container
                                    |
                    <<==============================>>
       IMusicService (Contract)             IGuitarService (Contract)         
                |                                    |
                | implemented by                     | implemented by
      MusicService (Implementation)     GuitarService (Implementation)
                |                                    |
                --------------------------------------
                                   |    
                                   |
                            MusicController (Consumer)              
                                   |
                                   | depends on:
                                    - IMusicService
                                    - IGuitarService
```
Based on the above diagram, we can see that our controller "MusicController" depends on two service abstractions (interfaces):
- IMusicService (Implemented by MusicService)
- IGuitarService (Implemented by GuitarService)

The controller will depend on these new abstractions **"interfaces (contracts)"**, not directly on GuitarService.

So we will create a second contract (interface) that represents another service dependency. Then creating the contract and the implementation as we did before and as shown below:
```bash
    > IGuitarService (new contract)
        >> implemented by >>
            > GuitarService (new implementation)
                >> injected into >>
                    MusicController (consumer)
```
Notice that the purpose is not to create a realistic guitar service. The purpose is to demonstrate an important DI concept:
**"A class can depend on multiple services, and ASP.NET Core DI can provide all of them automatically"**

**Please review the code and the detailed comments in "IGuitarService.cs" and "GuitarService.cs" files.**

**NOTE:**
At this point, we have the service mapping:
    > IMusicService => MusicService
However, the ASP.NET Core DI container does not know about this relationship until we register it in Program.cs:

```C#
builder.Services.AddTransient<IMusicService, MusicService>();
```

The same concept applies to our new guitar service:
```C#
builder.Services.AddTransient<IGuitarService, GuitarService>();
```

After registration, ASP.NET Core can automatically provide both dependencies when creating **MusicController**.

### Step6:
Modify the **MusicController** to inject and use the second service abstraction (**IGuitarService**).

The controller now depends on two service abstractions instead of one:
- IMusicService
- IGuitarService

```bash
                        ASP.NET Core DI Container
                                    |
                    <<==============================>>
       IMusicService (Contract)             IGuitarService (Contract)         
                |                                    |
                | implemented by                     | implemented by
                |                                    |
      MusicService (Implementation)     GuitarService (Implementation)
                |                                    |
                --------------------------------------
                                   |    
                                   |
                            MusicController (Consumer)              
                                   |
                                   | Injects:
                                    - IMusicService
                                    - IGuitarService
                                    |
                                    | Returns:
                                    - HTTP Response
```

At this stage, ASP.NET Core automatically resolves both dependencies through Constructor Dependency Injection.

The controller does **not** create the service objects itself *(No new ...)*:
```csharp
new MusicService();
new GuitarService();
```
Instead, the built-in DI container creates the required service objects and injects them into the controller constructor.

Please review the implementation and detailed comments in **MusicController.cs**.

### Step7:
The controller currently returns plain text using **Content()** to keep the Dependency Injection example simple and easy to understand. This allows us to verify that the injected services are working correctly before introducing Views.

In the next step, we will complete the MVC flow by replacing the plain text response with an MVC **View**, allowing the controller to pass data to the presentation layer.

We will now change the application to follow the normal MVC pattern by returning a View instead of plain text.
```bash
    > Browser Request
        > MusicController
            > Calls Services (IMusicService + IGuitarService)
                > Pass data to the View
                    > Views/Music/Index.cshtml
                        > Razor View Engine generates HTML
                            > Browser
```

A new ASP.NET Core MVC project includes a default Views/Home folder. In this project, we will create our own Views/Music folder because our controller is MusicController.

By convention, MVC uses this:
    > Views ==> ControllerName ==> ActionName.cshtml

Our controller is **"public class MusicController : Controller"**, so we remove the suffix **"Controller"** and keep only **"Music"** as the folder name.. 

Now we need to modify the controller file "MusicController.cs" by updating the action method:
```C#
public IActionResult Index()
```

Remember that this action method original (initial built) used to return one text message:
```C#
return Content(musicMessage);
```

After adding a second service, we combined both messages from the Music and Guitar services into a single text response:
```C#
var output = $"{musicMessage} \n {guitarMessage}";
return Content(output);
```

Now we will modify it to return a View.. By convention, ASP.NET Core will automatically look for:
```bash
    Views\Music\Index.cshtml
```
So when the controller returns **"View()"** from the **"Index()""** action, ASP.NET Core MVC follows the default view discovery convention and looks for: **"Views/Music/Index.cshtml"**

We then create a new Razor View named Index.cshtml, add some basic content, and update it to display the data received from the controller. Please review the code and comments in that file. Also we can test our application to see the view page "index.cshtml" is loading.

Now since we have the following two services in our controller:
```C#
var musicMessage = _musicService.GetMusicMessage();
var guitarMessage = _guitarService.Play();
```

We can now send these two values to the View to learn one of the ways a controller passes data to the presentation layer.

In order to pass data to a View, ASP.NET Core MVC provides several ways:
- ViewData
- ViewBag
- Strongly Typed View Models (recommended by Microsoft for real applications)

In order to clearly understand why "ViewModels" exist, we can demonstrate the three approaches in our current project (repo) according to the following order:
1. ViewData (very simple, built into MVC)
2. ViewBag (shows another common approach)
3. Strongly Typed View Models (the recommended approach for most real-world MVC applications)

Our final return code line in the controller was:
```C#
return View();
```

We will replace it with:
```C#
ViewData["MusicMessage"] = musicMessage;
ViewData["GuitarMessage"] = guitarMessage;

return View();
```

**Consider the following:**
- The controller does not generate HTML
- The controller prepares the data
- The View is responsible for generating the HTML displayed in the browser
- The Razor View is responsible for generating the HTML displayed in the browser


---
---

# Credits, References, and Resources:
- [Microsoft Visual Studio](https://visualstudio.microsoft.com/)
- [C# Classes](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes)
- [Constructors (C# programming guide)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors)
- [Access modifiers (C# programming guide)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers)
- [Interfaces - define behavior for multiple types](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces)
- [Dependency Injection in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [Dependency Injection Guidelines](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-guidelines)
- [ASP.NET Core DI Overview](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-10.0)
- [ASP.NET Core MVC - Overview of ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-11.0)
- [ASP.NET Core Razor Pages -Introduction to Razor Pages in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-11.0&tabs=visual-studio)
- [ASP.NET Core Web API - Create web APIs with ASP.NET Core ](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-11.0)
- My Other .NET Stack Repos:
   - .NET and C# Intro:
      - https://github.com/anmarjarjees/dotnet-csharp-intro
   - C# Essentials:
      - https://github.com/anmarjarjees/csharp-essentials
   - C# Intro:
      - https://github.com/anmarjarjees/csharp-intro
