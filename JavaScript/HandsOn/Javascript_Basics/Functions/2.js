//functions with return values
// Functions can return values using the `return` statement
function Square(n) {
    let result = n * n;
    return result;
}
let r = Square(12);
console.log(r);
function Greet(name) {
    let message = 'Hello ' + name;
    return message;
}
function isEven(number) {
    let isEven = number % 2 == 0 ? true : false;
    return isEven;
}
let result = Square(10);// calling function with return value
console.log(result);
result = Greet('Dhoni');
console.log(result);
result = isEven(12);
console.log(result ? 'Even' : 'Odd')
console.log(isEven(110) ? 'Even' : 'Odd');
