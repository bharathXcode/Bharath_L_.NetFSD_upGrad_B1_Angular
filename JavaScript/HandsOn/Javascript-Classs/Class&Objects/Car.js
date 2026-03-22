//A class is a blueprint. 
// An object is an instance of that blueprint.
class Car {
  //parameterized constructor
  constructor(brand, model) {
    this.brand = brand;
    this.model = model;
  }

  showDetails() {
    console.log(`🚗 This car is a ${this.brand} ${this.model}`);
  }
  show = () => {
    console.log("Hello");
  }
}

const car1 = new Car("Toyota", "Corolla");
car1.showDetails(); // Output: This car is a Toyota Corolla
car1.show();
let cars = [
  new Car("hundai", "i1o"),
  new Car('Maruti', 'Alto'),
  new Car('Tata', 'Curve')
]
for (let car of cars) {
  car.showDetails();
}
