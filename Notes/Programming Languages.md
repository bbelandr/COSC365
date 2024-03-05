# Translators
These take code and turn it into something the machine can execute.
There are a few kinds of translators:

| Translator | What it is used for |
| ---- | ---- |
| Compiler | Converts code into assembly and then into machine code. It translates the entire file before it is executed |
| Interpreter | Converts code into machine code line by line as the code runs |
| Assembler | Takes assembly code and converts it to machine code |
# Domain Specific Languages
DSLs are languages specific to a domain like HTML. 

| The language | What it stands for | What it  does |
| ---- | ---- | ---- |
| SQL | Structured Query Language | used for databases |
| GLSL/HLSL | GPU Shader Languages | used for writing programs embedded in the GPU pipeline |
| VHDL | Very High-Level Descriptor Language | used for describing logic and circuits in a textual way |
| UML | Unified Modeling Language | used to convey visually the design of a system |

# Language Styles
#### Imperative
#### Object Oriented
#### Functional
#### Logical

# Lexical Analysis
This can also be known as **Tokenization**
Begins by transforming text into meaningful groups. This would groups stuff like **comments, keywords, separators/punctuation, operators, literals, and identifiers**.

A Lexical analyzer runs the source code through a group of rules called **grammar** to determine which category the text enters. Most of the time this is based on symbols, names, or order.
### Parsing
The first step of Lexical Analysis. This is the process of taking code and breaking it down into pieces:
```js
let x = 15

// Is parsed into:
let
x
=
15
```

Parsing will create a **parse tree**, which is the exact same as the things produced by CFG's in CS312.

A parsing example can be found in [[HTML]]. 

##### AST
Creating an AST is the second step of lexical analysis. This takes parsed input and determines what the individual tokens are. 

**Here's a simple example of an AST:**
```
2 + (1 * 4)

	+
   / \
  2   *
     / \
    1   4
```
Notice how the AST doesn't show every single token, and instead manages to remove the parenthesis through tree levels. 
A parse tree would show all of the tokens just like something generated from a CFG. It would also have to use a ruleset that CFGs commonly use.

**Here's a more advanced example of an AST with real code:**
```js
function foo(d) {
  d += 3;
    return d+999
}
function bar(d) {
    return d*100
}
```

It would take this above code and then turn it into this tree at the bottom:

![[A9SZd.png]]

This has a unique similarity to CFG's (think back to COSC312). The above is a good representation of what it should look like. It doesn't show every single token, and instead just stays to the essential parts of the code. 

# Type Systems
### Strong vs Weak
A strong language forces you to put the correct type in, and a weak language would convert the values for you.
##### For example:
```c
int i = 77.3;   // C would round down for you

int i = 77.3;   // Java would throw an error
```
C is a weak language, while Java is strong.

# Static vs Dynamic
A static type checks all types and conversions at compile time. All typing related choices are already known. 
This means that you must declare the type like "int" before the name of the variable. Python is dynamically typed, which means you don't need to have any type beforehand.
```c
int i = 0;   // This is statically done
```

```js
var i = 0;   // This is dynamically done
```
