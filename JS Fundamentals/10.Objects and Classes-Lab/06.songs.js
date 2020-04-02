function songs(inputArr) {
    let numOfSongs = Number(inputArr.shift());

    for (let i = 0; i < inputArr.length - 1; i++) {
        let splitted = inputArr[i].split("_");
        let typeList = splitted[0];
        let name = splitted[1];
        let time = splitted[2];
        let lastElement = inputArr[inputArr.length - 1];
        if (typeList === lastElement) {
            console.log(`${name}`);
        } 
        else if (lastElement === "all") {
            console.log(`${name}`)
        }
    }
}
songs([2,'like_Replay_3:15','ban_Photoshop_3:48','all']);