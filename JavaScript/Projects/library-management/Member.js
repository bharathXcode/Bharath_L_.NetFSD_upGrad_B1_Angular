class Member {
  constructor(name) {
    this.name = name;
    this.borrowedBooks = [];
  }

  borrowBook(book) {
    if (book.borrow()) {
      this.borrowedBooks.push(book);
      console.log(`${this.name} borrowed "${book.title}"`);
    } else {
      console.log(`"${book.title}" is not available.`);
    }
  }

  returnBook(bookId) {
    const index = this.borrowedBooks.findIndex(b => b.id === bookId);
    if (index !== -1) {
      this.borrowedBooks[index].returnBook();
      console.log(`${this.name} returned "${this.borrowedBooks[index].title}"`);
      this.borrowedBooks.splice(index, 1);
    } else {
      console.log(`No book with ID ${bookId} found in borrowed list.`);
    }
  }
}

module.exports = Member;
