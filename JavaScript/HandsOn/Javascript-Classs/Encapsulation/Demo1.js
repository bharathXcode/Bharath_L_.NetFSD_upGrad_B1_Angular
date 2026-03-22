//Encapsulation means bundling data and methods that operate 
// on that data into a single unit (class), 
// and restricting direct access to some components.
class BankAccount {
    #balance = 0; // private field
    deposit(amount) {
        if (amount > 0) this.#balance += amount;
    }

    getBalance() {
        return this.#balance;
    }
}

const account = new BankAccount();
account.deposit(1000);
//account.#balance=110;
//console.log(account.#balance); // Output: undefined
console.log(account.getBalance()); // Output: 1000

