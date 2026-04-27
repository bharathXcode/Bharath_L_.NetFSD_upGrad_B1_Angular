"use strict";
class BankAccount {
    depositorName;
    accountNumber;
    accountType;
    balance;
    constructor(name, accNo, type, balance) {
        this.depositorName = name;
        this.accountNumber = accNo;
        this.accountType = type;
        this.balance = balance;
    }
    deposit(amount) {
        this.balance += amount;
        console.log(`Deposited: ${amount}`);
    }
    withdraw(amount) {
        if (amount > this.balance) {
            console.log("Insufficient Balance");
        }
        else {
            this.balance -= amount;
            console.log(`Withdrawn: ${amount}`);
        }
    }
    display() {
        console.log("Name:", this.depositorName);
        console.log("Balance:", this.balance);
    }
}
// Usage
const acc = new BankAccount("Bharath", 101, "Savings", 5000);
acc.deposit(2000);
acc.withdraw(1000);
acc.display();
