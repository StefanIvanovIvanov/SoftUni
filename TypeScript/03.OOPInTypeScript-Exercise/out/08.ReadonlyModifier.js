"use strict";
class Book {
    title;
    author;
    constructor(title, author) {
        this.title = title;
        this.author = author;
    }
}
const book = new Book("1984", "George Orwell");
console.log(`${book.title} by ${book.author}`);
// book.title = "Brave New World"; Error: Cannot assign to 'title' because it is a read-only property
// book.author = "Terry Pratchet"; Error: Cannot assign to author because it is a read-only property
//# sourceMappingURL=08.ReadonlyModifier.js.map