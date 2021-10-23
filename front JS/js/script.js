onload = () => {
    getBooks();
}

getBooks = () => {
    fetch("https://localhost:5001/api/Book",
        {
            method: 'GET'
        })
        .then(response => response.json())
        .then(json => {
            var booksContainer = document.getElementById('books-container');
            booksContainer.innerHTML = '';
            json.forEach(book => {
                booksContainer.innerHTML += `<div class="card-group">
         <div class="card" style="flex:none; margin: 10px">
          <img style="width: 300px;" src="${book.img}" class="card-img-top" alt="...">
          <div class="card-body">
            <h5 class="card-title">${book.title}</h5>
            <p class="card-text">${book.description}</p>
            <p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>
          </div>
          <button type="button" class="btn btn-outline-danger" onclick="deleteBook(${book.id})">Delete</button>
          <button type="button" data-bs-toggle="modal" data-bs-target="#createModal" class="btn btn-outline-info"onclick="editBook(${book.id})">Edit</button>
        </div>
      </div>`
                    ;

            });
        })
        .catch(err => console.error(err))
}
getSingleBook = (id) => {
    fetch(`https://localhost:5001/api/Book/GetSingleBook/9`, {
        method: 'GET'
    })
}
editBook = () => {
    var book = {
        "Title": document.getElementById('editTitle').value,
        "Description": document.getElementById('editDescription').value,
        "Year": parseInt(document.getElementById('editYear').value),
        "Img": document.getElementById('editImage').value,
    };
    fetch('https://localhost:5001/api/Book/AddBook', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(book)
    })
        .then(res => {
            if (res.status === 200) {
                console.log('Succesfully add');
                getBooks();
            } else {
                console.log('Bad request');
            }
        })
}
deleteBook = (id) => {
    fetch(`https://localhost:5001/api/Book/DeleteBook/${id}`, {
        method: 'GET'
    })
        .then(res => {
            if (res.status === 200) {
                console.log('Succesfully deleted');
                getBooks();
            } else {
                console.log('Bad request');
            }
        })
}
addBook = () => {
    var book = {
        "Title": document.getElementById('inputTitle').value,
        "Description": document.getElementById('inputDescription').value,
        "Year": parseInt(document.getElementById('inputYear').value),
        "Img": document.getElementById('inputImage').value,
    };
    fetch('https://localhost:5001/api/Book/AddBook', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(book)
    })
        .then(res => {
            if (res.status === 200) {
                console.log('Succesfully add');
                getBooks();
            } else {
                console.log('Bad request');
            }
        })
}






























