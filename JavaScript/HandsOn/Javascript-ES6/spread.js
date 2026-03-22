//Spread: expands arrays/objects
const nums = [1, 2, 3];
const moreNums = [...nums, 4, 5]; // Spread
let arr1 = [12, 23, 45];
let arr2 = [34, 45];
let arr3 = [...arr1, ...arr2]
for (let k of arr3)
    console.log(k);

