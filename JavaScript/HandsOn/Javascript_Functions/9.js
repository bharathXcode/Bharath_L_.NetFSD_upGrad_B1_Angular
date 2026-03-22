//constructor function
//used to creae objects(before es6)
function Person(name, age) {
    this.name = name;
    this.age = age;
}
const p1 = new Person('Virat', 34);
console.log(`Name:${p1.name} Age:${p1.age}`);