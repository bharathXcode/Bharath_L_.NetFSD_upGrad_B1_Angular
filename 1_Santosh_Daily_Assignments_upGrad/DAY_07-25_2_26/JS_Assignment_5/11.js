class User {
    constructor(password) {
        this.password = password;
    }

    set password(value) {
        if (value.length >= 6) {
            this._password = value;
        } else {
            console.log("Password must be at least 6 characters.");
        }
    }

    get password() {
        return this._password;
    }
}

let u1 = new User("123456");
console.log("Password:", u1.password);