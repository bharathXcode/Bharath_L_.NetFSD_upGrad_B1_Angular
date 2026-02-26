class BankAccount {
    constructor(accountHolder, balance) {
        this.accountHolder = accountHolder;
        this.balance = balance;
    }

    deposit(amount) {
        if (amount > 0) {
            this.balance += amount;
            console.log(`Deposited ₹${amount}`);
        } else {
            console.log("Deposit amount must be positive.");
        }
    }

    withdraw(amount) {
        if (amount > this.balance) {
            console.log("Insufficient balance. Withdrawal denied.");
        } else if (amount <= 0) {
            console.log("Withdrawal amount must be positive.");
        } else {
            this.balance -= amount;
            console.log(`Withdrawn ₹${amount}`);
        }
    }

    checkBalance() {
        console.log(`Current Balance: ₹${this.balance}`);
    }
}

let acc = new BankAccount("Bharath L", 1000);
acc.deposit(500);
acc.withdraw(2000);
acc.withdraw(300);
acc.checkBalance();