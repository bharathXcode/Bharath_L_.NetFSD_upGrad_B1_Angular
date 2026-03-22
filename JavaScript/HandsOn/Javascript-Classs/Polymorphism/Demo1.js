//Polymorphism means many forms—the same method behaves differently 
// depending on the object.
class Shape {
    area() {
        return 0;
    }
}

class Circle extends Shape {
    constructor(radius) {
        super();
        this.radius = radius;
    }

    area() {
        return Math.PI * this.radius ** 2;
    }
}

class Square extends Shape {
    constructor(side) {
        super();
        this.side = side;
    }

    area() {
        return this.side ** 2;
    }
}

const shapes = [new Circle(3), new Square(4)];
shapes.forEach(shape => console.log(shape.area()));
