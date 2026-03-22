let numbers = [12, 3, 45, 56, 78];
numbers.push(96); //item added at last
console.log(numbers);
numbers.unshift(10); //item added at begining
console.log(numbers);
numbers.pop(); //last item removed
console.log(numbers);
numbers.shift(); //item remove from begining
console.log(numbers);
// splice(add/remove items)
let ar = [23, 45, 67, 78, 89, 90, 12]
console.log(ar);
ar.splice(0, 2); //remove 2 items from 0th index
console.log(ar); //removed items are returned
let ar1 = [1, 4];
ar1.splice(1, 0, 2, 3); //added 2,3 
console.log(ar1);

// //slice(return in between items)
let ar2 = [23, 45, 67, 78, 89, 90, 12]
let ar3 = ar2.slice(1, 4);
console.log(ar2); //original array remains unchanged
console.log(ar3);

//concat
let arr1 = [23, 45, 67, 78, 89, 90, 12]
let arr2 = arr1.concat(100, 300)
let arr3 = arr1.concat(arr2); //concatenating arr1 with arr2
console.log(arr2);

