# Records in C#
You want to define a type for which objects are immutable. Meaning once initailized properties can't be updated.

###### Usage of 'With' in Records: 
 
# Collections

### What is difference between `Array` and `ArrayList`?
ArrayList represents ordered collection of an object that allows dynamic memory allocation.

|Array|ArrayList|
|-----|---------|
|Array's size is fixed, it can't be increased|Size of arraylist can be increased dynamically|
|Array can store only one data type of object|Arralist can stores objects of different data types|
|It can't be null|It can be null|
|Insertion/Deletion is fast|Insertion/Deletion is slower than Arrays|
|`int[] arr =  new int[4]();`|`ArrayList list= new ArrayList();`|
###### In which scenario which collection you choose?
 
##### HashTable vs Dictionary
* Both are key value pair collections. 
* HashTable uses HashCode of key for identification. 
* HashTable is non generic collection while dictionary is a generic collection.
* If key not present in hashtable it returns null while dictionary throws error.
 
### Thread Safe Collections
* Multiple threads can safely add/remove items from collection without any synchronization logic
* Namespace "System.Collection.Concurrent" includes several thread safe collection classes.

#### Sorted Collections Types
These are key value collection types where items are inserted as per ascending order of keys.
 
#### Immutable Collections Types
* We can't change the value of any item.
* We still can add/remove items.

## Generics
"We create a class once and use it multiple times with various different type of data". 

#### What problem `Generics` solve?
It helps to maxmize code reusability, type safety and perfromance.

## Lambda expressions
Lambda expressions are just anonymous methods. We use them for convenience and code reusability.

## Diiference between `IEnumerable` and `IQuerable` interfaces.
While querying data from database =>

* IEnumerable executes select query on server side, brings all data and then it applies filter on in memory data. It makes the operation costly and slow.

while 
* IQuerable executes query with filters on server side resulting less network traffic and fast queurying.
* IEnumerable is best for `LINQ to XML`
* IQuerable is best for `LINQ to SQL`


## Diiference between `IEnumerable` and `IEnumerator` interfaces.
Both interfaces has methods for iterating over a collection.

* `IEnumerable` internally uses `IEnumerator` for traversing and it provides simple and easy way for iterating without maintaining the state.
* `IEnumerator` mentains the state while treversing. 
   IEnumerator has following methods: 
    * MoveNext()
    * Reset
    * Current [Property]


## Diiference between `IEnumerable`, `ICollection`  and `IList` interfaces.

> `IEnumerable`---> (inherit) `ICollection`  ---> (inherit) `IList`

* `IEnumerable` contains methods for querying or retrieving data.
* `ICollection` has methods to count and syncronization.
* `IList` add method for inserting and removing items from collection.


## Sorting a list of complex type using 'IComparable', 'IComparer' and 'Comparison Delegate'

Let's suppose we have a collection of a class type 'Student'. 
```
public class Student
{
  public int Age { get; set; }
  public string Name { get; set; }
}
```

 ``` 
 List<Student> students= new List<Student>();
     
     var student1 = new Student()
     {
        Id = 1;
        Name = "Prabhanjan";
     };
     
     var student2 = new Student()
     {
        Id = 2;
        Name = "Duholiya";
     };
     
     students.Add(student1);
     students.Add(student2);
   ``` 
     
Now lets try to sort list of students by calling ```students.Sort();```, We see an error like 
"Can't sort, Student doesn't implement IComparable or IComparer". 

`Now fix this error` 

### By Implementing `IComparable` interface:

``` 
public class Student : IComparable<Student>
 {
      public int Age { get; set; }
      public string Name { get; set; }
      
      public int CompareTo(Student studentToCompareWith)
      {
        return this.Age.CompareTo(studentToCompareWith.Age);
      }
 }
 ```
    
Here we made the student class comparable that compares age but if we want to do comparison on some other fields or customized comparison, we may not be able to modify the class.
May be source is not available etc then we need to create a comparer by implementing `IComparer`

### By Implementing `IComparer` interface: 

IComparer method has a method that takes two arguments to compare.

```
public class SortByNameComparer : IComparer
{
  public int Compare(Stuednt studnet1,Stuednt studnet2)
  {
   // Customized comparison
  }
}
```
Now sort by name as following

```
students.Sort(new SortByNameComparer());
```

### By using Comparison delegate
Comparison delegate also has two parameters similar to IComparer. 


## Lambda Expressions

Lambda expressions are anonymous methods used for convenyence.


### Collection, Generics, Lambda Expressions:
* What is Generics?
* Why Generic is required.
* Can we inherit genric class
* ## Generics
"We create a class once and use it multiple times with various different type of data". 
* What are Generics?
* Why Generic is required.
* What problem `Generics` solve?
* What are Lambda expressions?

#### What problem `Generics` solve?
It helps to maxmize code reusability, type safety and perfromance.

## Lambda expressions
Lambda expressions are just anonymous methods. We use them for convenience and code reusability.
