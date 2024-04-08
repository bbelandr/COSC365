A lot of things are similar. Here are some differences:
# Skeleton of Main
```cs
static void Main(string[] args) {
	Console.WriteLine("Hello to me!");
}
```

# Printing in C
You can use curly brackets to print the first, second, or third argument in the parameter list. Here's an example:
```cs
int a = 0;
int b = 1;
int c = 2;

Console.WriteLine("b is {1}, c is {2}, and a is {0}.", a, b, c);
```

To add elements to a print statement, one should use the + sign instead of a comma. 
# For Each
```cs
foreach(var item in lis) {
	Console.WriteLine(item);
}
```

# Lists

# Arrays
### Declarations
Static array declaration:
```cs
int[] numbers = {1, 2, 3};
Console.WriteLine(numbers[2]);
```

Dynamic array:
```cs
int[] numbers = new int[5];
numbers[0] = 89;
numbers[1] = 10;
Console.WriteLine(numbers[0]);
```


String to char[]
```cs
// Taking a string and turning it into a character array
string ass = "this is a funny string";
char[] array = ass.ToCharArray();
Array.Reverse(charArray);
foreach(char assChar in array) {
	console.WriteLine(assChar);
}
```

### Arithmetic Ops
Sum() and Count():
```cs
int[] numbers = {23, 21, 41, 5};
float sum = numbers.Sum();
int count = numbers.Count();
float average = sum/count;

Console.WriteLine("The average is {0} and the count is {1}", average, count);
```
There also is just a straight up Average():
```cs
int[] nums = {10, 20, 4};
Console.WriteLine("The average is {0}", nums.Average());
```
### Sorting and Similar
Min and max are members of the normal array type:
```cs
int[] numbers = {1, 2, 3};
Console.WriteLine("Smallest Element: " + numbers.Min());
Console.WriteLine("Largest Element: " + numbers.Max());
```

# 2D Arrays
Are declared with a comma and it looks a lot like a ordered pair
```cs
int [ , ] x = {{1, 2, 3}, {4, 5, 6}};
Console.WriteLine(x[0,0]);
```

This is how the array would look like for the developer (x[2, 1] == 6):

|     | 0   | 1   | 2   |
| --- | --- | --- | --- |
| 0   | 1   | 2   | 3   |
| 1   | 4   | 5   | 6   |
these can also be declared in the C way by just using two side by side square brackets.
```cs
int[1][2]
```

### Jagged Arrays
Arrays that are not square. 
```cs
int[][] array = {
	new int[2] = {12}
}
```
### Operations
GetLength() returns the size of he dimension that the argument says
	* this means that Get Length(0) on a 2D array would return the length of the first dimension 

# Protections
There are three:
* Public
	* This object can be used and is visible by all
* Protected
	* This object can be used by itself and the other instances of this class
* Private
	* This object cannot be used from outside this scope
	* get{} and set{} can be used to access private members when necessary

# The Different Levels of Scope
* There was another one here that I couldn't get
* Method
* Block
# Try, Catch, and Finally
Try blocks indicate where errors could be. Catch blocks are the code to execute if a certain error comes up, and finally blocks are the code that always executes no matter if there was an error or not.
# FileStreams
```c#
FileStream F = new FileStream("test.dat", FileMode.OpenOrCreate);
```
These work like the filestreams that you have in C/C++.
You may want to use try and catch to avoid errors in case the file that you try to open no longer exists.

For the below streams, there aren't just readers and writers, but there are also combinations. For instance, BinaryReaderWriter exists.
### StreamReader
Used specifically to read from a stream
Declarations of StreamReaders and Writers use the "using" keyword when being declared.
```cs
using (StreamWriter sr = new StreamReader("D:\\myTest1.txt"))
```
* The path may change or just not work based on what OS is being run. Mac users may want an "@" in front of the string literal (for some reason?)
StreamWriters have different modes that can create files or write to files
```cs
using (StreamWriter sr = File.OpenText(path))
```

> [!NOTE]
> Remember to close the stream once you are done.

### StreamWriter
Used specifically to write to a stream

### BinaryReader
For binary files specifically.
Binary files can have no extension, .dat extension, .exe, and many others.

# Parallel Programming
Asynchronous vs Parallel Programming
* Parallel programming is when there ARE multiple processes running at the same time
* Asynchronous programming doesn't have to have them running at the same time, there are just multiple processes
Asynchronous is prepping and cooking one item at a time. Parallel is prepping and cooking everything at the same time.

### Parallel Methods
```cs
Parallel.For(0, 10, (count) => Console.WriteLine(count));
// The above will print numbers from 0 to 9 in a race condition
	// Seemingly random
```
The code above runs the given function in a for loop like fashion.

```cs
Parallel.ForEach
```

```cs
Parallel.Invoke(
	// Functions go here
)
```
Parallel.Invoke does a bunch of different functions passed to it. It also is a race condition.