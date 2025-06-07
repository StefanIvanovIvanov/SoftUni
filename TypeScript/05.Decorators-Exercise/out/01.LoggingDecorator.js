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
function log(target, methodName, descriptor) {
    const originalMethod = descriptor.value;
    descriptor.value = function (...args) {
        console.log(`Function '${methodName}' called with arguments: ${args.join(', ')}`);
        return originalMethod(args);
    };
    return descriptor;
}
class Person {
    fName;
    lName;
    constructor(firstName, lastName) {
        this.fName = firstName;
        this.lName = lastName;
    }
    static getFullName(firstName, lastName) {
        return `${firstName} ${lastName}`;
    }
}
__decorate([
    log,
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [String, String]),
    __metadata("design:returntype", String)
], Person, "getFullName", null);
let person = new Person('John', 'Does');
Person.getFullName(person.fName, person.lName);
Person.getFullName('Benny', 'Tres');
//# sourceMappingURL=01.LoggingDecorator.js.map