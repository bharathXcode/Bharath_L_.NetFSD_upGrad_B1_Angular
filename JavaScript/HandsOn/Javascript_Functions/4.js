//function with rest parameter
//used to handle multilple parameters
function sum(...numbers) {
    let total = 0;
    for (let k of numbers) {
        total = total + k;
    }
    return total;
}
console.log(sum(3, 4, 5, 6, 7))
console.log(sum(67, 78, 89, 54, 43))
function showFlowers(...flowers) {
    for (let flower of flowers) {
        console.log(flower);
    }
}
showFlowers('Rose', 'Lilly', 'Jasmine', 'Tulips');