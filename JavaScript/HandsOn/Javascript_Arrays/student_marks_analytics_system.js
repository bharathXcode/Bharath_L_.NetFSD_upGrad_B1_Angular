let marks = [78, 45, 89, 32, 67];
// 1. Add new mark
marks.push(91);

// 2. Remove last mark
marks.pop();

// 3. Passed students
let passed = marks.filter(m => m >= 40);

// 4. Distinction
let distinction = marks.filter(m => m >= 85);

// 5. Total & Average
let total = marks.reduce((sum, m) => sum + m, 0);
let avg = total / marks.length;

// 6. Sorting
let ascending = [...marks].sort((a, b) => a - b);
let descending = [...marks].sort((a, b) => b - a);

console.log("Marks:", marks);
console.log("Passed:", passed);
console.log("Distinction:", distinction);
console.log("Average:", avg);
console.log("Ascending:", ascending);
console.log("Descending:", descending);