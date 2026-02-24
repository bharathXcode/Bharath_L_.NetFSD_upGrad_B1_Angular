let start = 1;
let end = 20;
let count = 0;

console.log("Prime Numbers between", start, "and", end, ":");

for (let i = start; i <= end; i++) {

    let isPrime = true;

    if (i <= 1) {
        isPrime = false;
    }

    for (let j = 2; j < i; j++) {
        if (i % j === 0) {
            isPrime = false;
            break;
        }
    }

    if (isPrime) {
        console.log(i);
        count++;
    }
}

console.log("Total Prime Numbers:", count);
