class Product {
    constructor({ name, price, category = "General" }) {
        this.name = name;
        this.price = price;
        this.category = category;
    }

    display = () => {
        console.log(`Product: ${this.name}, Price: ₹${this.price}, Category: ${this.category}`);
    }
}

let prod1 = new Product({ name: "Laptop", price: 50000 });
prod1.display();

let extraFeatures = ["Warranty", "Free Delivery"];
let allFeatures = [...extraFeatures];
console.log("Features:", allFeatures);