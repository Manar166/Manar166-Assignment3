```text

Order o1 = new Order { OrderId = 1, CustomerName = "Ali" };
       STACK                                     HEAP
+-------------------+                   +-------------------+
|                   |                   |   Object Instance |
                    |                   |
|                   |                   |  Address: 0x00A1  |
|                   |                   |   OrderId = 1     |
|                   |                   |CustomerName = "Ali" 
+-------------------+                   |                   |
|  o1 [0x00A1] -----+------------------+|                   |
+-------------------+                   +-------------------+

object created in the heap memory and o1 is a reference variable t
hat holds the address of the object instance in the heap memory. 
The object instance contains the properties OrderId and CustomerName with their respective values.

```

```text
Order o2 = o1;

       STACK                                     HEAP
+-------------------+                   +-------------------+
|                   |                   |   Object Instance |
+-------------------+                   +-------------------+
|  o2 [0x00A1] ----+------------------->|  Address: 0x00A1  |
|                   |                   |  OrderId = 1      |
|  o1 [0x00A1] -----+-----------------'  CustomerName = "Ali"    |
+-------------------+                   +-------------------+

reference variable o2 is created and assigned the value of o1
which is the address of the object instance in the heap memory.

```

 ```text

 o2.IsPaid = true;

       STACK                                     HEAP
+-------------------+                   +-------------------+
|   Variable / Ref  |                   |   Object Instance |
+-------------------+                   +-------------------+
|  o2 [0x00A1] ----+------------------->|  Address: 0x00A1  |
|                   |                   |  Type: Order      |
|  o1 [0x00A1] -----+-----------------'>|  IsPaid = true    |
+-------------------+                   +-------------------+

when the property IsPaid is set to true using the reference variable o2,
it modifies the object instance in the heap memory.
Since both o1 and o2 reference the same object instance, 
the change is reflected when accessing the object through either reference variable.
```

 "What would be different with structs?" 
 1- the variable would be stored in the stack memory instead of the heap memory.
 2- when you assign one struct variable to another,
 a copy of the value is made, 
 so changes to one variable do not affect the other.
 3- when fields of a struct are modified,
 it does not affect other instances of the struct, 
 as each instance has its own copy of the data.
