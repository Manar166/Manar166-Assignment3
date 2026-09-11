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
    static void Main(string[] args)
    {
        Console.WriteLine("=== PART A: Project & Structure ===");
        RunTypesDemo();



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


}



