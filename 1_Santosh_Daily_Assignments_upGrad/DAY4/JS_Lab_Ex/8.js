let prices = [500, 300, 400, 200];

let total = 0;

for (let i = 0; i < prices.length; i++) {
    total += prices[i];
}

if (total > 1000) {
    total = total - (total * 0.10);
}

console.log("Item Prices:", prices);
console.log("Final Bill:", total);
