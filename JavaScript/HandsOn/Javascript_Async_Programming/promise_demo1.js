function fetchUser() {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve({ id: 1, name: "John" });
        }, 2000);
    });
}

fetchUser()
    .then(user => {
        console.log(user);
    });