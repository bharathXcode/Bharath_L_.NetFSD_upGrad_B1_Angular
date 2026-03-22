// app.js
const readline = require('readline');
const ProductManager = require('./productManager');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

const manager = new ProductManager();

const menu = `
🛍️ Product Manager Menu:
1. Create Product
2. View Products
3. Update Product
4. Delete Product
5. Search Product
6. Sort Products
7. Exit
`;

const prompt = () => {
    console.log(menu);
    rl.question('Choose an option: ', choice => {
        switch (choice.trim()) {
            case '1':
                rl.question('Enter id, name, price, quantity (comma-separated): ', input => {
                    const [id, name, price, quantity] = input.split(',').map(i => i.trim());
                    manager.createProduct(id, name, parseFloat(price), parseInt(quantity));
                    prompt();
                });
                break;
            case '2':
                manager.readProducts();
                prompt();
                break;
            case '3':
                rl.question('Enter product ID to update: ', id => {
                    rl.question('Enter new name, price, quantity (comma-separated): ', input => {
                        const [name, price, quantity] = input.split(',').map(i => i.trim());
                        manager.updateProduct(id, {
                            name,
                            price: parseFloat(price),
                            quantity: parseInt(quantity)
                        });
                        prompt();
                    });
                });
                break;
            case '4':
                rl.question('Enter product ID to delete: ', id => {
                    manager.deleteProduct(id.trim());
                    prompt();
                });
                break;
            case '5':
                rl.question('Enter product name or ID to search: ', term => {
                    manager.searchProduct(term.trim());
                    prompt();
                });
                break;
            case '6':
                rl.question('Sort by "price" or "quantity": ', by => {
                    manager.sortProducts(by.trim());
                    prompt();
                });
                break;
            case '7':
                console.log('👋 Exiting Product Manager. Goodbye!');
                rl.close();
                break;
            default:
                console.log('❗ Invalid option. Try again.');
                prompt();
        }
    });
};

prompt();
