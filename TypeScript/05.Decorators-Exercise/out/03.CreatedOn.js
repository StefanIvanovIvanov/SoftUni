var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
function addCreatedAt(constructor) {
    return class extends constructor {
        createdOn = new Date();
    };
}
let User = class User {
    name;
    age;
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }
    displayUserInfo() {
        console.log(`${this.name}, Age: ${this.age}`);
    }
};
User = __decorate([
    addCreatedAt,
    __metadata("design:paramtypes", [String, Number])
], User);
const user1 = new User("John Doe", 30);
user1.displayUserInfo();
console.log(user1);
console.log(user1.createdOn);
export {};
//# sourceMappingURL=03.CreatedOn.js.map