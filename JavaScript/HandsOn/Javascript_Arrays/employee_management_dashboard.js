let employees = [
    { id: 1, name: "Ravi", dept: "IT", salary: 60000 },
    { id: 2, name: "Anita", dept: "HR", salary: 40000 },
    { id: 3, name: "Karan", dept: "IT", salary: 75000 },
    { id: 4, name: "Meena", dept: "Finance", salary: 50000 }
];
// 1 IT Employees
let itEmployees = employees.filter(e => e.dept === "IT");

// 2 Increase HR salary
employees = employees.map(e =>
    e.dept === "HR" ? { ...e, salary: e.salary * 1.1 } : e
);

// 3 Highest salary
let highest = employees.reduce((max, e) =>
    e.salary > max.salary ? e : max
);

// 4 Dept-wise salary
let deptSalary = employees.reduce((acc, e) => {
    acc[e.dept] = (acc[e.dept] || 0) + e.salary;
    return acc;
}, {});

// 5 Sorting
let sorted = [...employees].sort((a, b) => b.salary - a.salary);

console.log(deptSalary);
// 🧩 Requirements

// Filter IT employees.

// Increase salary of HR employees by 10%.

// Find highest paid employee.

// Calculate department-wise total salary.

// Sort employees by salary descending.