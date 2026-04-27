class Shapes {

    // Rectangle
    area(length: number, breadth: number): number;

    // Circle
    area(radius: number): number;

    // Triangle
    area(base: number, height: number, isTriangle: boolean): number;

    // Implementation
    area(a: number, b?: number, isTriangle?: boolean): number {
        if (b !== undefined && !isTriangle) {
            return a * b; // Rectangle
        } else if (b !== undefined && isTriangle) {
            return 0.5 * a * b; // Triangle
        } else {
            return Math.PI * a * a; // Circle
        }
    }
}

// Usage
const shape = new Shapes();
console.log("Rectangle Area:", shape.area(10, 5));
console.log("Circle Area:", shape.area(7));
console.log("Triangle Area:", shape.area(10, 5, true));