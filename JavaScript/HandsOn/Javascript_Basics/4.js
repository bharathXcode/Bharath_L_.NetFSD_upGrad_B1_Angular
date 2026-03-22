//Javascript Operators
//Arithmetic Operators(+,-,*,/,%,++ )
//Assignment Operators(=,+=,-=,*=,/=,%=)
//Comparison Operators(==,===,!=,!==,>,<,>=,<=)
//Logical Operators(&&,||,!)
//Bitwise Operators(&,|,^,~,<<,>>)
//String Operators(+)
//Conditional (Ternary) Operator(? :)
let a = 10;
let b = 20;
let c = a + b;
console.log(a + b);
console.log(a - b);
console.log(a * b);
console.log(a / b);
console.log(a % b);
let x = 10;
x += 5;
console.log(x);
a="5";
b=5;
console.log(a == b); //loose equality operator
console.log(a === b);//strict equality operator(checks value and type)
console.log(a != b);
let age = 20;
let hasLicense = true;
console.log(age > 18 && hasLicense);
console.log(age > 18 || hasLicense);
console.log(!hasLicense);
let status = age > 18 ? 'Adult' : 'Minor';
console.log(status);
console.log(typeof age); //typeof operator retruns the type of the variable 
let arr = [1, 2, 3];
console.log(typeof arr); //typeof operator returns object for arrays
console.log(arr instanceof Array); //instanceof operator checks if arr is an instance of Array  
//??nullish coalescing operator(??) returns the right-hand operand when the left-hand operand is null or undefined
let n = null;
let defaultName = 'Guest';
let finalName = n ?? defaultName;
console.log(finalName);