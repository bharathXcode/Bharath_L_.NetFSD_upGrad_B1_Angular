let n = [23, 34, 45, 56, 67, 56]
let result = n.find(i => i > 50);
let users = [
    { id: 1, name: 'Tim', salary: 1200 },
    { id: 2, name: 'John', salary: 15000 },
    { id: 3, name: 'Suren', salary: 20000 },
    { id: 4, name: 'Tony', salary: 13000 },
]
//Find

let user = users.find(i => i.id == 4) //returns first value that matches the condition
user = users.find(i => i.salary > 10000) //return john details
if (user != null)
    console.log(user.name);
else
    console.log('Invalid Id')

//Filter
//return multiple values
result = n.filter(n => n > 40);
console.log(result);
let arr = users.filter(i => i.salary > 10000)
console.log(arr);
