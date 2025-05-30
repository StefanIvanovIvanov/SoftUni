"use strict";
class Employee {
    name;
    position;
    salary;
    constructor(name, position, salary) {
        this.name = name;
        this.position = position;
        this.salary = salary;
    }
    getDetails() {
        return `Name: ${this.name}, Position: ${this.position}`;
    }
    showSalary() {
        return `Salary: $${this.salary}`;
    }
}
const emp = new Employee("Alice", "Manager", 5000);
console.log(emp.getDetails());
console.log(emp.showSalary());
console.log(emp.name);
//console.log(emp.salary) Error: Property 'salary' is private
//console.log(emp.position) Error: Property 'position' is protected
//# sourceMappingURL=06.AccessModifiers.js.map