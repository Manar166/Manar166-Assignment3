using System.Collections;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace CSharpBasicsAssignment;

/*
.csproj:
1-بيقولي علي شوية اعدادات شغاله ولا لا 
2- بيعرفني الversion of .Net of project 
3-knows the liberaries the project uses 
4- بيعرفني البروجيكت بيسخدم من قبل بروجيكت تاني ولا لا
--------------------
program.cs:
the entry point of the project contains main method and the code to run the project
-----------------
obj:
1- cashing for re running the project
2-knows the new added code and compiles it 
2- contains the IL code of the project
------------------------
.bin:
1-contains the assembly files (.exe or .dll)







*/
/*
my project uses .slnx 
advantage of sln vs slnx : is compatibility with older versions of visual studio and .net framework


*/

class Program
{
    private int privateField = 42; // This is a private field
    static void Main(string[] args)
    {
        Console.WriteLine("=== PART A: Project & Structure ===");
        RunTypesDemo();
        Console.WriteLine("=== PART C: Value VS ReferenceType ===");
        RunValueVsReferenceDemo();
        ReadPrivateField();

        DemonstrateCompoundOperators();
        LocalVariablescopeDemo();
        BitWiseOperatorsDemo();






    }

    // --------- Part B--------
    static void RunTypesDemo()
    {
        int intNumber = 42;
        long longNumber = 1234567890123456789;
        double myDouble = 9.99;
        decimal myDecimal = 19.99m;
        bool myBool = true;
        char myChar = 'A';
        string myString = "Hello";
        var myInferred = 42;

        Console.WriteLine($"int: {intNumber} | Type: {intNumber.GetType()}");
        Console.WriteLine($"long: {longNumber} | Type: {longNumber.GetType()}");
        Console.WriteLine($"double: {myDouble} | Type: {myDouble.GetType()}");
        Console.WriteLine($"decimal: {myDecimal} | Type: {myDecimal.GetType()}");
        Console.WriteLine($"bool: {myBool} | Type: {myBool.GetType()}");
        Console.WriteLine($"char: {myChar} | Type: {myChar.GetType()}");
        Console.WriteLine($"string: {myString} | Type: {myString.GetType()}");
        Console.WriteLine($"var (inferred): {myInferred} | Type: {myInferred.GetType()}\n");

        //------2--------

        // no casting required because it can be done logically and safely with no loss of data
        int number = 10;

        long implicitLong = number; // Implicit conversion

        Console.WriteLine($"Implicit conversion from int to long: {implicitLong} | Type: {implicitLong.GetType()}");

        char letter = 'A';
        int implicitInt = letter; // Implicit conversion

        // prints the value of the char as an integer (ASCII value)
        Console.WriteLine($"Implicit conversion from char to int: {implicitInt} | Type: {implicitInt.GetType()}");

        //------------------3-------------------
        double doubleValue = 9.78;
        int explictInt = (int)doubleValue; // Explicit conversion (casting)
        Console.WriteLine($"Explicit conversion from double to int: {explictInt} | Type: {explictInt.GetType()}");

        int convertInt = Convert.ToInt32(doubleValue); // Using Convert class
        Console.WriteLine($"Using Convert class: {convertInt} | Type: {convertInt.GetType()}");

        // explict casting truncates the decimal part, while Convert rounds the value to the nearest integer.

        // -----------4-------------

        int number1 = 5 / 2;
        double number2 = 5.0 / 2.0;
        Console.WriteLine($"Integer division: {number1} | Type: {number1.GetType()}");
        Console.WriteLine($"Double division: {number2} | Type: {number2.GetType()}");

        //integer division, the result is an integer and any fractional part is discarded.
        //In double division, the result is a double and retains the fractional part.


        // -----------5-------------
        int boxedInt = 42; // Boxing
        Object boxedObject = boxedInt; // Boxing

        Console.WriteLine($"Boxed int: {boxedObject} | Type: {boxedObject.GetType()}");

        int unboxedInt = (int)boxedObject; // Unboxing
        Console.WriteLine($"Unboxed int: {unboxedInt} | Type: {unboxedInt.GetType()}");

        // --------------6-------------

        string strNumber = "123";

        int parsedInt = int.Parse(strNumber); // Using Parse method
        Console.WriteLine($"Parsed int using Parse method: {parsedInt} | Type: {parsedInt.GetType()}");

        string badStrNumber = "abc";

        bool successed = int.TryParse(badStrNumber, out int result); // Using TryParse method)
        Console.WriteLine($"TryParse result: {successed},{result}");


        //--------------7-------------

        float floatValue = 3.14f;
        // decimal decimalValue = floatValue;

        // cannot implicitly convert float to decimal because decimal is base 10 precision
        // and float is base 2 precision, so there could be a loss of precision in the conversion.

        decimal decimalValue = (decimal)floatValue; // Explicit conversion from float to decimal
        Console.WriteLine($"Explicit conversion from float to decimal: {decimalValue} | Type: {decimalValue.GetType()}");


    }

