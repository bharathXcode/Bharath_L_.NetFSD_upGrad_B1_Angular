//A class is a blueprint. 
// An object is an instance of that blueprint.
class Person {
  constructor() {
    //default constructor
    this.Pid = 1;
    this.Pname = "Ram";
    this.City = "Bangalore";
  }
}
const person = new Person();
console.log(person.Pid + " " + person.Pname + " " + person.City);
const person1 = new Person();
person1.Pid = 2;
person1.Pname = "Virat";
person1.City = "Delhi";
console.log(person1.Pid + " " + person1.Pname + " " + person1.City);
const persons = [
  person, person1,
]
for (let p of persons) {
  console.log(p);
}
