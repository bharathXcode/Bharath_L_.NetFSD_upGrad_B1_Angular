function outer() {
    let counter = 0;
    return function inner() {
        counter++;
        console.log(counter);
    }
}
const count = outer();
count(); //1
count(); //2
//Clousers
//A clouser gives access to outer function variables even
// after outer function execution