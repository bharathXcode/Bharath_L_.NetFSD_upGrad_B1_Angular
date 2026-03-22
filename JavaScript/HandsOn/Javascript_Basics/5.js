//conditional statements 
//if statement
//if..else statement
//else..if ladder
//switch statement
//ternary operator(? :)
//if statement
let age = 18;
if (age >= 18) {
    console.log('You are eligible to vote');
}
//if..else statement
let n = 5;
if (n % 2 === 0) {
    console.log('Even Number')
}
else {
    console.log('Odd Number')
}
//else.. if statement
let marks = 82;
if (marks >= 90) {
    console.log('Grader A');
} else if (marks >= 75) {
    console.log('Grader B');
} else if (marks >= 60) {
    console.log('Grade C')
} else {
    console.log('Fail')
}
//switch
let day = 3;
switch (day) {
    case 1:
        console.log('Monday');
        break; //prevents fall through
    case 2:
        console.log('Tuesday');
        break;
    case 3:
        console.log('Wednesday');
        break;
    case 4:
        console.log('Thursday');
        break;
    case 6:
    case 7:
        console.log('Weekend');
        break;
    default:
        console.log('Invalid day');
}
//Ternary
age = 16;
let result = age >= 18 ? 'Adult' : 'Minor';
console.log(result);
