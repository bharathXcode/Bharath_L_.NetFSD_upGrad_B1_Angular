//High Order Function
/*
A function that:
1.takes another function as a argument
2. or returns a function
*/
//ex1: accecpting function
function calculate(a, b, operation) {
    return operation(a, b);
}
function add(a, b) {
    return a + b;
}
console.log(calculate(10, 5, add));
//ex2: returning function
function multiple(factor) {
    return function (num) {
        return num * factor;
    }
}
const result = multiple(2);
console.log(result(5));