# Dependency Injection in .NET
A beginner-friendly guide to Dependency Injection (DI) in C# and ASP.NET Core using industry best practices and real-world development patterns.

---

## What is Dependency Injection?
Dependency Injection (DI) is a software design pattern where an object does not create its own dependencies. Instead, those dependencies are provided (or "injected") from the outside. So we can think about DI as a collection of necessary tools and services that a class needs to perform its tasks.

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
- Setter (Property) Dependency Injection and when it is used
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

> Note: Advanced topics like service lifetimes, scopes, and disposal behavior will be introduced in future learning stages.

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
        - Tools provided through properties/setters!
    - Dependencies can be changed after object creation
        - Showing property-based injection and its risks
    - Used when dependencies are optional or need to be changed after object creation.
    - NOTE => Dependencies might not be set at object creation time which may lead to potential null reference exception
- Part 4: Interface Injection (educational example in this tutorial repository)
    - Demonstrating dependency injection through interface-defined methods
    - Understanding contracts and abstractions
    - Comparing it with constructor injection
    - Providing dependencies through an interface
        - Interface will be implemented by the consumer class "Musician"
        - Interface will define the methods
    - A clear contract for DI though interfaces
    - NOTE: => Requires additional interfaces to be defined for setting the dependencies
- Part 5: ASP.NET Core Built-in Dependency Injection
    - IServiceCollection service registration
    - Service registration methods:
        - AddTransient
        - AddScoped
        - AddSingleton
    - Constructor Injection managed by the ASP.NET Core DI container
- Part 6: Service Lifetimes
    - Transient
    - Scoped
    - Singleton
    - Visual demonstrations
    - Common lifetime mistakes
- Part 7: Real-World Example
    - Repository pattern
    - Logging (ILogger<T>)
    - Configuration (IOptions<T>)
    - Best practices and Common DI mistakes
    - Microsoft recommendations
    - Best Practices and Common Mistakes

**NOTE:
Dependency Injection is a design pattern, not a framework.
.NET and ASP.NET Core provide built-in support for implementing this pattern through their dependency injection container.**

# Project and Folder Structure:
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
        - Interfaces
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

*Continue in the same way for the remaining parts. Each part demonstrates a different Dependency Injection technique while reusing the same example application.*

---

# Project Part Folders Explained:
## Part 1: Bad design (Musician creates dependencies) **(tight coupling)** 
The **Musician** class is doing this:
- creating Guitar
-creating Amplifier
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
This part demonstrates dependency injection through interface-defined methods.
This helps explain abstraction and contracts, although it is less common in modern .NET applications.

## Part 5:
To be added...

## Part 6:
To be added...

## Part 7:
To be added...

# Staring the ASP.NET Core Project
We will now practice tha actual implementation of the "Dependency Injection" using ASP.NET Core. Notice that .NET provides 3 different primary types (templates) of ASP.NET Core project, and we see them commonly in Visual Studio:
- **ASP.NET Core Web App (MVC)**:
 Builds web applications using the **Model-View-Controller (MVC)** pattern. Best suited for applications with controllers, views, routing, and server-side rendering.
- **ASP.NET Core Web App (Razor Pages)**:
 Builds page-focused web applications using **Razor Pages**. Provides a simpler programming model for UI-centric applications where each page handles its own logic.
- **ASP.NET Core Web API**:
Builds **HTTP REST APIs** that return data (such as JSON) for browsers, mobile apps, desktop applications, or other services. It typically does not include server-rendered views.

**Other Visual Studio Templates include:**
- Blazor Web App: Builds interactive web applications using C# instead of JavaScript for much of the client-side logic.
- ASP.NET Core Empty: Creates a minimal project with only the essential infrastructure.
- ASP.NET Core gRPC Service: Builds high-performance RPC services using the gRPC protocol.
- ASP.NET Core Worker Service: Builds long-running background services that don't expose a web UI.

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
    ─ appsettings.Development.json
    ─ Program.cs
    ─ AspNetCoreDIDemo.csproj

# Project Building and Coding Sequence:
### Step#1:
You can review the details comments and explanations in **Program.cs** file. 

### Step2:
Creating a new folder **"Services"** to store our services, and creating the interface file **"IMusicService.cs"**.
We created the interface first so the consumer class (later, an ASP.NET Core Controller) will depend on an abstraction (interface), not directly on a concrete implementation class.

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
    > Controller == depends on ==> IMusicService (Contract) == implemented by ==> MusicService (Actual Code)

Then creating the **MusicService.cs** file that implements the interface.

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
This line uses "builder.Services" because the Services property is an "IServiceCollection", which is the collection where framework services, application services, and third-party services are registered with the built-in ASP.NET Core Dependency Injection container.

We followed this progression:
```bash
builder.Services (IServiceCollection): A collection of registration
    => ASP.NET Core framework service registrations
        => Logging service registrations
            => Configuration service registrations
                => Our custom service registrations
```
So our custom service is treated exactly like Microsoft's framework services.

**NOTE:**
The DI container does not treat our custom services differently. Once registered, our services can be injected in the same way as built-in ASP.NET Core services.

By the end of this step, we have done three things:
1. Created the contract (IMusicService)
2. Created the implementation (MusicService)
3. Registered it with the DI container

But nothing is using it yet.

### Step4:
Creating a Controller because this project uses the ASP.NET Core MVC template. Instead of using the default controller "HomeController", we will use another dedicated controller because it makes our DI example more clear.

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
                >> injected into >>
                    MusicController (consumer)
```

Please review the code and the detailed comments in **"MusicController.cs"**

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
