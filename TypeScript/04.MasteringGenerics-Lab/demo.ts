// functions

function getFirstElement<ElementType>(arr :ElementType[]): ElementType {
    return arr[0];
}

const firstEl = getFirstElement<string>(['pen4o', 'dim4o']);
console.log(firstEl)

const firstNumEl = getFirstElement<number>([3, 5]);
console.log(firstNumEl)

function echo<T>(arg: T) : T {
    console.log(typeof arg)
    return arg;
}

echo('hello');
echo(123);

const takeLast = <T>(array: T[]) => {
    return array.pop();
}

const sample = takeLast(['Hello', 'World', 'TypeScript']);
const secondSample = takeLast([1, 2, 3, 4]);
console.log(sample, secondSample);

const makeTuple = <T, V>(a: T, b: V) => {
    return [a, b];
}

const firstTuple = makeTuple(1, 2);
const secondTuple = makeTuple('a', 'b');
console.log(firstTuple, secondTuple);

// interfaces

interface Message<T> {
    name: string;
    text: string;
    data: T;
}

let message1: Message<string> = {
    name: "hello",
    text: "text",
    data: "data",
}

let message2: Message<{greeting: string, phone: number}> = {
    name: "hello",
    text: "text",
    data: {greeting: "hi there", phone: 12345},
}

console.log(message1.data.length);
console.log(message2.data.phone);

// type

function logItemId<T extends {id: number}>(item: T): void {
    console.log(item);
}

logItemId({id: 2, name: "min4o", age: 30});
logItemId({id: 3, email: "pen4o@abv.bg"});

// class

class StorateBox<T> {
    items: T[] = [];

    constructor(initialTems: T[]) {
        this.items = initialTems;
    }

    getAllItems(): T[] {
        return this.items
    }

    getFirstItem(): T {
        return this.items[0];
    }

    addItem(newItem: T) {
        this.items.push(newItem);
    }

    reverseItems(): T[] {
        return this.items.reverse();
    }

    removeItem(item: T): void {
        const index = this.items.indexOf(item);

        if (index > -1) {
            this.items.splice(index, 1);
        }
    }
}

const box1 = new StorateBox<string>(['pen4o', 'min4o']);
box1.addItem('ginka');
box1.addItem('ivan4o')
box1.removeItem('min4o');
box1.reverseItems();
console.log(box1.getAllItems());
console.log(box1.reverseItems());

const box2 = new StorateBox<number>([3, 4, 5]);
box2.addItem(7);
box2.removeItem(5);
console.log(box2.getAllItems());


class ApiResponse<T, U> {
    isSuccessful: boolean;
    data: T | null;
    error: U | null;

    constructor(isSuccessful: boolean, data: T | null, error: U | null) {
        this.isSuccessful = isSuccessful;
        this.data = data;
        this.error = error;
    }

    getResult(): T {
        if (!this.isSuccessful || this.data === null) {
            throw new Error(String(this.error));
        } 

        return this.data;
    }
}

const userResponse1 = new ApiResponse<string, string>(true, 'pen4o', null);
const userResponse2 = new ApiResponse(true, ['pen4o', 'min4o', 'go6o'], null)
const userResponse3 = new ApiResponse(false, null, 'Unknown Error');

console.log(userResponse1.getResult());
console.log(userResponse2.getResult());
//console.log(userResponse3.getResult()); throws error

// mapped types

type User = {
    id: number;
    username: string;
    email: string;
}

type Point = {
    x: number;
    y: number;
}

type MakeOptionalProperties<T> = {
    // for each key in key of type(type being e.g. User): type[key]
    [K in keyof T]?: T[K];
}

type PartialUser = MakeOptionalProperties<User>
type PartialPoint = MakeOptionalProperties<Point>

let newUser: User = {
    id: 1,
    username: "pen4o",
    email: "pen4o@abv.bg"
}

let username = newUser['username'] // same as T[K] above (type[key]) with T type being User => get the type of the property we search by the key

type Age = { age: number };
type Person = { name: string, age: number };
type strOrNum = Person extends Age ? string : number; // strOrNum == string


type Employee = {
    name: string;
    age: number;
    salary: number;
}

type Product = {
    title: string;
    price: number;
    isSrock: boolean;
    rating: number;
}

type GetNumericKeys<T> = {
    [K in keyof T]: T[K] extends number ? K : never;
}[keyof T];

// name: never;
// age: 'age';
// salary: 'salary';
type EmployeeGetNumericKeys = GetNumericKeys<Employee>; // "age" | "salary"
type ProductGetNumericKeys = GetNumericKeys<Product>; // "price" | "rating"
