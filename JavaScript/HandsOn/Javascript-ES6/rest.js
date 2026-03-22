//Rest: collects remaining elements
function add(a) //sum of array elements
{
    let result = 0;
    for (let k of a) {
        result += k;
    }
    return result;
}
add([1, 2, 3, 4]);//10
function sum(...args) {
    return args.reduce((a, b) => a + b, 0); // Rest
}
console.log(sum(1, 2, 3, 4)); // 10
console.log(sum(5, 10, 15)); // 30
function Greet(greeting, ...names) {
}
Greet("Hello", "Alice", "Bob", "Charlie");