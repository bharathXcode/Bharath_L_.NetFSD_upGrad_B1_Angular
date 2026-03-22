let orderFood = new Promise(function (resolve) {
    setTimeout(function () {
        resolve("Order received");
    }, 2000)
})
orderFood.then(function (response) {
    console.log(response);
    return 'Food is being prepared';
}).then(function (response) {
    console.log(response);
    return 'Food Delivered';
}).then(function (response) {
    console.log(response);
})