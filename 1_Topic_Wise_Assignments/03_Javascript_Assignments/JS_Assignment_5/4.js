class Vehicle {
    constructor(brand, speed) {
        this.brand = brand;
        this.speed = speed;
    }

    start() {
        console.log(`${this.brand} vehicle started.`);
    }
}

class Car extends Vehicle {
    constructor(brand, speed, fuelType) {
        super(brand, speed);
        this.fuelType = fuelType;
    }

    showDetails() {
        console.log(`Brand: ${this.brand}`);
        console.log(`Speed: ${this.speed}`);
        console.log(`Fuel Type: ${this.fuelType}`);
    }
}

let car1 = new Car("Toyota", 120, "Petrol");
car1.start();
car1.showDetails();

let car2 = new Car("Hyundai", 110, "Petrol + Hybrid");
car2.start();
car2.showDetails();