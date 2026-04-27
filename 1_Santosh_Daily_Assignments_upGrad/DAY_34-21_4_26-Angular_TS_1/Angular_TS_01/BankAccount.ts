class BankAccount {
    depositorName: string;
    accountNumber: number;
    accountType: string;
    balance: number;

    constructor(name: string, accNo: number, type: string, balance: number) {
        this.depositorName = name;
        this.accountNumber = accNo;
        this.accountType = type;
        this.balance = balance;
    }

    deposit(amount: number): void {
        this.balance += amount;
        console.log(`Deposited: ${amount}`);
    }

    withdraw(amount: number): void {
        if (amount > this.balance) {
            console.log("Insufficient Balance");
        } else {
            this.balance -= amount;
            console.log(`Withdrawn: ${amount}`);
        }
    }

    display(): void {
        console.log("Name:", this.depositorName);
        console.log("Balance:", this.balance);
    }
}

// Usage
const acc = new BankAccount("Bharath", 101, "Savings", 5000);
acc.deposit(2000);
acc.withdraw(1000);
acc.display();