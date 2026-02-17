# Design Patterns

Design patterns are solutions to software design problems you find again and again in real-world application development. Patterns are about reusable designs and interactions of objects.

The 23 Gang of Four (GoF) patterns are generally considered the foundation for all other patterns. 

They are categorized in three groups: 
###### Creational Patterns: 
The Creational Design Pattern deals with object creation mechanisms; trying to create objects in a manner suitable to the situation.

###### Structural Patterns:
* Structural design patterns are concerned with how classes and objects can be composed, to form larger structures.
* The structural design patterns simplifies the structure by identifying the relationships.
* These patterns focus on, how the classes inherit from each other and how they are composed from other classes.

###### Behavioral patterns:
Behavioral design patterns are concerned with the interaction and responsibility of objects.
In these design patterns, the interaction between the objects should be in such a way that they can easily talk to each other and still should be loosely coupled.

| Creational design patterns                                       |Structural design patterns         | Behavioural design patterns|
|------------------------------------------------------------------|-----------------------------------|-----------------------------------|
| [Builder](creational/Builder.md)                                 |[Adapter](structural/Adapter.md)   |Command                            |
| [Factory](creational/Factory_Abstract_Factory.md)                |[Facade](structural/Facade.md)     |Mediator                           |
| [Abstract Factory](creational/Factory_Abstract_Factory.md)       |Decorator                          |Observer                           |
| Singelton                                                        |Bridge                             |Startegy                           |
| Prototype                                                        |Composite                          |Visitor                            |
|Object pooling design pattern                                     |[Proxy](behavioural/Proxy.md)      |                                   |
|                                                                  |Flyweight                          |                                   |

## FAQ
#### Which Design patterns have you implemented?
#### What do you understand by IOC (Inversion of control) design pattern?
You should depend on abstractions instead oc concrete implementation.
#### What is dependency injection?
#### Why we need double null check in singelton pattern?

```
public static MyClass GetInstance()
{
    if (obj==null) // Avoid unnecessary locking of resource
    {
      lock()
      {
        if(obj==null)
        {
          obj = new MyClass();
          return obj;
        }
      }
    }
    else
    {
      return obj;
    }
}
```

## Object pooling design pattern
* It is a creational design pattern, that helps when creation of an object is costly it impacts the performance of application.
* A container or collection holds the object those are ready to be used. Once it is taken from the pool, it is not available till it is back into the pool.

#### How to implement object pooling in .Net core?
`Microsoft.Extensions.ObjectPool` nuget is the part of ASP.Net core infrastructure that supports object pooling. 

## Proxy design pattern 

Proxy pattern is used when we need to create a wrapper to cover the main object’s complexity from the client.

## Factory Design pattern
Factory pattern is one of the most used design patterns in Java. This type of design pattern comes under creational pattern as this pattern provides one of the best ways to create an object.

In Factory pattern, we create object without exposing the creation logic to the client and refer to newly created object using a common interface.
<img width="460" alt="Factory" src="https://user-images.githubusercontent.com/31764786/142975264-3a31b571-8091-4ac6-9feb-ec42795bc7a1.PNG">

## Factory Method Design Pattern

## Abstract Factory Design pattern
Abstract Factory patterns work around a super-factory which creates other factories. This factory is also called as factory of factories. This type of design pattern comes under creational pattern as this pattern provides one of the best ways to create an object.

In Abstract Factory pattern an interface is responsible for creating a factory of related objects without explicitly specifying their classes. Each generated factory can give the objects as per the Factory pattern.

![AbstractFactoryPattern-2](https://user-images.githubusercontent.com/31764786/142975329-acad232f-aef9-4798-ae54-f7fbeea37937.png)

# Builder design pattern

Piecewise construction of an object is served by builder pattern.

### What problem does it solves? 
* Sometimes creation or initialization of an object is complex task to make it ready to use.
* Builder pattern provides a way to construct an object in step by step or piecewise way not the whole object in one go.

### UML Diagram
![Builder Pattern](https://user-images.githubusercontent.com/31764786/142841020-d0b3b02e-f1bb-4a4e-b31b-6977f8a64853.jpg)

##### Product – 
The product class defines the type of the complex object that is to be generated by the builder pattern.

##### Builder – 
This abstract base class defines all of the steps that must be taken in order to correctly create a product. Each step is generally abstract as the actual functionality of the builder is carried out in the concrete subclasses. The GetProduct method is used to return the final product. The builder class is often replaced with a simple interface.

##### ConcreteBuilder – 
There may be any number of concrete builder classes inheriting from Builder. These classes contain the functionality to create a particular complex product.

##### Director – 
The director-class controls the algorithm that generates the final product object. A director object is instantiated and its Construct method is called. The method includes a parameter to capture the specific concrete builder object that is to be used to generate the product. The director then calls methods of the concrete builder in the correct order to generate the product object. On completion of the process, the GetProduct method of the builder object can be used to return the product.

### Example: 
# Facade Design Pattern

* It is a structural design pattern
* Facade provides a higher level interface that makes the sub systems easier to use.
* It hides the complexity of whole system that is composed of multiple components or sub systems. 
* Client of the system intracts with the facade only. 

![facadeA](https://user-images.githubusercontent.com/31764786/142854166-eed10c0f-a518-44d9-aded-b115b02cee79.png)



# Adapter Design Pattern

The adapter pattern convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn’t otherwise because of incompatible interfaces.

To use an adapter:

* The client makes a request to the adapter by calling a method on it using the target interface.
* The adapter translates that request on the adaptee using the adaptee interface.
* Client receive the results of the call and is unaware of adapter’s presence.

### What problem it solves? 
* Let's suppose we have a legacy component that is not compatible with the technology or application you are developing.
* Client only knows the target interface.

### UML 
![Adapter](https://user-images.githubusercontent.com/31764786/142974088-7e66def4-a3e5-4048-be6c-b1366f865608.jpg)

