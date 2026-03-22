//Simulating API Call
function fetchData(callback) {
    console.log("Fetching data...");

    setTimeout(function () {
        callback("Data received");
    }, 2000);
}

fetchData(function (data) {
    console.log(data);
});