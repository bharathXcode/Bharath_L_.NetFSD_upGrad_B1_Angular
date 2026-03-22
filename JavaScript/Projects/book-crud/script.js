const API_URL = "http://localhost:3000/books";
async function getBooks() {
    const response = await fetch(API_URL);
    const books = await response.json();

    const table = document.getElementById("bookTable");
    table.innerHTML = "";

    books.forEach(book => {
        table.innerHTML += `
            <tr>
                <td>${book.title}</td>
                <td>${book.author}</td>
                <td>${book.price}</td>
                <td>
                    <button onclick="editBook(${book.id})">Edit</button>
                    <button onclick="deleteBook(${book.id})">Delete</button>
                </td>
            </tr>
        `;
    });
}

getBooks();
document.getElementById("bookForm").addEventListener("submit", async function (e) {
    e.preventDefault();

    const id = document.getElementById("bookId").value;
    const title = document.getElementById("title").value;
    const author = document.getElementById("author").value;
    const price = document.getElementById("price").value;

    const book = { title, author, price };

    if (id) {
        await updateBook(id, book);
    } else {
        await fetch(API_URL, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(book)
        });
    }

    this.reset();
    getBooks();
});
async function editBook(id) {
    const response = await fetch(API_URL + "/" + id);
    const book = await response.json();

    document.getElementById("bookId").value = book.id;
    document.getElementById("title").value = book.title;
    document.getElementById("author").value = book.author;
    document.getElementById("price").value = book.price;
}

async function updateBook(id, book) {
    await fetch(API_URL + "/" + id, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(book)
    });
}
async function deleteBook(id) {
    await fetch(API_URL + "/" + id, {
        method: "DELETE"
    });

    getBooks();
}