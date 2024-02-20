let value = prompt("Enter a value: ")

// Determine if the value is even or odd
if (value % 2 === 0) {
    console.log(value, " is even.")
}
else {
    console.log(value, " is odd.")
}

// Determine if the value is prime, converts a negative value to positive first.
let valueCopy = value
if (valueCopy < 0) {
    valueCopy = valueCopy * -1
}

isPrime = true
for (let i = Math.floor(valueCopy / 2); i > 1; i--) {
    if (valueCopy % i === 0) {
        isPrime = false
        break
    }
}
if (isPrime) {
    console.log(value, " is prime")
}
else {
    console.log(value, " is not prime")
}

