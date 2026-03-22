const Book = require('./Book');
const Member = require('./Member');

class Library {
    constructor() {
        if (Library.instance) return Library.instance;
        this.books = [];
        this.members = [];
        Library.instance = this;
    }

    addBook(title, author) {
        const id = Date.now().toString();
        const book = new Book(id, title, author);
        this.books.push(book);
        console.log(`✅ Book added: "${title}" by ${author}`);
    }

    addMember(name) {
        const member = new Member(name);
        this.members.push(member);
        console.log(`👤 Member added: ${name}`);
    }

    listBooks() {
        console.log("📚 Available Books:");
        this.books.forEach(book => {
            console.log(`🆔 ${book.id} | 📘 ${book.title} | ✍️ ${book.author} | ${book.isAvailable ? "✅ Available" : "❌ Borrowed"}`);
        });
    }

    findBook(id) {
        return this.books.find(book => book.id === id);
    }

    findMember(name) {
        return this.members.find(member => member.name === name);
    }
}

module.exports = new Library();
