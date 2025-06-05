function LogClass(constructor: Function) {
    console.log(constructor); // logs User class or Employee class
    console.log('LogClass')
    console.log('---------------------')
    console.log(`Class ${constructor.name} created!`)
    console.log('---------------------')
}

function LogAccessor(target: any, accessorName: string, descriptor: PropertyDescriptor){
    console.log('LogAccessor')
    console.log('---------------------')
    console.log(accessorName);
    console.log('---------------------')

    console.log(target);
    console.log('---------------------')

    console.log(descriptor);
    console.log('---------------------')

    console.log(descriptor.get);
    console.log('---------------------')

    console.log(descriptor.set);
    console.log('---------------------')

    console.log(`Accessors for property ${accessorName} created`);
}

function LogMethod(target: any, methodName: string, descriptor: PropertyDescriptor) {
    console.log('LogMethod')
    console.log('---------------------')
    console.log(descriptor);
    console.log('---------------------')

    console.log(descriptor.value); // the function
    console.log('---------------------')

    console.log(`Method ${methodName} created!`);
    console.log('---------------------')
}

function LogProperty(target: any, propertyName: string) {
    console.log('LogProperty')
    console.log('---------------------')
    console.log(propertyName);
    console.log('---------------------')

    console.log(propertyName.length);
    console.log('---------------------')

    console.log(`Property ${propertyName} created!`);
    console.log('---------------------')
}

function LogParameter(target: any, methodName: string, parameterIndex: number) {
    console.log('LogParameter')
    console.log('---------------------')

    console.log(methodName); // gets method name, not parameter
    console.log('---------------------')
    
    console.log(parameterIndex);
    console.log('---------------------')
    
    console.log(`Parameter ${parameterIndex} for method ${methodName} created!`);
    console.log('---------------------')
}

@LogClass
class User {
    @LogProperty
    name: string;
    @LogProperty
    age: number;
    private _email!: string;

    constructor (name: string, age: number, email: string) {
        this.name = name;
        this.age = age;
        this.email = email;
    }

    @LogAccessor
    get email() {
        return this._email;
    }

    set email(newEmail: string) {
        this._email = newEmail;
    }

    @LogMethod
    getInfo(@LogParameter condensed: boolean, @LogParameter test: string): string {
        return condensed 
        ? `Person ${this.name}` 
        : `Person ${this.name} is ${this.age} years old awith email ${this.email}`;
    }
}

@LogClass
class Employee {
    name: string = 'Pen4o';
    salary: number = 1000
}

const user1 = new User('pen4o', 12, 'pen4o@abv.bg');
const user2 = new User('min4o', 34, 'min4o@abv.bg');