# SOLID principles

##### Single responsibility principle:
A class should be responsible for single functionality. There should be one reason to change. 

##### Open closed principle:
"A class should be open for extension while closed for modification." 

It tells you to write your code so that you will be able to add new functionality without changing the existing code. That prevents situations in which a change to one of your classes also requires you to adapt all depending classes.

Solution: Initially a solution was suggested using inheritance but inheritance comes with drawback of tight coupling so we can use interfaces and thier multiple implementations can be injected without making chnages to their existing classes.

##### Liskov subsitution principle:
* objects of a superclass shall be replaceable with objects of its subclasses without breaking the application. 
* That requires the objects of your subclasses to behave in the same way as the objects of your superclass

An overridden method of a subclass needs to accept the same input parameter values as the method of the superclass. That means you can implement less restrictive validation rules, but you are not allowed to enforce stricter ones in your subclass. Otherwise, any code that calls this method on an object of the superclass might cause an exception, if it gets called with an object of the subclass.

Similar rules apply to the return value of the method. The return value of a method of the subclass needs to comply with the same rules as the return value of the method of the superclass. You can only decide to apply even stricter rules by returning a specific subclass of the defined return value, or by returning a subset of the valid return values of the superclass.

##### Interface segregation rule:
Inetent of this rule is, a client should not be forced to reference an interface which is not used by him. Sub modules of any class must be segregated by their own interfaces.

##### Dependency inversion rule:
A class should depend on abstractions rather than concrete types. 
