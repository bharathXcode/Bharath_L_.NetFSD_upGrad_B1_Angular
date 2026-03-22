let name = 'Virat';
let user = {
    name,
    age: 23,
    city: 'Delhi',
    greet() {
        console.log(`Name:${this.name} Age:${this.age} city:${this.city}`);
    }
}
console.log(user.name)
user.greet();