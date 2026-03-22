//map
//it calls the function for each
// element in the array and returns 
// the array of results.
//Transform each element
let n = [2, 3, 5];
let r = n.map(i => i * i);
console.log(r);
let flowers = ["Rose", "Lilly", 
    "Tulips"];
let result = flowers.map(item => 
    item.length);
console.log(result);
result = flowers.map(item => 
    item.toUpperCase());
console.log(result);
result = flowers.map(item => 
    item.length > 5);
console.log(result);