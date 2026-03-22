export const saveCart = (cart) => {
    localStorage.setItem("cart", JSON.stringify(cart.items));
};

export const loadCart = () => {
    const data = localStorage.getItem("cart");
    return data ? JSON.parse(data) : [];
};

export const checkLogin = () => {
    const user = sessionStorage.getItem("user");
    if (!user) {
        window.location.href = "login.html";
    }
    return user;
};

export const logoutUser = () => {
    sessionStorage.removeItem("user");
    window.location.href = "login.html";
};