    static void RunValueVsReferenceDemo()
    {
        Point p1 = new Point() { X = 1, Y = 2 };
        Point p2 = p1;
        p1.X = 99;
        Console.WriteLine($"p1.X={p1.X}"); // prints 99
                                           // struct is a value type, so when we assign p1 to p2,
                                           // a new copy of the data is created in memory.

        Order o1 = new Order
        {
            OrderId = 101,
            CustomerName = "Manar",
            Quantity = 2,
            UnitPrice = 50.00m,
            IsPaid = false,
            DiscountPercent = 10.0,
            ShippingCity = "Cairo",
            Priority = 'H',
            ItemCode = 9876543210L
        };

        o1.CalculateTotal();
        o1.PrintSummary();
        Order o2 = o1;
        o2.IsPaid = true;
        Console.WriteLine($"o1.IsPaid={o1.IsPaid}");  // prints true
        Console.WriteLine($"o2.IsPaid={o2.IsPaid}"); // prints true

        // class is a reference type, so when we assign o1 to o2,
        // both variables point to the same object in memory(heap).

        object boxedOrder = o1;

        Order o3 = (Order)boxedOrder;
        Console.WriteLine($"o1 and o3 are the same instance: {object.ReferenceEquals(o1, o3)}");
        o2.PrintSummary();

        /* 1- where each kind of data lives(stack vs.heap)?
         * stack: value types like structs and premitive types 
         * heap:reference types like classes and objects 
         * 2- what "assignment" actually copies for a value type vs. a reference type?
         * for value types :copies the actual data 
         * for reference type:copies the address of the object in heap ,
         * so both variables points tonthe same object in heap
         * 3-why storing a reference type inside an object variable does not create a new object ?
         *  because the object variable is just a reference to the same object in heap,
         *  it just copis the address of the object in heap to the object variable

        */


    }

    static void ReadPrivateField()
    {
        Program programInstance = new Program();
        Console.WriteLine(programInstance.privateField);
    }
    static void ReadPrivateFieldFromAnotherMethod()
    {
        Program programInstance = new Program();
        Console.WriteLine(programInstance.privateField);
    }

    static void LocalVariablescopeDemo()
    {
        int localVariable = 10; // This variable is only accessible within this method
        Console.WriteLine($"localVariable = {localVariable}");

        for (int i = 0; i < 3; i++)
        {
            int loopVariable = i * 2; // This variable is only accessible within this loop
            Console.WriteLine($"loopVariable = {loopVariable}");
        }
        // Attempting to access block - scoped variables outside the loop:
        // Console.WriteLine(i);             // CS0103: The name 'i' does not exist in the current context
        // Console.WriteLine(loopVariable); // CS0103: The name 'loopVariable' does not exist in the current context
        // Explanation: Both 'i' and 'loopVariable' are allocated on the stack within the loop block
        // and destroyed as soon as execution leaves the loop scope.
    }

    private static void DemonstrateCompoundOperators()
    {
        Console.WriteLine("--- D2: Compound Assignment Operators ---");
        int total = 100;

        Console.WriteLine($"Initial total: {total}");

        total += 20; // Equivalent to: total = total + 20;


        Console.WriteLine($"After += 20: {total}");

        total = total + 20;
        Console.WriteLine($"After += 20: {total}");

        total -= 15;
        Console.WriteLine($"After -= 15: {total}");

        total *= 2;
        Console.WriteLine($"After *= 2:  {total}");

        total /= 5;
        Console.WriteLine($"After /= 5:  {total}");

        total %= 7;
        Console.WriteLine($"After %= 7:  {total}\n");



    }

    static void BitWiseOperatorsDemo()
    {
        int a = 12;  // Binary: 1100
        int b = 10;  // Binary: 1010
        Console.WriteLine($"a & b = {a & b}");   // Bitwise AND
        Console.WriteLine($"a | b = {a | b}");   // Bitwise OR
        Console.WriteLine($"a ^ b = {a ^ b}");   // Bitwise XOR

        //& operator compares each bit of the first operand to the corresponding bit of the second operand.
        //If both bits are 1, the corresponding result bit is set to 1. Otherwise, it is set to 0. 
        // && operator is a logical AND operator that evaluates the second operand only if the first operand is true.
        //what happens differently when the left operand is false in an if-condition?
        // the right operand is not evaluated at all, and the entire expression evaluates to false.

    }

    struct Point
    {

        public int X;
        public int Y;
    }
}







