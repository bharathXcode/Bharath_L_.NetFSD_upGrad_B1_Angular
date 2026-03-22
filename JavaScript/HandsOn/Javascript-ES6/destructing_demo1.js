//destructing with arrays
let numbers = [12, 23, 34, 45];
let [a, b, c] = numbers;
console.log(`a=${a} b=${b} c=${c}`);
//destructing with objects
let item = {
    id: 133,
    name: 'laptop',
    price: 56000,
    stock: 2
};
let { id, price, name } = item;
console.log(`Id:${id} price:${price} name:${name}`)