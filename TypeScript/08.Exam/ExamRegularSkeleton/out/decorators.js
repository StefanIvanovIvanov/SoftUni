"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.decorator1 = decorator1;
exports.decorator2 = decorator2;
exports.decorator3 = decorator3;
exports.decorator4 = decorator4;
exports.decorator5 = decorator5;
function decorator1() { }
function decorator2(target, propertyName, descriptor) {
    const originalGet = descriptor.get;
    descriptor.get = function () {
        const originalPrice = originalGet?.call(this);
        return originalPrice * 1.2;
    };
    return descriptor;
}
function decorator3(target, propertyName, descriptor) {
    const originalGet = descriptor.get;
    descriptor.get = function () {
        const originalPrice = originalGet?.call(this);
        return originalPrice * 1.2;
    };
    return descriptor;
}
function decorator4() { }
function decorator5(constructor) {
    return class extends constructor {
        static MotelName = 'Monthly Motel';
    };
}
//# sourceMappingURL=decorators.js.map