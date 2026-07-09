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
    - MOTE => Dependencies might not be set at object creation time which may lead to potential null reference exception
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
    - Best practices
    - Common DI mistakes
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

# Credits, References, and Resources:
- [Microsoft Visual Studio](https://visualstudio.microsoft.com/)
- [C# Classes](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes)
- [Constructors (C# programming guide)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors)
- [Access modifiers (C# programming guide)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers)
- [Interfaces - define behavior for multiple types](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces)
- [Dependency Injection in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [Dependency Injection Guidelines](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-guidelines)
- [ASP.NET Core DI Overview](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-10.0)
- My Other .NET Stack Repos:
   - .NET and C# Intro:
      - https://github.com/anmarjarjees/dotnet-csharp-intro
   - C# Essentials:
      - https://github.com/anmarjarjees/csharp-essentials
   - C# Intro:
      - https://github.com/anmarjarjees/csharp-intro
