# Delegates
Delegates are pointer to the functions that knows how to call a method or group of methods. 

#### Why we Need Delegates?
Delegates are needed to design flexible applications or frameworks that allow invocation and binding of method definations at runtime.

### Multicast Delgate: 
Multicast delegates allows to invoke multiple methods. We can say it has multiple function pointers while Delegate has single function pointer.

* Multicast delegate instance has a property called `InvocationList` that has list of all methods to be executed.

### `action` delegate VS `func` delegate:
Both are inbuilt delegates in .Net framework that allow invocation of methods. 

"Action delegate return void while func delegate return a value."

### `predicate`:
Inbuilt delegate that takes a parameter and return boolean value. It represents a method that has some logic to verify if passed parameter matches that criteria.

* Prdicates are wildly used for filtering out collections.

``` public delegate bool Predicate<in T>(T obj);```

## Using Variances in delegates
When you assign a method to a delegate, covariance and contravariance provide flexibility for matching a delegate type with a method signature. 
* `Covariance` permits a method to have return type that is more derived than that defined in the delegate. 
* `Contravariance` permits a method that has parameter types that are less derived than those in the delegate type.

###### Example Covariance: 
This example demonstrates how delegates can be used with methods that have return types that are derived from the return type in the delegate signature. The data type returned by DogsHandler is of type Dogs, which derives from the Mammals type that is defined in the delegate.

``` 
class Mammals {}  
class Dogs : Mammals {}  
  
class Program  
{  
    // Define the delegate.  
    public delegate Mammals HandlerMethod();  
  
    public static Mammals MammalsHandler()  
    {  
        return null;  
    }  
  
    public static Dogs DogsHandler()  
    {  
        return null;  
    }  
  
    static void Test()  
    {  
        HandlerMethod handlerMammals = MammalsHandler;  
  
        // Covariance enables this assignment.  
        HandlerMethod handlerDogs = DogsHandler;  
    }  
}
```
###### Example Contravariance: 

This example demonstrates how delegates can be used with methods that have parameters whose types are base types of the delegate signature parameter type. With contravariance, you can use one event handler instead of separate handlers. The following example makes use of two delegates:

``` 
delegate Child GetChild(Child child);

static Child MyMethod(Base b)
{

}

// This is enabled by contravariance
GetChild child = MyMethod;
```

# Events
* A mechanism for communication among objects.
* Used in loosely coupled applications.

See [Code to learn repo]

### Events & Delegates:
* What are events in C#.
* What are delegates in C#.
* event vs delegate
* Different use case of delegates.
* Why do we need delegates if we can call methods directly.
* What are multicast delegates.
* Real time use cases of Delegates?
* what will happen if any exception occurs in multicast delegate. If rest methods doesn't execute how to execute those.
* delegate is reference type
* Publisher subscriber using events
* Why we need delegate in custom event handler
* Asynchronous delegates
* What is your idea of Delegate
* We can pass Delegate as parameter to function.
* What are events in C.
* What are delegates in C.
* event vs delegate
* Different use case of delegates.
* Why do we need delegates if we can call methods directly.
* What are multicast delegates.
* Real time use cases of Delegates?
* what will happen if any exception occurs in multicast delegate. If rest methods doesn't execute how to execute those.
* delegate is reference type
* Publisher subscriber using events
* Why we need delegate in custom event handler
* Asynchronous delegates
* What is your idea of Delegate
* We can pass Delegate as parameter to function.
* What are events in C#?
* What are delegates in C#?
* What is difference between event and delegate?
* What are different use case of delegates.
* Why do we need delegates if we can call methods directly.
* What are multicast delegates.
* What are real time use cases of Delegates?
* What will happen if any exception occurs in multicast delegate. 
  If rest methods doesn't execute how to execute those.
* Why we need delegate in custom event handler?
* What are Asynchronous delegates?
