# unity-point-and-click-sandbox

## Coding conventions

### Order in class

According to the StyleCop Rules Documentation the ordering is as follows.

Within a class, struct or interface: (SA1201 and SA1203)

* Constant Fields
* Fields
* Constructors
* Finalizers (Destructors)
* Delegates
* Events
* Enums
* Interfaces (interface implementations)
* Properties
* Indexers
* Methods
* Structs
* Classes

Within each of these groups order by access: (SA1202)

* public
* internal
* protected internal
* protected
* private

Within each of the access groups, order by static, then non-static: (SA1204)

* static
* non-static
 
Within each of the static/non-static groups of fields, order by readonly, then non-readonly : (SA1214 and SA1215)

* readonly
* non-readonly

An unrolled list is 130 lines long, so I won't unroll it here. The methods part unrolled is:

* public static methods
* public methods
* internal static methods
* internal methods
* protected internal static methods
* protected internal methods
* protected static methods
* protected methods
* private static methods
* private methods

The documentation notes that if the prescribed order isn't suitable - say, multiple interfaces are being implemented, and the interface methods and properties should be grouped together - then use a partial class to group the related methods and properties together.