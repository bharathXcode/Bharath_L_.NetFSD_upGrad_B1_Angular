import { Cart } from "./models.js";
import { fetchProducts } from "./api.js";
import { saveCart, loadCart, checkLogin, logoutUser } from "./storage.js";

const user = checkLogin();
document.getElementById("userInfo").innerText = `Welcome, ${user}`;

window.logout = logoutUser;

const cart = new Cart();

// Load cart from localStorage
const savedItems = loadCart();
savedItems.forEach(item => cart.addProduct(item));

updateCartUI();

// Fetch products asynchronously
const loadProducts = async () => {
    const products = await fetchProducts();
    displayProducts(products);
};

loadProducts();
function displayProducts(products) {
    const container = document.getElementById("productList");
    container.innerHTML = "";

    products.forEach(product => {

        const col = document.createElement("div");
        col.className = "col-md-3 mb-4";

        col.innerHTML = `
            <div class="card h-100 shadow-sm">
                <img src="${product.image}" class="card-img-top p-3" style="height:200px; object-fit:contain;">
                <div class="card-body d-flex flex-column">
                    <h6 class="card-title">${product.title.substring(0, 40)}...</h6>
                    <p class="fw-bold text-success">₹${product.price}</p>
                    <button class="btn btn-primary mt-auto"
                        onclick="addToCart(${product.id}, '${product.title}', ${product.price}, '${product.image}')">
                        Add to Cart
                    </button>
                </div>
            </div>
        `;

        container.appendChild(col);
    });
}
function updateCartUI() {
    const cartList = document.getElementById("cartList");
    const cartCount = document.getElementById("cartCount");
    const totalAmount = document.getElementById("totalAmount");

    cartList.innerHTML = "";

    cart.items.forEach(item => {
        const li = document.createElement("li");
        li.className = "list-group-item d-flex justify-content-between align-items-center";

        li.innerHTML = `
            ${item.title.substring(0, 30)}...
            <div>
                ₹${item.price}
                <button class="btn btn-sm btn-danger ms-2"
                    onclick="removeItem(${item.id})">
                    Remove
                </button>
            </div>
        `;

        cartList.appendChild(li);
    });

    cartCount.innerText = cart.items.length;
    totalAmount.innerText = cart.getTotal();
}
window.addToCart = (id, title, price, image) => {
    cart.addProduct({ id, title, price, image });
    saveCart(cart);
    updateCartUI();
};

window.removeItem = (id) => {
    cart.removeProduct(id);
    saveCart(cart);
    updateCartUI();
};