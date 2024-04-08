#language
# What is Javascript
Very popular with web development.
Mostly used on the front end
* Javascript is a High-Level, Object-jOriented, Multi-Paradigm Programming Language
	* High level because we don't have to worry about memory management
	* Multi-paradigm because you can use different styles of programming
	* Programming Language because it can instruct computers to do things
* Think of [[COSC365/Notes/HTML]], [[CSS]], and Javascript like this
	* HTML is like the nouns
	* JS is like the verbs
	* CSS is like the adjectives
# Functions
Here is a list of [[Javascript]]
# Syntax
## Semicolons are optional

```js
console.log("Welcome back")
let js = 'amazing'
if (js == 'amazing') alert('JavaScript is fun!')
js = 'boring'
if (js == 'amazing') alert('JavaScript is fun!')
```

> [!NOTE] Using Obsidian and JS
> Alerts won't work within Obsidian, but they will work if you paste it onto a console from the inspect element tool in an internet browser



```run-js
age = 24;
price = 99.99
console.log(age);
```
Notice how semicolons are optional

## Comments
Comments are C-style
```js
// This is a comment
/* This is a comment */
```

## Increment
There is also pre and post increment
```js
a++   // Post increment (done after the line of code is executed)
++a   // Pre increment (done before the line of code is executed)
```

## Operators
The normal ones are there, but there also are a few extras
```js
let age = 3
if (age % 2 === 0) {
	console.log("Even")
}
else {
	console.log("Odd")
}
```

### How to do Integer Division
You must use the Math.floor() function
```js
let answer = Math.floor(10 / 3)
console.log(answer)
```
### Comparison Operators
Non-zero values are considered true, and zero is false.
#### ==
Any data is automatically converted to a version that makes sense. For example, if you were to compare "5" and 5, the == operator would return true.

#### ===
This means strict equality, which does not convert between different types. This means that if you were to compare "5" and 5, the === operator would return false.

## If statements
These work just like C as well
```js
let age = 10
if (age > 18) {
	console.log("You can vote")
}
else {
	console.log("You CANNOT vote")
}
```
There also is else if

### Same line if statements
```js
let mode = "dark"
if (mode === "dark") console.log(mode)
```

### Ternary Operators
```js
age = 10
age > 18 ? "adult" : "not adult";
```

## For loops
break and continue also exist like from C
For loops work almost exactly like C, but the syntax is slightly different
	Uses let instead of a data type

```js
const numbers = [1, 2, 3, 4, 5]

for (let i = 0; i < numbers.length; i++) {
	console.log(i)
}
```

### For of loop
There is another way as well that more closely resembles python. 

> [!NOTE] Clarification
> In the example below, i is a COPY of an element in numbers. Modifying i does not change the corresponding element in numbers.

```js
const numbers = [4, 2, 9, 4, 5]

for (let i of numbers) {   // i will hold the information from within the array
	console.log(i)
}
```

___
Examples:
```js
const grades = [85, 97, 44, 37, 76, 60]
let rollingSum = 0
for (grade of grades) {
	rollingSum += grade
}
let average = rollingSum / grades.length
console.log("The average is ", average)
```

```js
const prices = [250, 645, 300, 900, 50]
let i = 0
for (price of prices) {
	price = price * 0.9
	prices[i++] = price
}
console.log(prices)
```

```js
const prices = [250, 645, 300, 900, 50]
let i = 0
while (i < prices.length) {
	prices[i] = prices[i] * 0.9
	i++
}
console.log(prices)
```

___

## While Loops
These exist like they do in C as well

## Input and Output

The main ways are through [[prompt()]] and [[console.log()]]
```js
let num = prompt("Enter a number:")
if (num % 5 === 0) {
	console.log(num, " is a multiple of 5")
}
else {
	console.log(num, " is not a multiple of 5")
}
```

