const run = async () => {
    const url = 'https://my-test-project-e1efb.firebaseio.com/books.json';
    const response = await fetch(url);
    const books = await response.json();
    console.log(books);
    let booksString = JSON.stringify(books);
    let body = document.getElementsByTagName('body')[0];
    body.innerHTML = booksString;
};

run();