let correctUsername = "admin";
let correctPassword = "1234";

let usernames = ["user", "admin", "admin"];
let passwords = ["1111", "1234", "0000"];

let attempts = 0;

while (attempts < 3) {
    if (usernames[attempts] === correctUsername &&
        passwords[attempts] === correctPassword) {

        console.log("Login Successful");
        break;

    } else {
        console.log("Invalid Credentials");
        attempts++;
    }
}

if (attempts === 3) {
    console.log("Account Locked");
}
