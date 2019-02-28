function CreateUser(bookName, bookAuthor, bookPrice, bookDescription) {
    $.ajax({
        url: "api/books",
        contentType: "application/json",
        method: "POST",
        data: JSON.stringify({
            name: bookName,
            author: bookAuthor,
            price: bookPrice,
            description: bookDescription
        }),
        success: function () {
            alert("hello");
        },
        statusCode: {
            404: function () {
                alert("There was a prob");
            }
        }
    });
}

$("#book-form").submit(function (e) {
    //alert("hello");
    e.preventDefault();
    //alert("hello");
    let name = this.elements["name"].value;
    let author = this.elements["author"].value;
    let price = this.elements["price"].value;
    let description = this.elements["description"].value;
    CreateUser(name, author, price, description);
    //alert("new");
});
