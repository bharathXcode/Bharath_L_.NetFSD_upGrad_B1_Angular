let array = [];
let choices = ["add", "add", "display", "remove", "display", "exit"];
let index = 0;

do {

    let choice = choices[index];
    index++;

    switch (choice) {

        case "add":
            array.push("Item" + index);
            console.log("Element Added");
            break;

        case "remove":
            array.pop();
            console.log("Element Removed");
            break;

        case "display":
            console.log("Array:", array);
            break;

        case "exit":
            console.log("Exiting Program...");
            break;

        default:
            console.log("Invalid Choice");
    }

} while (choices[index - 1] !== "exit");
