//loops or iterative statements
//for
//while
//do..while
//for ...of(ES6)
//for ...in(ES6)
//for
for (let i = 1; i <= 5; i++) {
    console.log(i);
}
for (let i = 1; i <= 100000; i++) {
    if (i === 10)
        break;
    console.log(i);
}
//while
let i = 1;
while (i <= 5) {
    console.log(i);
    i++
}
//do-while
i = 6;
do {
    console.log(i);
    i++;
} while (i <= 5);
//for ... of
let colors = ["red", "blue", 'orange']
for (let color of colors) {
    console.log(color);
}
//for ... in
let user = {
    name: 'Virat',
    age: 35
};
console.log('Name: ' + user.name + ' age: ' + user.age);
console.log(`name:${user.name} age:${user.age}`);
for (let key in user) {
    console.log(`${key}:${user[key]}`)
}