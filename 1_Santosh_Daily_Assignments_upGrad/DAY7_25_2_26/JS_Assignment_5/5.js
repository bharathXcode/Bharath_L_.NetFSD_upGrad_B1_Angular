class Employee {
    constructor(name, salary) {
        this.name = name;
        this.salary = salary;
    }

    getDetails() {
        console.log(`Name: ${this.name}, Base Salary: ₹${this.salary}`);
    }
}

class Manager extends Employee {
    constructor(name, salary, bonus) {
        super(name, salary);
        this.bonus = bonus;
    }

    getTotalSalary() {
        return this.salary + this.bonus;
    }
}

class Director extends Manager {
    constructor(name, salary, bonus, stockOptions) {
        super(name, salary, bonus);
        this.stockOptions = stockOptions;
    }

    getFullCompensation() {
        return this.getTotalSalary() + this.stockOptions;
    }
}

let d1 = new Director("Rahul", 50000, 10000, 20000);
d1.getDetails();
console.log("Full Compensation:", d1.getFullCompensation());

let d2 = new Director("Bharath", 50000, 20000, 30000);
d2.getDetails();
console.log("Full Compensation:", d2.getFullCompensation());