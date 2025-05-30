class Counter {
    private static count: number = 0;

    static increment() {
        Counter.count++;
    }

    static getCount(): number {
        return Counter.count;
    }
}

Counter.increment();
Counter.increment();
console.log(Counter.getCount());

// Counter.count; can't be accessed.