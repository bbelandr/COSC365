# What is HTML
HTML is a language that can be used to piece together code.


# An Example with Parsing
## Addition
```html
<html>
	<body>
		<h1>how to program a parser </h1>   
		Expression<input id='expression'>   
		Result<input id='result'>           
		<button onclick="parse()">PARSE</button>
	</body>
	<script>
		const parsePlusSeparatedExpression = (expression) => {
			return 0;
		};
		const parse = () => {
			const expressionNode = document.getElementById("expression")
			const resultNode = document.getElementById("result")
			const expression = expressionNode.value
			const result = parsePlusSeparatedExpression(expression)
			resultNode.value = String(result)
		}

	</script>
</html>
```

## Multiplication
```html
<html>
	<body>
		<h1>how to program a parser </h1>   
		Expression<input id='expression'>   
		Result<input id='result'>           
		<button onclick="parse()">PARSE</button>
	</body>
	<script>
		// This would only take strings containing * operator and not +
		const parseMultiplicationSeparatedExpression = (expression) => {
			const numbersString = expression.split("*")
			const numbers = numbersString.map(noStr => +noStr)
			const initialValue = 1
			const result = numbers.reduce((acc, no) => acc * no, initialValue)
			return result;
		};
		
		const parsePlusSeparatedExpression = (expression) => {
			const numbersString = expression.split("+")
			const numbers = numbersString.map(noStr => parseMultiplicationSeparatedExpression(noStr))
			const result = numbers.reduce((acc, no) => acc + no, 0)
			return result;
		};
		const parse = () => {
			const expressionNode = document.getElementById("expression")
			const resultNode = document.getElementById("result")
			const expression = expressionNode.value
			const result = parsePlusSeparatedExpression(expression)
			resultNode.value = String(result)
		}

	</script>
</html>
```

