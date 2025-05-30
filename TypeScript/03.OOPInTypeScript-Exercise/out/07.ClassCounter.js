"use strict";
class Counter {
    static count = 0;
    static increment() {
        Counter.count++;
    }
    static getCount() {
        return Counter.count;
    }
}
Counter.increment();
Counter.increment();
console.log(Counter.getCount());
// Counter.count; can't be accessed.
//# sourceMappingURL=07.ClassCounter.js.map