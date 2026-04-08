class Animal {
    makeSound() {
        console.log("Animal makes sound");
    }
}

class Dog extends Animal {
    makeSound() {
        console.log("Dog barks");
    }
}

class Cat extends Animal {
    makeSound() {
        console.log("Cat meows");
    }
}

class Cow extends Animal {
    makeSound() {
        console.log("Cow moos");
    }
}

let animals = [new Dog(), new Cat(), new Cow()];
animals.forEach(a => a.makeSound());