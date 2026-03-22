// ES6 Class

export class Product {
    constructor(id, title, price, image) {
        this.id = id;
        this.title = title;
        this.price = price;
        this.image = image;
    }
}

export class Cart {
    constructor() {
        this.items = [];
    }

    addProduct(product) {
        this.items.push(product);
    }

    removeProduct(id) {
        this.items = this.items.filter(p => p.id !== id);
    }

    getTotal() {
        return this.items.reduce((sum, p) => sum + p.price, 0);
    }
}