class Wallet {
    #balance = 0;

    addMoney(amount) {
        if (amount > 0) {
            this.#balance += amount;
        }
    }

    spendMoney(amount) {
        if (amount > this.#balance) {
            console.log("Insufficient funds.");
        } else {
            this.#balance -= amount;
        }
    }

    getBalance() {
        return this.#balance;
    }
}

let w1 = new Wallet();
w1.addMoney(1000);
w1.spendMoney(300);
console.log("Balance:", w1.getBalance());