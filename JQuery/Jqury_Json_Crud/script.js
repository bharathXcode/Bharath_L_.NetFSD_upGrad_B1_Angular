const API_URL = "http://localhost:3000/books";

$(document).ready(function () {

    loadBooks();

    // CREATE
    $("#saveBtn").click(function () {
        const book = {
            title: $("#title").val(),
            author: $("#author").val(),
            price: parseFloat($("#price").val())
        };

        $.ajax({
            url: API_URL,
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(book),
            success: function () {
                clearForm();
                loadBooks();
            }
        });
    });

    // UPDATE
    $("#updateBtn").click(function () {
        const id = $("#bookId").val();

        const updatedBook = {
            title: $("#title").val(),
            author: $("#author").val(),
            price: parseFloat($("#price").val())
        };

        $.ajax({
            url: API_URL + "/" + id,
            method: "PUT",
            contentType: "application/json",
            data: JSON.stringify(updatedBook),
            success: function () {
                clearForm();
                loadBooks();
                $("#saveBtn").show();
                $("#updateBtn").hide();
            }
        });
    });

});

// READ
function loadBooks() {
    $.get(API_URL, function (data) {
        $("#bookTable").empty();

        data.forEach(book => {
            $("#bookTable").append(`
                <tr>
                    <td>${book.id}</td>
                    <td>${book.title}</td>
                    <td>${book.author}</td>
                    <td>${book.price}</td>
                    <td>
                        <button onclick="editBook('${book.id}')">Edit</button>
                        <button onclick="deleteBook(${book.id})">Delete</button>
                    </td>
                </tr>
            `);
        });
    });
}

// DELETE
function deleteBook(id) {
    $.ajax({
        url: API_URL + "/" + id,
        method: "DELETE",
        success: function () {
            loadBooks();
        }
    });
}

// EDIT
function editBook(id) {
    // let id = 'b792'
    //alert(`${API_URL}/${id}`)
    $.get(`${API_URL}/${id}`, function (book) {
        $("#bookId").val(book.id);
        $("#title").val(book.title);
        $("#author").val(book.author);
        $("#price").val(book.price);

        $("#saveBtn").hide();
        $("#updateBtn").show();
    });
}

// Clear Form
function clearForm() {
    $("#bookId").val("");
    $("#title").val("");
    $("#author").val("");
    $("#price").val("");
}