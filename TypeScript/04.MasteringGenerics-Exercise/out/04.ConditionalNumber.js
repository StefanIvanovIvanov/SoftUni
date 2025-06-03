"use strict";
function conditionalNumber(input) {
    if (typeof input == 'number') {
        console.log(input.toFixed(2));
    }
    else {
        console.log(input);
    }
}
conditionalNumber(20.3555);
conditionalNumber('wow');
conditionalNumber('a string');
// conditionalNumber<boolean>(30); TS error
// conditionalNumber<number>('test');  TS error
//# sourceMappingURL=04.ConditionalNumber.js.map