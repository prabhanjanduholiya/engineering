
## Top Level Statements - programs without Main methods

Starting in C# 9, you don't have to explicitly include a Main method in a console application project. Instead, you can use the top-level statements feature to minimize the code you have to write. In this case, the compiler generates a class and Main method entry point for the application.

Only one top-level file
An application must have only one entry point. A project can have only one file with top-level statements. Putting top-level statements in more than one file in a project results in the following compiler error:

CS8802 Only one compilation unit can have top-level statements.

No other entry points
You can write a Main method explicitly, but it can't function as an entry point. The compiler issues the following warning:

CS7022 The entry point of the program is global code; ignoring 'Main()' entry point.

Top-level statements are implicitly in the global namespace.



## Primary Constructors

class C(int i)
{
    protected int i = i; // references parameter
    public int I => i; // references field
}

# Framework
* Microsoft code definition of Linq method "firstOrDefault()", "singleOrDefault()".
* Difference vs value type and reference type
* virtual overrride shadowing
* protected internal, protected private
* stringlength vs maxlength in ef
* What are access modifiers in C#?
* Please let me which access modifiers are used with class?
* Please explain the differences between Internal and Protected internal?

### Indexes
* What are the Indexers.
* indexer overloading

### Collection
* Difference between ienumerator and ienumerble
* Which collection you choose in (Dictionary and Hash Table) for storing large amount of data and why?
* difference between first or default and single or default(Entity framework)
* Anonymous types, Anonymous methods
* IQueryable, ICollection, IDisposable interface
* How you will make your own custom collection class.
* generic Stack implementation without using build in functional  
* Expression Tree in detail
* Query Expression
* Lambda Expression 
* Ienumerable vs ienumerator vs ilist

### Delegate
* Difference between covariance and contravariance
* Difference between Func, Action and Predicate

# OOPS
* Contuctor Overloading
* SOLID principles.
* solid principle -liskhov substitution principle-practical questions
* What is d in solid principle. Show on white board.
* scenario based nested class inheritance, interface inheritance and calling of methods.
* scenario based constructor calling sequence including static constructor (execution flow)
* Polymorphism (Compile time and Run Time- Overloading and Overriding)
* Abstract class and methods, Sealed  classes
* Difference between abstract and interfaces and when to use where?

# Design Patterns
* What is Dependency Injection?
* What IOC containers have you used? How can you define the object usage as singleton type?
* Dependency injection without using constructor?
* Difference between singleton and static Class?
* How we can create Object Pooling.

----------------------------------------------
* Programs(given) output depending upon ref and polymorphism (overrride)
* DI(dependency inversion) vs DI (Dependency Injection)
* What is static constructor?
* nested try catch -- execution flow
* explicit calling of self and base constructors.
* parameterizedthreadstart
* Difference bw List and Dictionary (how they stored at backend)
* Difference between icomparable and icomparer
* Encapsulation vs Data Hiding vs Abstraction
* coupling vs cohesion (Simple Definition)
* Association,Aggregation and Composition
* Object mutation.
* Can we have abstract class without an abstract methods 
* Types of constructor? Private, Default, Static, Parametrized, Copy
* Is it possible to store n numer of lists of different types in single list?
* How to differ keys for Dev and Live environment in C#.
* String Interpolation
* Null Check Operators.
* Order of evaluation of the expressions in C#, Precedence of the operators
* IQueryable, ICollection, IDisposable interface
* Finalize vs Disposeand using statement in c#
* Run time polymorphism (using virtual, abstract, sealed)
* Entity Framework basics and  Lazy loding vs eager loading (in EF), when to use what?"
* stringlength vs maxlength in ef
* Contuctor Overloading
* What is Dependency Injection?
* What IOC containers have you used? How can you define the object usage as singleton type?
* Dependency injection without using constructor?
* Microsoft code definition of Linq method "firstOrDefault()", "singleOrDefault()".
* What are the Indexers.
* indexer overloading
* Difference between singleton and static Class?
* Difference between ienumerator and ienumerble
* Which collection you choose in (Dictionary and Hash Table) for storing large amount of data and why?
* How we can create Object Pooling.
* SOLID principles.
* solid principle -liskhov substitution principle-practical questions
* What is d in solid principle. Show on white board.
* scenario based nested class inheritance, interface inheritance and calling of methods.
* scenario based constructor calling sequence including static constructor (execution flow)
* Difference vs value type and reference type
* virtual overrride shadowing
* protected internal, protected private
* Ienumerable vs ienumerator vs ilist
* Programs(given) output depending upon ref and polymorphism (overrride)
* DI(dependency inversion) vs DI (Dependency Injection)
* What is static constructor?
* Polymorphism (Compile time and Run Time- Overloading and Overriding)
* Abstract class and methods, Sealed  classes
* Difference between abstract and interfaces and when to use where?
* difference between first or default and single or default(Entity framework)
* Anonymous types, Anonymous methods
* IQueryable, ICollection, IDisposable interface
* How you will make your own custom collection class.
* generic Stack implementation without using build in functional  
* nested try catch -- execution flow
* explicit calling of self and base constructors.
* parameterizedthreadstart
* Difference bw List and Dictionary (how they stored at backend)
* Difference between icomparable and icomparer
* Encapsulation vs Data Hiding vs Abstraction
* coupling vs cohesion (Simple Definition)
* Association,Aggregation and Composition
* Object mutation.
* Expression Tree in detail
* Query Expression
* Lambda Expression 
* Can we have abstract class without an abstract methods 
* Types of constructor? Private, Default, Static, Parametrized, Copy
* Is it possible to store n numer of lists of different types in single list?
* How to differ keys for Dev and Live environment in C.
* String Interpolation
* Null Check Operators.
* Order of evaluation of the expressions in C, Precedence of the operators
* IQueryable, ICollection, IDisposable interface
* Finalize vs Disposeand using statement in c
* Run time polymorphism (using virtual, abstract, sealed)
* Entity Framework basics and  Lazy loding vs eager loading (in EF), when to use what?"
* Please explain concepts of memory management and garbage collection in c#.
* Please explain uses of I disposable.
* Please explain difference between finalize and IDisposable. 
* Also let me know where I should write code that will be executed when finalized is called.
* Please explain about Abstract class.an We create object of Abstract Class. 
* Can I create constructor in abstract class? If yes, what is the benefit if I can’t create object of abstract class.
* Please explain about dependency injection and how you achieved that in your recent project. 
* Which container you have used for dependency injection.
* Please let me know about design patterns which you have used so far in your project. 
* Also explain about those patterns why you have used them in your project. 
* Please let me know why you have used Web API in your project and for which functionality. 
* Please explain about content negotiation in Web API.
* Please explain about delegating handlers in web API.

## .Net Core
* working of .net core application
* transient, scope and singleton in .net core
* deployment server options in .net core app
* differenct-2 server setup for differetnt-2 environment (dev, prod, QA)
* How to implement object pooling in .Net core?
----------------------------------------------------------------------------------------------------------------

* **What are Records in C#?**
Consider using a record in place of a class or struct in thefollowing scenarios:
   - You want to definea data model that depends on value equality.
   - You want to definea typefor which objects areimmutable.