There is another way to output variables from within a string using specifiers (This example doesn't work)
```js
let avg = 10
console.log('avg marks of the class = ${avg}')   
```

> [!NOTE] Prompt and Obsidian
> Prompt, like alert, will not work with Obsidian, but it will work through the browser

## Variable Naming
### Case Sensitive
Variable names will not work if you have a variable named "a" and you try to access it by typing "A"
### Allowed characters
Only letters, digits, underscores, and '$' are allowed

### Allowed names
There are some names in JS that are simply not allowed to be used
* class cannot be used as a variable name
## Var, let, and const
You don't need any of these if you are going to use a boolean
Technically, you don't need these keywords at all, but they won't be considered variables
### Var
Means the variable can be redeclared and updated. It has a global scope.

> [!NOTE] Outdated
> In modern JS, we typically won't use the var keyword

```run-js
var a = 5
console.log(a)
```

```run-js
var a = 5
a = 10   // This will change the value of a since it was declared as a var
console.log(a)
```
### let
Variable cannot be re-declared but can be updated. It has a block scope. 
```js
let age = 5
let age = 10   // This will not be allowed because you cannot redeclare a let variable
console.log(age)
```

```run-js
let age = 5
age = 10
age = "abc"
console.log(age)
```
The above works because you didn't redeclare it, you just updated it.

Scope still plays a role with this too
```run-js
{
	let a = 5
}
let a = 10
console.log(a)
```
### const
variable cannot be re-declared or updated. It has a block scope like let.
```js
const age = 5 
age = 10   // This will cause an error
console.log(age)
```
# JS is Dynamic
That means you don't have to declare the type of a variable, it is done automatically for you
```js
variable = 10
// Notice that above didn't require the int 
```

```run-js
let age = 5
age = 10
age = "abc"
console.log(age)
```
Notice how the above works as well
# JS Data Types
## BigInt
```js
let x = BigInt(123)
```
## Symbol
```js
let x = Symbol("Hello$")
```

## Objects
Storing multiple types of data in the same space are done with key value pairs, like a dictionary or a map. Notice how the inside of the brackets is un-indented (I have been told that this is common practice {I was told wrong})
```run-js
const student={
	fullName : "Jack",
	age : 20,
	gpa : 3.9,
	isPass : true,
}

student["gpa"] = 4.0   // This can be changed despite the fact that the dictionary is const

console.log(student)
console.log(student["fullName"])
console.log(student["gpa"])
console.log(student.age)
```
All key value pairs must be separated by commas from within the dictionary

You can also access elements using the dot operator.

**Nested Objects** also exist:
```js
const student = {
	fullname : "mark",
	age: 30,
	grades: {
		science : 90,
		math : 70
	}
}

console.log(student.grades.science)
```

### Accessing elements from the object
It is possible to access elements from other objects within a different object
```js
let obj1 = {
	money: 50
}

let obj2 = {
	money: 10,
	getMoney: function() {   // You cannot use an arrow function here
		console.log(this.money)
	},
	getMoney2: function() {
		console.log(obj1.money)
	}
}

obj2.getMoney()
obj2.getMoney2()
```

##### You cannot use Arrow functions to do this
If you want to access elements from within the object, the arrow function will not work. This is because 'this' refers to the global object called the 'window' or 'global,' since arrow functions do not. A normal function declaration would have 'this' refer to the parent object.
* This scenario occurs because arrow functions do not bind their own 'this' but instead draw from the enclosing lexical context.
### Object Methods
Here is an example of a method using the function keyword:
```js
const person = {
	firstName : "Mark",
	lastName : "Rober",
	getFullName: function() {
		return `${this.firstName} ${this.lastName}`
	},
	getFirstName: function() {
		return this.firstName
	}
}

console.log(person.getFirstName())
console.log(person.getFullName())
```
#### Constructors
Constructors can have elements added through the this keyword. You can then use the new keyword to call the constructor.
```js

```

Using **Prototypes**:
Prototypes allow you to add elements to an object after they have been made. Prototypes will NOT overwrite an already existing element from within the object. Here's an example:
```js
function Person() {
	this.name = 'John'
}
Person.prototype.age = 20
Person.prototype.name = 'ass'
const person1 = new Person()
console.log(person1.age)
```

```js
const name = new String("kyle")
console.log(name)
```
There are default constructors for some types as well
* String()
* Boolean()
* Some others
#### Another Example
```js
const product = {
	name: 'Ball Pen',
	rating: 4.6,
	inStock: true,
	price: 29.99
}
```

### Const and Dictionaries
Note how the keys within the dictionary, despite being const, can be changed. There is a function that can protect the objects from within the dictionary, but calling the dictionary const will still allow you to change its keys.

### Arrays
Linear collections of items that can store multiple values.
```js
const numbers = [0, 3.14, 9.81]
```
They can be indexed with [ ]. You cannot index an array with a negative value in order to start from the end of the array (like how python works).

[[Arrays]] in JS are mutable.

Strings are also considered an array of characters, but they are immutable.

#### Pushfront and Pushback
Here's an example that will
* Remove the first company from the array
* Remove Uber and add Lyft in its place
* Add Amazon to the end
It looks like this:
```js
let companies = ["Bloomberg", "Microsoft", "Uber", "Google", "IBM", "Netflix"]
companies.shift()
companies.push("Amazon")
console.log(companies)

```
##### push()
Adds an element to the end of the array

##### pop()
Removes the end element 
##### unshift()
Adds an element to the beginning of the array
##### shift()
Removes the first element of the array

#### Manipulating Arrays
Empty arrays
```js
const arr = Array()   // Constructor for an empty array
```

##### forEach()
```js
function addFive(val) {
	return val + 5
}
let sum3 = 0
const numbers3 = [1, 2, 3, 4, 5]
numbers3.forEach(addFive)
console.log(numbers3)=
```
##### filter()
You can find strings from an array that only end with a or something similar

##### reduce()
Takes a callback function. The callback function takes an accumulator, current, and optional initial value as a parameter and returns a single value. It is a good practice to define an initial value for the accumulator value. If we do not specify this parameter, by default accumulator will get array first value. If our array is an empty array, then Javascript will throw an error.

```js
const numbers = [1, 2, 3, 4, 5]

```

```js
// Take a number n as input from user. Create an array of number from 1 to n.
// use the reduce method to calculate sum of all numbers in the array
// use the reduce method to calculate product of all numbers in the array
// let n = prompt("Enter a number: ")
let n = 5
let arr = []
for (let i = 1; i <= n; i++) {
	arr[i - 1] = i
}
console.log(arr)
```
##### every()

##### find()
##### some()
Acts like any() in python
##### sort()
You probably want to define your own comparison function like you would when using a sorting algorithm in C.
##### fill()
```js
const arr = Array()
arr.fill("8")
```
##### Length
length is a member variable that holds the amount of elements within the array.
```js
const numbers = [0, 3.14, 9.81]
console.log(numbers.length)
```

##### concat()
* Takes two arrays and puts them together

##### indexOf(object)
* Returns the index of an element if it exists within the array
* It would return the index of only the first element that it finds.
##### lastIndexOf(object)
* Returns the final index of a searched for element. If it doesn't exist, it returns -1
##### includes(object)
* Returns true if the element is within the array
##### isArray()
* Returns true or false if the object is an array or not
```js
const numbers = [1, 2, 3, 4, 5]
console.log(Array.isArray(numbers))
```

###### toString()
Converts an array to a string. The converted string will have commas within them.
```js
let numbers = [1, 2, 3, 4, 5]
console.log(numbers.toString())
```

##### join()
Turns an array to a string like toString(), but you can specify the separation character like the comma.

##### slice()
Returns multiple items in a range. It takes the start position and end position. The end position is non-inclusive.
Just look this up, his explanations are bad
```js
const numbers = [1, 2, 3, 4, 5]

console.log(numbers.slice(1, 3))
const obj1 = {first: 20, second: 30, first: 50}
console.log(NaN === NaN)
```

##### splice()
Takes three parameters:
* Ending index
* number of times to be removed
* number of items to be added
```js
const numbers = [1, 2, 3 4, 5]
numbers.splice(4)
```
##### Split()
Is able to take a string and break it into an array of individual characters.

## Sets
Only allow for one of each type of element from within the set. Sets are immutable. 

See below how to declare them
```js
const set = new Set([1, 2, 3, 3])
set.forEach(function add(num) {
	console.log(num + 1)
})
```

## Strings
Making a string on the fly:
```js
let x = 10
let y = 50
console.log(`${x} ass ${y}`)
```
Surround the string with backticks and use $ along with { } to build a string

String Checking:
```js
let myString = "**";
if ('**' == myString[0] + myString[1]) {
	console.log("Pizza!");
}
```
## Actual Maps in JS
These are real key value pairs. There are also weakMaps
```js
let map4 = new Map()
map4.set('info', {name: 'Jack', age: "26"})  // The key value pair is between info and the elements defined in the {} <- called an object

console.log(map4.get('info'))
```

Looping through maps
You can use for loops, but you can also just use forEach()
```js
map8.forEach(function(value, key) {
	
})
```

Maps vs Objects:

| Maps | Objects |
| --- | --- |
| Maps can contain |  |

## WeakMaps
Similar to maps, but WeakMaps can only contain objects as keys.
forEach() will not work with weakMaps.

___

# Higher Order Functions
A callback is a function which can be passed as a parameter to another function.
Think of defining a function from within a function

```js
const numbers = [1, 2, 3, 4, 5]
const sumArray = arr => {
	let sum = 0
	const callback = function(element) {
		sum += element
	}
	arr.forEach(callback)
	return sum
}
console.log(sumArray(numbers))
```

___
# Declaring your own functions
Declaring functions looks like this:
```js
function printFullName() {
	console.log("Full Name")
}
printFullName()
```
Functions work more like python than C.

You can also declare a function like this:
```js
const a = function(n) {
	return n/2
}
console.log(a(10))
```
___
```js
function solveQuadratic(a, b, c) {   // Follows the form ax^2 + by + c = 0
	let answer = 0
	answer  = answer - c
	
}
```

```js
function countVowels(str) {
	let count = 0
	for (const char of str) {
		if (char === 'a' || 
			char === 'e' || 
			char === 'i' || 
			char === 'o' || 
			char === 'u') {
			
			count++
		}
	}
	return count
}

console.log(countVowels("chicken is delicious"))
```
___
## Arrow Functions
These are made when you **assign a function to a variable.** 
ARROW FUNCTIONS CANNOT BE CONSTRUCTORS.

In the below example, the NAME of the function is x, and the parameters are arg1 and arg2. It will return a stray value that it is left with. 
```js
let x = (arg1, arg2) => arg1 * arg2
console.log(x(1,2))
```

You can make a multiline arrow function as you can see below.
```js
let marks = [97, 64, 32, 49, 99, 96, 88]
let toppers = marks.filter((val) => {
	return val > 90
})

console.log(toppers)
```

If you only have one argument, you don't need to have the parenthesis.
```js
let makePizza = numPizzas => {
	for (let i = 0; i < numPizzas; i++) {
		console.log("Pizza number", i, "is made.")
	}
}
makePizza(5)
```
### Spread Syntax
These can have an unlimited size of parameters. This is like the functions with ... in C
```js
const sumAllNums2 = (...args) => {   // You don't HAVE TO use ..., you can use (a, b) like a normal parameter list
	 let sum = 0
	 for (const element of args) {
		 sum += element
	 }
	 return sum
}
console.log(sumAllNums2(1, 2, 5))
```

___
### Recursion
```js
// Finding the factorial of a number
let factorial = (num) => {
	let total = 1
	for (let i = 1; i <= num; i++) {
		total = total * i
		console.log(total)
	}
	return total
}
console.log(factorial(4))

// Function determining if the sum of two numbers is prime
let isSumPrime = (a, b) => {
	let sum = a + b
	for (let i = 2; i < sum / 2; i++) {
		if (sum % i === 0) {
			return false
		}
	}
	return true
}
console.log(isSumPrime())
```

## Default Parameters
```js
function ass(cheeks = 10) {
	return cheeks
}
console.log(ass())
```
These can be combined with arrow functions

## this Keyword
A pointer to the current object which can be dereferenced
```js
function Person() {
	this.name = 'Jack',
	this.age = 25,
	this.sayName = function () {
		console.log(this.age)
		let innerFunc = () => {
			console.log(this.age)
		}
		innerFunc()
	}
	
}
const x1 = new Person()
x1.sayName()
```

In the above example, the function keyword is being used to define a constructor. Notice how the first member variables are separated by commas

## then Function
Allows you to daisy chain functions together

## forEach Function
Used to iterate through an array.
Takes a function as a parameter.
```js
let students = [1, 2, 3]
students.forEach(myFunction)

function myFunction (student) {
	console.log(student)
}
```

The function for the forEach() function can also be defined within forEach's parameters
```js
let chickenNames = ['joe', 'kyle', 'david']
chickenNames.forEach(function makeFunny(name) {
	console.log(name, 'is a silly goose')
})
```
# Functional Programming

# Timing
# Error Control
There are three kinds of keywords:
* **Try**
	* Run some code that could cause an error
* **Catch**
	* Handle the error
* **Finally**
	* Run code after both try and catch are done
Try and catch work like C. Finally gets executed no matter what happens whether the code within the try section worked or not
```js
try {
	fakeFunction()
}
catch (error) {   // Both error and e work
	console.log("bad boy")
}
finally {
	console.log("this is the finally statement")
}
```

There also is **throw**
* Throw allows you to create your own exceptions/errors.
	* When you throw something like a value, catch can take it and use it to execute something. See below:
```js
try {  
  let age = 15;  
  if (age >= 18) {  
    console.log("Access granted - you are old enough.") 
  } else {  
    throw (age);  
  }  
}  
catch (myNum) {  
  console.log("Access denied - You must be at least 18 years old.");  
  console.log("Age is: ", myNum);  
}
```

# Other functions:
[[typeof]]
[[console.log()]]