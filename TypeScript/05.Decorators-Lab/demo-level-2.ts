function FreezeClass(constructor: Function) {
    console.log('Freeze applied')

    Object.freeze(constructor);
    Object.freeze(constructor.prototype);
}

function ValidateStringAccessor(target: any, propertyName: string, descriptor: PropertyDescriptor) {

    const originalSetter = descriptor.set;

    descriptor.set = function(val: string) {
        if (val.length < 3) {
            throw new Error('Length must be minimum 3 characters');
        }

        originalSetter?.call(this, val);
    }

    return descriptor; // not neccesarry
}

// function DepricatedMethod(target: any, methodName: string, descriptor: PropertyDescriptor) {
//     const originalMethod = descriptor.value;

//     descriptor.value = function(...args: any[]) {
//         console.log(`Caution! Method ${methodName} is depricated`);
//         return originalMethod.apply(this, args);
//     }

//     return descriptor;
// }


// with factory
function DepricatedMethod(message: string) {
    return function(target: any, methodName: string, descriptor: PropertyDescriptor) {
        const originalMethod = descriptor.value;

        descriptor.value = function(...args: any[]) {
            console.log(`Caution! ${message}`);
            return originalMethod.apply(this, args);
        }

        return descriptor;
    }
    
}

@FreezeClass
class User2 {
    name: string;
    age: number;
    private _email!: string;

    constructor (name: string, age: number, email: string) {
        this.name = name;
        this.age = age;
        this.email = email;
    }

    @ValidateStringAccessor
    get email() {
        return this._email;
    }

    set email(newEmail: string) {
        this._email = newEmail;
    }

    // @DepricatedMethod
    @DepricatedMethod('Method is depricated') // factory parameters
    getInfo(condensed: boolean): string {
        return condensed 
        ? `Person ${this.name}` 
        : `Person ${this.name} is ${this.age} years old awith email ${this.email}`;
    }
}

console.log(Object.isFrozen(User2));
console.log(Object.isFrozen(User2.prototype));

const newUser1 = new User2('pen4o', 12, 'pen4o@abv.bg');
const newUser2 = new User2('min4o', 34, 'min4o@abv.bg');

// newUser1.email = 'a' validation error

console.log(newUser1.getInfo(true));