//Inheritance allows one class to inherit properties and methods
//  from another.   
class Animal {

    constructor(name) {
        this.name = name;
    }

    speak() {
        console.log(`${this.name} makes a sound.`);

    }
}

class Dog extends Animal {

    speak() {
        super.speak(); //invokes animal class speak()
        console.log(`${this.name} barks.`);
    }
}
const animal = new Animal("Blacky");
animal.speak();
const dog = new Dog("Buddy");
dog.speak(); // Output: Buddy barks.


