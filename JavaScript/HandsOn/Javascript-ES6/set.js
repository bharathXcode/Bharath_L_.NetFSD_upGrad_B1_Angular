//Javascript Set Objects
//A set is a collection of unique values.
//A set can hold value of any type
const ids = new Set([1, 2, 2, 3]);
console.log(ids); // Set {1, 2, 3}
//Create set
const letters = new Set();
//add values to the Set
letters.add('a');
letters.add('b');
letters.add('c');
letters.add('a');
console.log('Length: ' + letters.size);
let isExist = letters.has('a');
console.log(isExist);
//letters.clear(); //clare all objects
const numbers = new Set([1, 3, 4, 6, 7]);
numbers.add(12)
numbers.add(34)
numbers.add(3);
console.log(numbers.size);
//return all the values from Set
numbers.delete(1); //remove item from Set
for (let k of numbers) {
    console.log(k);
}

