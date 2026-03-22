//reduce the array elements with single value
/* array.reduce(accumulator,currentvalue,index,array)=>{
    return updatedaccumlator
},initialvalue)*/
let arr = [1, 2, 3, 4, 5];
let result = arr.reduce((sum, current) => sum + current, 0)
console.log(result);
let n = [2, 3, 4]
let p = n.reduce((acc, cur) => {
    return acc * cur
}, 1)
//calculating total cart value
let cart = [
    { product: 'laptop', price: 50000, qty: 1 },
    { product: 'mouse', price: 500, qty: 2 }
]
let total = cart.reduce((acc, item) => acc + item.price * item.qty, 0);
console.log(total);
let numbers = [1, 2, 3, 4, 1];
//removing duplicates
let unique = numbers.reduce((acc, cur) => {
    if (!acc.includes(cur)) {
        acc.push(cur)
    }
    return acc;
}, []);
console.log(unique);