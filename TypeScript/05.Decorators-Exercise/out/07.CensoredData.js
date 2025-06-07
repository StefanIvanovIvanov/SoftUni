var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
function addCreatedOn(constructor) {
    return class extends constructor {
        createdOn = new Date();
    };
}
function getLatest(seconds) {
    return function (target, methodName, descriptor) {
        const originalMethod = descriptor.value;
        descriptor.value = function () {
            const allItems = originalMethod.call(this);
            const currentTime = new Date();
            const recentItems = allItems.filter((item) => currentTime.getTime() - item.createdOn.getTime() <= (seconds * 1000));
            return recentItems;
        };
        return descriptor;
    };
}
function censorProps(censorService) {
    return function (target, methodName, descriptor) {
        const originalMethod = descriptor.value;
        descriptor.value = function () {
            const allItems = originalMethod.call(this);
            const censoredItems = censorService.censorProperties(allItems);
            return censoredItems;
        };
    };
}
function log(target, methodName, descriptor) {
    const originalMethod = descriptor.value;
    descriptor.value = function () {
        console.log(`Method ${methodName} called successfully`);
        return originalMethod.call(this);
    };
    return descriptor;
}
class MockCensorService {
    censoredProperties;
    constructor(censoredProperties) {
        this.censoredProperties = censoredProperties;
    }
    censorProperties(items) {
        let censoredItems = items.slice();
        censoredItems.forEach(i => {
            this.censoredProperties.forEach(prop => { delete i[prop]; });
        });
        return censoredItems;
    }
}
let userCensorService = new MockCensorService(['creditCardNumber']);
let employeeCensorService = new MockCensorService(['birthday', 'salary']);
// let userCensorService = new MockCensorService<User>(['age'])
// let employeeCensorService = new MockCensorService<Employee>(['salary'])
let User = class User {
    name;
    age;
    creditCardNumber;
    constructor(name, age, creditCardNumber) {
        this.name = name;
        this.age = age;
        this.creditCardNumber = creditCardNumber;
    }
    getInfo() { return `${this.name}, Age: ${this.age} CreditCardNumber: ${this.creditCardNumber}`; }
};
User = __decorate([
    addCreatedOn,
    __metadata("design:paramtypes", [String, Number, String])
], User);
let Employee = class Employee {
    name;
    birthday;
    salary;
    constructor(name, birthday, salary) {
        this.name = name;
        this.birthday = birthday;
        this.salary = salary;
    }
    getInfo() { return `${this.name}, Birthday: ${this.birthday?.toLocaleDateString()} Salary: ${this.salary}`; }
};
Employee = __decorate([
    addCreatedOn,
    __metadata("design:paramtypes", [String, Date, Number])
], Employee);
class UsersService {
    _users;
    _employees;
    constructor(users, employees) {
        this._users = users;
        this._employees = employees;
    }
    addUser(user) { this._users.push(user); }
    addEmployee(employee) { this._employees.push(employee); }
    getUsers() { return this._users; }
    getEmployees() { return this._employees; }
}
__decorate([
    getLatest(5),
    censorProps(userCensorService),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", []),
    __metadata("design:returntype", void 0)
], UsersService.prototype, "getUsers", null);
__decorate([
    log,
    getLatest(10),
    censorProps(employeeCensorService),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", []),
    __metadata("design:returntype", void 0)
], UsersService.prototype, "getEmployees", null);
const user1 = new User('John Does', 30, 'ABCD-1234');
const user2 = new User('Benny Tres', 23, 'EFGH-5678');
const emp1 = new Employee('Sarah Connor', new Date(1964, 4, 15), 2500);
const emp2 = new Employee('Arnold Schwarzenegger', new Date(1947, 6, 30), 3500);
let usersService = new UsersService([user1, user2], [emp1, emp2]);
let users = usersService.getUsers();
console.log(users.map(x => x.getInfo()));
let employees = usersService.getEmployees();
console.log(employees.map(x => x.getInfo()));
//7 seconds later
setTimeout(() => {
    const user3 = new User('Jimmy Quatro', 27, 'IJKL-9012');
    const emp3 = new Employee('Kyle Reese', new Date(2004, 0, 1), 2000);
    usersService.addUser(user3);
    usersService.addEmployee(emp3);
    let users = usersService.getUsers();
    console.log(users.map(x => x.getInfo()));
    let employees = usersService.getEmployees();
    console.log(employees.map(x => x.getInfo()));
}, 7000);
//15 seconds later
setTimeout(() => {
    let users = usersService.getUsers();
    console.log(users.map(x => x.getInfo()));
    let employees = usersService.getEmployees();
    console.log(employees.map(x => x.getInfo()));
}, 15000);
export {};
// const user1 = new User('John Does', 30, 'ABCD-1234');
// const user2 = new User('Benny Tres', 23, 'EFGH-5678');
// const emp1 = new Employee('Sarah Connor', new Date(1964, 4, 15), 2500);
// const emp2 = new Employee('Arnold Schwarzenegger', new Date(1947, 6, 30), 3500);
// let usersService = new UsersService([user1, user2], [emp1, emp2]);
// let users = usersService.getUsers();
// console.log(users.map(x => x.getInfo()));
// let employees = usersService.getEmployees();
// console.log(employees.map(x => x.getInfo()));
// //7 seconds later
// setTimeout(() => {
//     const user3 = new User('Jimmy Quatro', 27, 'IJKL-9012');
//     const emp3 = new Employee('Kyle Reese', new Date(2004, 0, 1), 2000);
//     usersService.addUser(user3);
//     usersService.addEmployee(emp3);
//     let users = usersService.getUsers();
//     console.log(users.map(x => x.getInfo()));
//     let employees = usersService.getEmployees();
//     console.log(employees.map(x => x.getInfo()));
// }, 7000)
// //15 seconds later
// setTimeout(() => {
//     let users = usersService.getUsers();
//     console.log(users.map(x => x.getInfo()));
//     let employees = usersService.getEmployees();
//     console.log(employees.map(x => x.getInfo()));
// }, 15000)
//# sourceMappingURL=07.CensoredData.js.map