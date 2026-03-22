// productManager.js
const Product = require('./product');

class ProductManager {
    constructor() {
        this.products = [];
    }

    createProduct(id, name, price, quantity) {
        const product = new Product(id, name, price, quantity);
        this.products.push(product);
        console.log(`✅ Product "${name}" added.`);
    }

    readProducts() {
        console.log('\n📋 Product List:');
        this.products.forEach(({ id, name, price, quantity }) => {
            console.log(`ID: ${id}, Name: ${name}, Price: ₹${price}, Quantity: ${quantity}`);
        });
    }

    updateProduct(id, newData) {
        const product = this.products.find(p => p.id === id);
        if (product) {
            Object.assign(product, newData);
            console.log(`✏️ Product ID ${id} updated.`);
        } else {
            console.log(`❌ Product ID ${id} not found.`);
        }
    }

    deleteProduct(id) {
        const index = this.products.findIndex(p => p.id === id);
        if (index !== -1) {
            const removed = this.products.splice(index, 1);
            console.log(`🗑️ Product "${removed[0].name}" deleted.`);
        } else {
            console.log(`❌ Product ID ${id} not found.`);
        }
    }

    searchProduct(term) {
        const results = this.products.filter(p =>
            p.name.toLowerCase().includes(term.toLowerCase()) || p.id === term
        );
        console.log(`🔍 Search Results for "${term}":`);
        results.forEach(({ id, name, price, quantity }) =>
            console.log(`ID: ${id}, Name: ${name}, Price: ₹${price}, Quantity: ${quantity}`)
        );
    }

    sortProducts(by = 'price') {
        const sorted = [...this.products].sort((a, b) => a[by] - b[by]);
        console.log(`📊 Products sorted by ${by}:`);
        sorted.forEach(({ id, name, price, quantity }) =>
            console.log(`ID: ${id}, Name: ${name}, Price: ₹${price}, Quantity: ${quantity}`)
        );
    }
}

module.exports = ProductManager;
