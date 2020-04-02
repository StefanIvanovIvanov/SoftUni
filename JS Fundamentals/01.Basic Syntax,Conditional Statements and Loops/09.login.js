function login(inputArr) {
    let username = inputArr.shift();
    let reversed = ""
    let counter = 0;

    for (let i = username.length - 1; i >= 0; i--) {
        reversed += username[i]
    }

    for (let i = 0; i < inputArr.length; i++) {
        if (inputArr[i] === reversed) {
            console.log(`User ${username} logged in.`);
            break;
        } else {
            counter++;
            if (counter === 4) {
                console.log(`User ${username} blocked!`);
                break;
            }
            console.log(`Incorrect password. Try again.`);
        }
    }
}

login(['sunny','rainy','cloudy','sunny','not sunny']);