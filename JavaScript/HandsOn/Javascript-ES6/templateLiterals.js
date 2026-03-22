//Template literals (also called template strings) are a feature
//  introduced in ES6 that make working with strings in JavaScript 
// much more flexible and readable. Instead of using single (') 
// or double (") quotes, template literals use backticks (`), 
// allowing you to
//1. String Interpolation
const n = "Santosh";
console.log(`Hello, ${n}!`); // Output: Hello, Santosh!
const x = 5, y = 10;
console.log(`Sum: ${x + y}`); // Output: Sum: 15
//2. Multiline Strings
const message = `This is line one.
This is line two.
This is line three.`;

console.log(message);
//3. HTML Templates
//Perfect for generating dynamic HTML snippets.
const items = ["Book", "Pen", "Notebook"];
const html = `
  <ul>
    ${items.map(item => `<li>${item}</li>`).join("")}
  </ul>
`;

console.log(html);
//Tagged Templates (Advanced)
//You can pass a template literal to a function 
// to customize its output.
function shout(strings, value) {
    return `${strings[0]}${value.toUpperCase()}${strings[1]}`;
}

const n1 = "santosh";
console.log(shout`Hello, ${n1}!`); // Output: Hello, SANTOSH!
