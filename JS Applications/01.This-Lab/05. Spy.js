function Spy(target, method) {
    let orgFunc = target[method];

    let result = {
        count: 0
    };

    target[method] = function () {
        result.count++;
        return orgFunc.apply(this, arguments);
    };

    return result;
}

let spy = Spy(console, "log");

console.log(spy);
console.log(spy);
console.log(spy); 

let obj = {
    method: () => "invoked"
};

let spy2 = Spy(obj, "method");

obj.method();
obj.method();
obj.method();
obj.method();
obj.method();
obj.method();

console.log(spy2);