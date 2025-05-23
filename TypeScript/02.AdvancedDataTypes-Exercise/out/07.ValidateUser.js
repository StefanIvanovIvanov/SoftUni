"use strict";
function isValidUser(user) {
    return user != undefined && typeof user === 'object' &&
        'id' in user &&
        ((typeof user.id === 'number' && user.id > 100) ||
            (typeof user.id === 'string' && user.id.length === 14)) &&
        'username' in user &&
        (typeof user.username === 'string' && user.username.length >= 5 && user.username.length <= 10) &&
        'passwordHash' in user &&
        ((typeof user.passwordHash === 'string' && user.passwordHash.length === 20) ||
            (Array.isArray(user.passwordHash) && user.passwordHash.length === 4) && user.passwordHash.every(x => typeof x === 'string' && x.length === 8)) &&
        'status' in user &&
        typeof user.status === 'string' && ['Locked', 'Unlocked'].includes(user.status);
}
console.log(isValidUser({ id: 120, username: 'testing', passwordHash: '123456-123456-123456', status: 'Deleted', email: 'something' }));
console.log(isValidUser({ id: '1234-abcd-5678', username: 'testing', passwordHash: '123456-123456-123456', status: 'Unlocked' }));
console.log(isValidUser({ id: '20', username: 'testing', passwordHash: '123456-123456-123456', status: 'Deleted', email: 'something' }));
console.log(isValidUser({ id: 255, username: 'Pesho', passwordHash: ['asdf1245', 'qrqweggw', '123-4567', '98765432'], status: 'Locked', email: 'something' }));
console.log(isValidUser({ id: 'qwwe-azfg-ey38', username: 'Someone', passwordHash: ['qwezz8jg', 'asdg-444', '12-34-56'], status: 'Unlocked' }));
console.log(isValidUser({ id: 1344, username: 'wow123', passwordHash: '123456-123456-1234567', status: 'Locked', email: 'something@abv.bg' }));
//# sourceMappingURL=07.ValidateUser.js.map