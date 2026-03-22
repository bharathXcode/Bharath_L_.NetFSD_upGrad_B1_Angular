function getData() {
    return new Promise((resolve, reject) => {
        let success = true;

        setTimeout(() => {
            if (success)
                resolve("Data loaded");
            else
                reject("Error loading data");
        }, 2000);
    });
}

async function load() {
    try {
        let result = await getData();
        console.log(result);
    }
    catch (error) {
        console.log(error);
    }
}

load();