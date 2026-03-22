//function expression
//A function stored in a varaible
const add = function (a, b) {
    return a + b;
}
console.log(add(2, 3));
//Anonymous function
//function without a name
//function get execute after 2 min
setTimeout(function () {
    console.log('Executed after 2 minuts')
}, 2000);

