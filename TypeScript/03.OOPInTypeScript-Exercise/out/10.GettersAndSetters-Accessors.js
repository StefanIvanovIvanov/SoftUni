"use strict";
class User {
    _username;
    constructor(userName) {
        this.username = userName;
    }
    get username() {
        return this._username;
    }
    set username(newUsername) {
        if (newUsername.length >= 3) {
            this._username = newUsername;
        }
        else {
            throw Error('Username must be atleast 3 characters');
        }
    }
}
const user1 = new User("Martin");
user1.username = "johnDoe";
console.log(user1.username);
// const user2 = new User("jo"); error
// const user3 = new User("Martin");
// user3.username = "Do"; // error
//# sourceMappingURL=10.GettersAndSetters-Accessors.js.map