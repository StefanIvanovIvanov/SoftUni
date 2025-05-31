"use strict";
// functions
function getFirstElement(arr) {
    return arr[0];
}
const firstEl = getFirstElement(['pen4o', 'dim4o']);
console.log(firstEl);
const firstNumEl = getFirstElement([3, 5]);
console.log(firstNumEl);
function echo(arg) {
    console.log(typeof arg);
    return arg;
}
echo('hello');
echo(123);
const takeLast = (array) => {
    return array.pop();
};
const sample = takeLast(['Hello', 'World', 'TypeScript']);
const secondSample = takeLast([1, 2, 3, 4]);
console.log(sample, secondSample);
const makeTuple = (a, b) => {
    return [a, b];
};
const firstTuple = makeTuple(1, 2);
const secondTuple = makeTuple('a', 'b');
console.log(firstTuple, secondTuple);
let message1 = {
    name: "hello",
    text: "text",
    data: "data",
};
let message2 = {
    name: "hello",
    text: "text",
    data: { greeting: "hi there", phone: 12345 },
};
console.log(message1.data.length);
console.log(message2.data.phone);
// type
function logItemId(item) {
    console.log(item);
}
logItemId({ id: 2, name: "min4o", age: 30 });
logItemId({ id: 3, email: "pen4o@abv.bg" });
// class
class StorateBox {
    items = [];
    constructor(initialTems) {
        this.items = initialTems;
    }
    getAllItems() {
        return this.items;
    }
    getFirstItem() {
        return this.items[0];
    }
    addItem(newItem) {
        this.items.push(newItem);
    }
    reverseItems() {
        return this.items.reverse();
    }
    removeItem(item) {
        const index = this.items.indexOf(item);
        if (index > -1) {
            this.items.splice(index, 1);
        }
    }
}
const box1 = new StorateBox(['pen4o', 'min4o']);
box1.addItem('ginka');
box1.addItem('ivan4o');
box1.removeItem('min4o');
box1.reverseItems();
console.log(box1.getAllItems());
console.log(box1.reverseItems());
const box2 = new StorateBox([3, 4, 5]);
box2.addItem(7);
box2.removeItem(5);
console.log(box2.getAllItems());
class ApiResponse {
    isSuccessful;
    data;
    error;
    constructor(isSuccessful, data, error) {
        this.isSuccessful = isSuccessful;
        this.data = data;
        this.error = error;
    }
    getResult() {
        if (!this.isSuccessful || this.data === null) {
            throw new Error(String(this.error));
        }
        return this.data;
    }
}
const userResponse1 = new ApiResponse(true, 'pen4o', null);
const userResponse2 = new ApiResponse(true, ['pen4o', 'min4o', 'go6o'], null);
const userResponse3 = new ApiResponse(false, null, 'Unknown Error');
console.log(userResponse1.getResult());
console.log(userResponse2.getResult());
let newUser = {
    id: 1,
    username: "pen4o",
    email: "pen4o@abv.bg"
};
let username = newUser['username']; // same as T[K] above (type[key]) with T type being User => get the type of the property we search by the key
//# sourceMappingURL=demo.js.map