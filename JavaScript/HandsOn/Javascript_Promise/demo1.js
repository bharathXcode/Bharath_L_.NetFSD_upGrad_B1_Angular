let myPromise = new Promise(function (resolve, reject) {
    console.log('Fetching Data...');
    setTimeout(function () {
        let success = true;
        if (success) {
            resolve('Data Fetched Successfully');
        } else {
            reject('Failed to Fetch data!! ');
        }
    }, 3000);
});
//execute
myPromise
    .then(function (response) {
        console.log(response);
    })
    .catch(function (error) {
        console.log(error);
    })
/*
1.promise created->state-pending
2. after 3 seconds->resolve/reject
3..then() handle sccess
4. .catch() handle error
*/