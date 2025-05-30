"use strict";
class Product {
    static productCount = 0;
    id;
    _name;
    _price;
    constructor(name, price) {
        Product.productCount++;
        this.id = Product.productCount;
        this._name = name;
        this._price = price;
    }
    get name() {
        return this._name;
    }
    set name(newName) {
        if (newName.length >= 1) {
            this.name = newName;
        }
        else {
            throw Error('name must be at least 1 character');
        }
    }
    get price() {
        return this._price;
    }
    set price(newPrice) {
        if (newPrice > 0) {
            this.price = newPrice;
        }
        else {
            throw Error('price must be bigger than 0');
        }
    }
    getDetails() {
        return `ID: ${this.id}, Name: ${this.name}, Price: $${this.price}`;
    }
}
class Inventory {
    products = [];
    addProduct(product) {
        this.products.push(product);
    }
    ;
    listProducts() {
        let productList = this.products.map(p => p.getDetails());
        return `${productList.join('\n')}\nTotal products created: ${this.products.length}`;
    }
}
const inventory = new Inventory();
const product1 = new Product("Laptop", 1200);
const product2 = new Product("Phone", 800);
inventory.addProduct(product1);
inventory.addProduct(product2);
console.log(inventory.listProducts());
// should be error: cannot assign to 'productCount'
// Product.productCount = 10;
// const product = new Product("", 800);
//# sourceMappingURL=13.InventorySystem.js.map