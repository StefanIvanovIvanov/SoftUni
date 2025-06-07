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
function authorizeUser(authService) {
    return function (target, propertyName, descriptor) {
        const originalGetter = descriptor.get;
        descriptor.get = function () {
            const hasAccess = authService.canViewData(propertyName);
            if (!hasAccess) {
                throw new Error(`You are not authorized to view this information`);
            }
            return originalGetter?.call(this);
        };
        return descriptor;
    };
}
class MockAuthorizationService {
    userRole;
    constructor(userRole) {
        this.userRole = userRole;
    }
    canViewData(property) {
        switch (this.userRole) {
            case 'Admin': return true;
            case 'PersonalDataAdministrator': return ['name', 'age'].includes(property);
            default: return false;
        }
    }
}
// switch service in getters
let mockAuthorizationService = new MockAuthorizationService('Admin');
let mockAuthorizationService2 = new MockAuthorizationService('PersonalDataAdministrator');
let mockAuthorizationService3 = new MockAuthorizationService('Guest');
class User {
    _name;
    _age;
    _creditCardNumber;
    constructor(name, age, creditCardNumber) {
        this._name = name;
        this._age = age;
        this._creditCardNumber = creditCardNumber;
    }
    get name() {
        return this._name;
    }
    get age() {
        return this._age;
    }
    get creditCardNumber() {
        return this._creditCardNumber;
    }
}
__decorate([
    authorizeUser(mockAuthorizationService),
    __metadata("design:type", Object),
    __metadata("design:paramtypes", [])
], User.prototype, "name", null);
__decorate([
    authorizeUser(mockAuthorizationService),
    __metadata("design:type", Object),
    __metadata("design:paramtypes", [])
], User.prototype, "age", null);
__decorate([
    authorizeUser(mockAuthorizationService),
    __metadata("design:type", Object),
    __metadata("design:paramtypes", [])
], User.prototype, "creditCardNumber", null);
const user1 = new User("John Doe", 30, 'ABCD-1234');
console.log(user1.name);
console.log(user1.age);
console.log(user1.creditCardNumber);
const user2 = new User("John Doe", 30, 'ABCD-1234');
console.log(user2.name);
console.log(user2.age);
console.log(user2.creditCardNumber);
const user3 = new User("John Doe", 30, 'ABCD-1234');
console.log(user3.name);
console.log(user3.age);
console.log(user3.creditCardNumber);
//# sourceMappingURL=04.Authorization.js.map