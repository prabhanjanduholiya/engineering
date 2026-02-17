# Garbage collection in .Net
Garbage collection is an automated process that is that is able to find out which objects are needed to get rid of by freeing up memory.

### Can we force Garbage collector to run?
Yes, we by calling `GC.Collect()`.

### Managed Heap: 
Memory that is managed by CLR.

### When garbage collection occurs?
Garbage collection occur when either of condition met.
* System has low physical memory.
* If memory allocated to various objects in the heap exceeds the preset threshold.
* By calling GC.Collect().

### What are phases in garbage collection?
* Marking phase -> List of live objects created
* Relocating phase -> References to live objects updated
* Compacting phase -> Dead objects released and live objects gets moved to next genration.

### Genrations: 
* Gen 0 => Short lived objects
* Gen 1 => 
* Gen 2 => Holds long lived objects like global variable, static objects

### What happens during garbage collection?



# Disposing unmanaged resources

## Finalize() 
* This is used to release unmanged resources. `Finalize` method is called by garbage collector, we can't call it explicitly. 
As garbage collector claims memory for managed resources, it also checks if the class has implemented `finalize` method. If yes the GC moves the object to finalize queue. 
* At compile time, destructor is converted into finalize method.

But here is an issue, checking of finalize method is very less so unmanged resources are still alive in heap for unknown duration of time or may be even till the lifetime of application.

Solution to above issue using `GC.Collect` method.

## GC.Collect()
This method can be used to de-allocate memory for unmanged resources in finalize queue, but it is very expensive operation as it passes through all genrations each time.

Now what, implement `IDisposable` for releasing unmanged resources.

## Implement IDisposable interface
For releasing unmanaged resources, this interface has method called `Dispose`. 

By implementing this pattern, we get more control for disposing unmanged resources like whenever we want.

By `Using` block, at the end it will call `dispose` method.

```
public class DisposableService : IDisposable
{
private bool isDisposed = false;

  ~DisposableService()
  {
    Dispose(false);
  }
  
  public void Dispose()
  {
    Dispose(true);
    GC.SupressFinalize();
  }
  
  protected void Dispose(bool disposed)
  {
    if(!isDisposed)
    {
      if(dispose)
      {
        // Release unmanged resource
      }
      
      isDisposed = true;
    }
  }

}
```

This pattern has both `Finalize` and `Dispose` implementation.

#### `Finalize` is required, if user fails to call dispose method.

## GC.SupressFinalize()

It simply prevents the finalizer being called. It should not be called, if dispose of unmanaged resources is alread done. 
It gives small performance improvement. 

### GC & Memory management:
* Garbage Collection and its working?
* Memory management of a Class?
* Use of Garbage Collection, manually?
* Memory management in case of File reading?
* Finalizer
* GC collection- How GC decides when to dispose the object.
* GC.SuppressFinalize
* Explain memory model of .net ----------------------------------------------------[Pending]
* How stack and heap actually store the data and where the local variables to a method get stored? ------------------------------------[Pending]
* CLR
* What is Garbage Collection?
* How Garbage collection works internally?
* Memory management of a Class?
* How to Use of Garbage Collection, manually?
* How to do Memory management in case of File reading?
* What is Finalizer?
* How GC decides when to dispose the objects?
* What is GC.SuppressFinalize()
* Explain memory model of .net 
* How stack and heap actually store the data and where the local variables to a method get stored? 

