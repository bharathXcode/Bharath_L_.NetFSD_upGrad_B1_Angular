let numbers = [45, 12, 89, 32, 67];

let largest = numbers[0];
let smallest = numbers[0];

for (let i = 1; i < numbers.length; i++) {
    if (numbers[i] > largest) {
        largest = numbers[i];
    }

    if (numbers[i] < smallest) {
        smallest = numbers[i];
    }
}

console.log("Numbers:", numbers);
console.log("Largest:", largest);
console.log("Smallest:", smallest);
