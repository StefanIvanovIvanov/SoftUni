export { };

function validateName(minLength: number) {
    return function (target: any, propertyName: string, descriptor: PropertyDescriptor) {
        const originalSetter = descriptor.set;

        descriptor.set = function (val: string) {
        if (val.length < minLength) {
            throw new Error(`Name must have a min length of ${minLength} characters`);
        }

        originalSetter?.call(this, val);
    }

        return descriptor
    }
}

function validateAge(min: number, max: number) {
    return function (target: any, propertyName: string, descriptor: PropertyDescriptor) {
        const originalSetter = descriptor.set;

        descriptor.set = function (val: number) {
        if (val < min || val > max) {
            throw new Error(`Age must be between ${min} and ${max}`);
        }

        originalSetter?.call(this, val);
    }

        return descriptor
    }
}

function validatePassword(pattern: RegExp) {
    return function (target: any, propertyName: string, descriptor: PropertyDescriptor) {

        const originalSetter = descriptor.set;

        descriptor.set = function (val: string) {
        let isValidPassword = val.match(pattern); // use match method, not test method for decorators!

        if (!isValidPassword) {
            throw new Error(`Password needs to match ${pattern}`);
        }

        originalSetter?.call(this, val);
    }

        return descriptor
    }
}

class User {
    private _name!: string;
    private _age!: number;
    private _password!: string;

    constructor(name: string, age: number, password: string) {
        this.name = name;
        this.age = age;
        this.password = password;
    }

    @validateName(1)
    set name(val: string) { this._name = val; }

    @validateAge(1, 150)
    set age(val: number) { this._age = val; }

    @validatePassword(/^[a-zA-Z0-9!@]+$/g)
    set password(val: string) { this._password = val; }

    get name() { return this._name; }
    get age() { return this._age; }
}

// minLength = 1
// min = 1, max = 150
// regex = /^[a-zA-Z0-9!@]+$/g

let user = new User('John', 130, 'hardPassword12');
let user2 = new User('John', 30, '!test');
let user3 = new User('John', 25, '@werty');
let user4 = new User('Jo', 20, 'password123');


// Should return runtime errors:

// minLength = 3
// min = 1, max = 100
// regex = /^[a-zA-Z0-9]+$/g

// let user = new User('John', 130, 'hardPassword12');
// let user2 = new User('John', 30, '!test');
// let user3 = new User('John', 25, '@werty');
// let user4 = new User('Jo', 20, 'password123');
