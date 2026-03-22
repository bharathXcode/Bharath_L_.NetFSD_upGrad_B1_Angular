function f()
{
    return [1, 6, 7, 4, 8, 0];
}
function returnmultiple()
{
    let x=10;
    let y=20;
    return [x,y];
}
var a,b;

[a,b]=returnmultiple();
console.log(a)
console.log(b)
var q, w, e, r, t, y;
[q,w,,r,,y]=f()
console.log(q)
console.log(y)
console.log(r)