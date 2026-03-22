//Map was introduced in ES6
// A Map is a collection of key-value pairs
//Key can be of any data-type
//Map has in built methods
let map = new Map();//create map object
map.set('Id', 3233);
map.set('Name', 'Virat');
console.log(map.get('Id'))
console.log(map.get('Name'));
let userMap = new Map([
    ["id", 101],
    ["name", "San"],
    ["role", 'Trainer']
]);
console.log(userMap)
console.log(userMap.has('city'));
userMap.delete('role') //delete key-value pair
//userMap.clear(); //cleare all the key pairs
console.log('size ' + userMap.size);
//key as an object
let user = { id: 12334 };
let map1 = new Map();
map1.set(user, "San");
map1.set(user.id, user);
//Iterating Map object
for (let [key, value] of userMap) {
    console.log(key, value);
}
//get keys
for (let key of userMap.keys()) {
    console.log(key);
}
for (let entry of map.entries())
    console.log(entry);
userMap.forEach((k, v) => {
    console.log(k, v)
})