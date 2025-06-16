export function decorator1() {}

export function decorator2(target: any, propertyName: string, descriptor: PropertyDescriptor) {
    const originalGet = descriptor.get;
    descriptor.get = function() {
        const originalPrice = originalGet?.call(this);
        return originalPrice * 1.2;
    };

    return descriptor;
}

export function decorator3(target: any, propertyName: string, descriptor: PropertyDescriptor) {
    const originalGet = descriptor.get;
    descriptor.get = function() {
        const originalPrice = originalGet?.call(this);
        return originalPrice * 1.2;
    };

    return descriptor;
}

export function decorator4() {}

export function decorator5<T extends new (...args: any[]) => {}>(constructor: T)  {
    return class extends constructor {
        public static readonly MotelName = 'Monthly Motel';
    };
}