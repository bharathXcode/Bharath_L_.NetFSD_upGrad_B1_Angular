let salaries = [25000, 30000, 28000, 40000, 35000];

let total = 0;

for (let i = 0; i < salaries.length; i++) {
    total += salaries[i];
}

let average = total / salaries.length;

console.log("Salaries:", salaries);
console.log("Total Salary:", total);
console.log("Average Salary:", average);
console.log("Salaries Above Average:");

for (let i = 0; i < salaries.length; i++) {
    if (salaries[i] > average) {
        console.log(salaries[i]);
    }
}
