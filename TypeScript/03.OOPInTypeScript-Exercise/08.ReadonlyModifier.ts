class Book {
    public readonly title: string;
    public  readonly author: string;

    constructor(title: string, author: string) {
        this.title = title;
        this.author = author;
    }
}

const book = new Book("1984", "George Orwell");
console.log(`${book.title} by ${book.author}`);

// book.title = "Brave New World"; Error: Cannot assign to 'title' because it is a read-only property
// book.author = "Terry Pratchet"; Error: Cannot assign to author because it is a read-only property