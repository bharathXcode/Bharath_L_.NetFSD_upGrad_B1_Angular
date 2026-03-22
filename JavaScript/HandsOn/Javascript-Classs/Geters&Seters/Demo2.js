class Book {
    constructor(title) {
        this._title = title; // underscore indicates a private-like field
    }

    // Getter
    get title() {
        return this._title.toUpperCase(); // Always return in uppercase
    }

    // Setter
    set title(newTitle) {
        if (newTitle.length < 3) {
            console.log(" Title too short.");
        } else {
            this._title = newTitle;
        }
    }
}

const b = new Book("Clean Code");
console.log(b.title); // Output: CLEAN CODE

b.title = "JS";       // Title too short.
console.log(b.title);
b.title = "JavaScript Essentials";
console.log(b.title); // Output: JAVASCRIPT ESSENTIALS
