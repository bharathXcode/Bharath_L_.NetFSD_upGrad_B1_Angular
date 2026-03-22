let cart = [
    { id: 1, name: "Laptop", price: 50000, qty: 1 },
    { id: 2, name: "Mouse", price: 500, qty: 2 },
    { id: 3, name: "Keyboard", price: 1500, qty: 1 }
];
// 1 Total price
let total = cart.reduce((sum, item) =>
    sum + (item.price * item.qty), 0);

// 2 Increase quantity
cart = cart.map(item =>
    item.id === 2 ? { ...item, qty: item.qty + 1 } : item
);

// 3 Remove item
cart = cart.filter(item => item.id !== 3);

// 4 Find product
let product = cart.find(item => item.id === 1);

// 5 Conditions
let expensive = cart.some(item => item.price > 40000);
let allAvailable = cart.every(item => item.qty > 0);

console.log(cart);
console.log("Total:", total);
// 🧩 Requirements

// Calculate total cart value.

// Increase quantity of Mouse by 1.

// Remove product by ID.

// Find product by ID.

// Check:

// Is any product above ₹40,000?

// Are all products in stock (qty > 0)?