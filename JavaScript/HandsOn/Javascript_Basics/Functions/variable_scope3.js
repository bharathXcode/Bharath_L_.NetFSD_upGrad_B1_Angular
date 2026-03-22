function fun() {
    if (true) {
        let i = 100;
        var j=50;
    }
    console.log(i);// This will throw an error because i is not defined in this scope
    console.log(j);
}
fun();
console.log(i); //error
console.log(j); //error