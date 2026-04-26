class Book {
    title: string;
    author: string;
    isbn: string;
    price: number;

    constructor(title: string, author: string, isbn: string, price: number) {
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        this.price = price;
    }

    displayDetails(): void {
        console.log("Book Details:");
        console.log("Title:", this.title);
        console.log("Author:", this.author);
        console.log("ISBN:", this.isbn);
        console.log("Price:", this.price);
    }
}

// Usage
const book1 = new Book("Atomic Habits", "James Clear", "12345", 499);
book1.displayDetails();