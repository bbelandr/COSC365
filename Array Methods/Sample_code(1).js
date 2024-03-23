// Benjamin Belandres
// Mastering Array Methods and Asynchronous Javascript
///////////////////////////////////////   Sample Code 1

// Sample array containing student scores
const studentScores = [70, 85, 90, 65, 80];

// Function to calculate the total score of all students
function calculateTotalScore() {

    const totalScore = studentScores.reduce((accumulator, value) => accumulator + value);
    alert("Total score of all students: " + totalScore);
}

// Function to find the average score of all students
function calculateAverageScore() {
    let totalScore = studentScores.reduce((accumulator, value) => accumulator + value);
    const averageScore = totalScore / studentScores.length;
    alert("Average score of all students: " + averageScore);
}

// Function to find and alert the highest score
function findHighestScore() {
  let highestScore = studentScores.reduce((prevVal, curVal) => {
    if (curVal > prevVal) {
        return curVal;
    }
    else {
        return prevVal;
    }
  });

  alert("Highest score among students: " + highestScore);
}

// Function to find and alert the lowest score
function findLowestScore() {
    let lowestScore = studentScores.reduce((prevVal, curVal) => {
        if (curVal < prevVal) {
            return curVal;
        }
        else {
            return prevVal;
        }
      });
      alert("Lowest score among students: " + lowestScore);
}

// Call functions
calculateTotalScore();
calculateAverageScore();
findHighestScore();
findLowestScore();
// 390 78 90 65





///////////////////////////////////////   Sample Code 2

// Instructions:
// PART B: 

// Code to use: Use Sample code 2 from Sample_code.txt file

// Your task is to debug and enhance the code by incorporating the following JavaScript concepts and methods:

//     Array methods: .map(), .forEach(), .reduce()
//     Asynchronous JavaScript: setTimeout(), setInterval()
//     Understanding the 'this' keyword
//     Utilizing the alert function for user interaction

// Instructions:

//     Review the provided sample code carefully.
//     Identify areas where you can incorporate .map, .forEach, .reduce, alert, setTimeout(), setInterval(), and .this methods to improve the code.
//     Enhance the code to accurately calculate taxes based on the given inputs.
//     Make sure to handle any potential errors or edge cases that may arise during the tax calculation process.
//     Test your modified code to ensure it works correctly in various scenarios.
//     Provide comments in your code to explain the purpose of each section and any modifications made.

// Requirements:

//     Incorporate .map, .forEach, or .reduce method to calculate the total price of products.
//     Use .this method to access object properties within the Product constructor function.
//     Utilize setTimeout() or setInterval() to display tax information after a certain delay.
//     Ensure that tax calculation is accurate and handles edge cases appropriately.
//     Make your code modular and easy to understand by providing comments and clear variable/function names.

// Note: Feel free to add additional features or improvements to the code if you find it necessary.



// Sample code for tax calculation
// OUTPUT BEFORE CHANGES:
    // Total Price: $100.00
    // Tax: $10.00

// Object representing a product

function Product(name, price) {
  this.name = name;
  this.price = price;
}

// Array of     products
const products = [
  new Product('Shirt', 20),
  new Product('Pants', 30),
  new Product('Shoes', 50),
];

// Function to calculate total price of products with tax
function calculateTotal(products) {
  let totalPrice = products.reduce((accumulator, curVal) => accumulator + curVal.price, 0);
//   Replaced the below code with reduce
//   for (let i = 0; i < products.length; i++) {
//     const product = products[i];
//     totalPrice += product.price;
//   }
  
  return totalPrice;
}

// Function to calculate tax
function calculateTax(price, taxRate) {
  return price * taxRate;
}

// Function to display alert with tax information
function displayTaxInformation(totalPrice, tax) {
  // Added code that also shows the individual products that sum up to the total price.
  let productString = "";
  products.forEach((product) => {
    productString = productString.concat(product.name, " Price: $", product.price.toFixed(2), "\n");
    productString = productString.concat("    Tax: $", calculateTax(product.price, taxRate).toFixed(2), "\n");
  })
  alert(
`${productString}~~~~~~~~~~~~~~~~~~~
Total Price: $${totalPrice.toFixed(2)}\nTax: $${tax.toFixed(2)}`);
}

// Calculate total price
const totalPrice = calculateTotal(products);

// Tax rate
const taxRate = 0.1;

// Calculate tax
const tax = calculateTax(totalPrice, taxRate);

// Initial display
displayTaxInformation(totalPrice, tax);
setInterval(displayTaxInformation, 3000, totalPrice, tax);  // Display tax information every 3 seconds, allowing the price and the tax to change and the update be reflected

// Adding a new product after the initial alert just to prove it is possible
products.push(new Product("Chicken", 5));


//////////////////////////////////////////////////



