function distinctArray(input) {
    for (let i = 0; i < input.length - 1; i++) {
        for (let j = i + 1; j < input.length; j++) {
            if (input[i] === input[j]) {
               input.splice(j, 1);
               i = 0;
               j = 0;
            }
        }
    }
        console.log(input.join(" "));
}

distinctArray([20, 8, 12, 13, 4, 4, 8, 5]);