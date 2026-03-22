function loginUser(username, password) {
    return new Promise(function (resolve, reject) {
        setTimeout(function () {
            if (username == 'Virat' && password == '1234') {
                resolve({ status: 'seccess', user: username });
            } else {
                reject({ status: 'error', message: 'Invalid Credentials' });
            }
        }, 3000)
    });
}
loginUser('Virat', '1234')
    .then((response) => {
        console.log('Login Success:', response);
    })
    .catch((error) => console.log('Login Failed: ', error))