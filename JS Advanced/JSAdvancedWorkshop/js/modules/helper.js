// Enumerations to be used in the game. 
// The snake is controlled by changeDirection method and a direction as a parameter.  
const Directions = Object.freeze({
    UP: "up",
    DOWN: "down",
    LEFT: "left",
    RIGHT: "right"
}),

//This enumeration holds single object size. The snake is made of several objects.
ObjectSize = Object.freeze({
    WIDTH: 20,
    HEIGHT: 20
}),

// This enumeration gives us the dimensions of the game field
FieldSize = Object.freeze({
    WIDTH: 960,
    HEIGHT: 500
}),

// This is the interval to update game field
GameSpeed = 100;

// This functions return random position on the field, normalized to the grid. 
//Grid size is equal to object size.
function getRandomPositionX(start, end) {
    return Math.floor((Math.random() * (end - start + 1) + start) / ObjectSize.WIDTH) * ObjectSize.WIDTH;
}

function getRandomPositionY(start, end) {
    return Math.floor((Math.random() * (end - start + 1) + start) / ObjectSize.HEIGHT) * ObjectSize.HEIGHT;
}

export { 
    getRandomPositionX, 
    getRandomPositionY, 
    Directions, 
    ObjectSize,
    FieldSize, 
    GameSpeed
};