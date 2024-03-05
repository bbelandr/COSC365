A lot of things are similar. Here are some differences:

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
