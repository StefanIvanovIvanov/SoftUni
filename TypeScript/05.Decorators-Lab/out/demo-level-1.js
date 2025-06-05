"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
function LogClass(constructor) {
    console.log(constructor); // logs User class or Employee class
    console.log('LogClass');
    console.log('---------------------');
    console.log(`Class ${constructor.name} created!`);
    console.log('---------------------');
}
function LogAccessor(target, accessorName, descriptor) {
    console.log('LogAccessor');
    console.log('---------------------');
    console.log(accessorName);
    console.log('---------------------');
    console.log(target);
    console.log('---------------------');
    console.log(descriptor);
    console.log('---------------------');
    console.log(descriptor.get);
    console.log('---------------------');
    console.log(descriptor.set);
    console.log('---------------------');
    console.log(`Accessors for property ${accessorName} created`);
}
function LogMethod(target, methodName, descriptor) {
    console.log('LogMethod');
    console.log('---------------------');
    console.log(descriptor);
    console.log('---------------------');
    console.log(descriptor.value); // the function
    console.log('---------------------');
    console.log(`Method ${methodName} created!`);
    console.log('---------------------');
}
function LogProperty(target, propertyName) {
    console.log('LogProperty');
    console.log('---------------------');
    console.log(propertyName);
    console.log('---------------------');
    console.log(propertyName.length);
    console.log('---------------------');
    console.log(`Property ${propertyName} created!`);
    console.log('---------------------');
}
function LogParameter(target, methodName, parameterIndex) {
    console.log('LogParameter');
    console.log('---------------------');
    console.log(methodName); // gets method name, not parameter
    console.log('---------------------');
    console.log(parameterIndex);
    console.log('---------------------');
    console.log(`Parameter ${parameterIndex} for method ${methodName} created!`);
    console.log('---------------------');
}
let User = class User {
    name;
    age;
    _email;
    constructor(name, age, email) {
        this.name = name;
        this.age = age;
        this.email = email;
    }
    get email() {
        return this._email;
    }
    set email(newEmail) {
        this._email = newEmail;
    }
    getInfo(condensed, test) {
        return condensed
            ? `Person ${this.name}`
            : `Person ${this.name} is ${this.age} years old awith email ${this.email}`;
    }
};
__decorate([
    LogProperty,
    __metadata("design:type", String)
], User.prototype, "name", void 0);
__decorate([
    LogProperty,
    __metadata("design:type", Number)
], User.prototype, "age", void 0);
__decorate([
    LogAccessor,
    __metadata("design:type", String),
    __metadata("design:paramtypes", [String])
], User.prototype, "email", null);
__decorate([
    LogMethod,
    __param(0, LogParameter),
    __param(1, LogParameter),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [Boolean, String]),
    __metadata("design:returntype", String)
], User.prototype, "getInfo", null);
User = __decorate([
    LogClass,
    __metadata("design:paramtypes", [String, Number, String])
], User);
let Employee = class Employee {
    name = 'Pen4o';
    salary = 1000;
};
Employee = __decorate([
    LogClass
], Employee);
const user1 = new User('pen4o', 12, 'pen4o@abv.bg');
const user2 = new User('min4o', 34, 'min4o@abv.bg');
//# sourceMappingURL=demo-level-1.js.map