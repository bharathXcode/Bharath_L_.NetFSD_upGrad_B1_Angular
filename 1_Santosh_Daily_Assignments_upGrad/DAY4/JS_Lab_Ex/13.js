let numbers = [10, 15, 20, 25, 30];

let sum = 0;
let evenCount = 0;
let oddCount = 0;

for (let i = 0; i < numbers.length; i++) {

    sum += numbers[i];

    if (numbers[i] % 2 === 0) {
        evenCount++;
    } else {
        oddCount++;
    }
}

let average = sum / numbers.length;

console.log("Numbers:", numbers);
console.log("Sum:", sum);
console.log("Average:", average);
console.log("Even Numbers Count:", evenCount);
console.log("Odd Numbers Count:", oddCount);
