// ================= LOCAL STORAGE UTILITIES =================

// Retrieves data from localStorage for a given key
function getData(key) {

    // Get raw data (string) from localStorage
    let data = localStorage.getItem(key);

    // If data exists, parse it into JSON, otherwise return empty array
    return data ? JSON.parse(data) : [];
}


// Saves data into localStorage for a given key
function setData(key, value) {

    // Convert JavaScript object/array into JSON string and store it
    localStorage.setItem(key, JSON.stringify(value));
}