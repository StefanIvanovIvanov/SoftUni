class Product {
    private static productCount: number = 0;
    private readonly id: number;
    private _name!: string;
    private _price!: number;

    constructor(name: string, price: number) {
        Product.productCount++;
        this.id = Product.productCount;
        this._name = name;
        this._price = price;
    }

    get name() {
        return this._name;
    }

    set name(newName: string) {
        if (newName.length >= 1) {
            this.name = newName;
        } else {
            throw Error('name must be at least 1 character');
        }
    }

    get price() {
        return this._price;
    }

    set price(newPrice: number) {
        if (newPrice > 0) {
            this.price = newPrice;
        } else {
            throw Error('price must be bigger than 0');
        }
    }

    public getDetails(): string {
        return `ID: ${this.id}, Name: ${this.name}, Price: $${this.price}`;
    }  
}

class Inventory {
    private products: Product[] = [];

    public addProduct(product: Product): void {
        this.products.push(product);
    };

    public listProducts(): string {
        let productList : string[] = this.products.map(p => p.getDetails());
        return `${productList.join('\n')}\nTotal products created: ${this.products.length}`
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