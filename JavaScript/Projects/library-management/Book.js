class Book {
  constructor(id, title, author) {
    this.id = id;
    this.title = title;
    this.author = author;
    this.isAvailable = true;
  }

  borrow() {
    if (this.isAvailable) {
      this.isAvailable = false;
      return true;
    }
    return false;
  }

  returnBook() {
    this.isAvailable = true;
  }
}

module.exports = Book;
