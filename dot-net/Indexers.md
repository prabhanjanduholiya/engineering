# Indexers 

* Indexers allows instance of any class or structure to be indexed as an array.
* Indexers are just for convinience

```
[access modifier] [return type] this [argument list]
{
get
  {
  
  }; 
  
set 
  {

  };
}
```

### Multi dimentional indexers
The multi-dimensional indexer is almost similar to multidimensional arrays. For the efficient content-based retrieval of data, multidimensional indexers are used. To create multi-dimensional indexer you have to pass at least two parameters in the argument list of indexer declaration. To access a single element of a multi-dimensional indexer, use integer subscripts. Each subscript indexes a dimension like the first indexes the row dimension, the second indexes the column dimension and so on.

```
// C# program to illustrate the
// Multidimensional Indexers
using System;


class GFG {
	
	// reference to underlying 2D array
	int[, ] data = new int[5, 5];
	
	
	// declaring Multidimensional Indexer
	public int this[int index1, int index2]
	{
		// get accessor
		get
		{
			
			// it returns the values which
			// read the indexes
			return data[index1, index2];
			
		}
		
		// set accessor
		set
		{
			
			// write the values in 'data'
			// using value keyword
			data[index1, index2] = value;
			
		}
	}
}

// Driver Class
class Geeks {
	// Main Method
	public static void Main(String []args)
	{
		
		// creating the instance of
		// Class GFG as "index"
		GFG index = new GFG();
		

		// assign the values accordingly to
		// the indexes of the array
		// 1st row
		index[0, 0] = 1;
		index[0, 1] = 2;
		index[0, 2] = 3;
		
		// 2nd row
		index[1, 0] = 4;
		index[1, 1] = 5;
		index[1, 2] = 6;
		
		// 3rd row
		index[2, 0] = 7;
		index[2, 1] = 8;
		index[2, 2] = 9;
	
		// displaying the values
		Console.WriteLine("{0}\t{1}\t{2}\n{3}\t{4}\t{5}\n{6}\t{7}\t{8}",
								index[0, 0], index[0, 1], index[0, 2],
								index[1, 0], index[1, 1], index[1, 2],
								index[2, 0], index[2, 1], index[2, 2]);
	
	}
}

```
### Indexers overloading 
Like functions, Indexers can also be overloaded. In C#, we can have multiple indexers in a single class. To overload an indexer, declare it with multiple parameters and each parameter should have a different data type. Indexers are overloaded by passing 2 different types of parameters. It is quite similar to method overloading.

```
// C# Program to illustrate
// the overloading of indexers
using System;

namespace HelloGeeksApp {
	
class HelloGeeks {
	
	// private array of
	// strings with size 2
	private string[] word = new string[2];
	
	// this indexer gets executed
	// when Obj[0]gets executed
	public string this[int flag]
	{
		
		// using get accessor
		get
		{
			string temp = word[flag];
			return temp;
		}
		
		// using set accessor
		set
		{
			word[flag] = value;
		}
	}
	
	// this is an Overloaded indexer
	// which will execute when
	// Obj[1.0f] gets executed
	public string this[float flag]
	{
		
		// using get accessor
		get
		{
			string temp = word[1];
			return temp;
		}
		
		// using set accessor
		set
		{
			
			// it will set value of
			// the private string
			// assigned in main
			word[1] = value;
			
		}
	}
	
// Main Method
static void Main(string[] args)
{
	HelloGeeks Obj = new HelloGeeks();
	
	Obj[0] = "Hello"; // Value of word[0]
	
	Obj[1.0f] = " Geeks"; // Value of word[1]
	
	Console.WriteLine(Obj[0] + Obj[1.0f]);
}
}
}

```
