//callback function
// A function passed as an argument to another function
function processUser(name, callback) {
    console.log("Processing User:" + name);
    callback();
}
function complete() {
    console.log('Process Completed');
}
//processUser is the callbackfunction
processUser("Virat", complete);
//callback with Parameters
function calculate(a, b, operation) {
    const result = operation(a, b);
    console.log('Result: ' + result);
}
function add(a, b) {
    return a + b;
}
calculate(10, 5, add);
//anonymous callback
//anonymous function as parameter
calculate(2, 4, function (a, b) {
    return a * b;
});
//arrow function as a parameter
calculate(23, 3, (a, b) => a - b);
processUser('Rohith', function () {
    console.log('Complted');
})