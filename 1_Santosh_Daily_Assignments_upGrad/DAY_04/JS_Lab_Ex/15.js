let sales = [5000, 7000, 6500, 8000, 7200, 6000, 9000];

let total = 0;
let bestDayIndex = 0;
let worstDayIndex = 0;

for (let i = 0; i < sales.length; i++) {

    total += sales[i];

    if (sales[i] > sales[bestDayIndex]) {
        bestDayIndex = i;
    }

    if (sales[i] < sales[worstDayIndex]) {
        worstDayIndex = i;
    }
}

console.log("Daily Sales:", sales);
console.log("Total Weekly Sales:", total);
console.log("Best Day Sales:", sales[bestDayIndex]);
console.log("Worst Day Sales:", sales[worstDayIndex]);
