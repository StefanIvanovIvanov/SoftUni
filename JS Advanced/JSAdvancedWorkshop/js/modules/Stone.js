import GameObject from './GameObject.js';

//Stones definition
//This class represents stones which the snake must avoid
export default class Stone extends GameObject {
    constructor(x, y) {
        super(x, y, false, document.getElementById('stone'));
        this.color = 'grey';
    }

    //Stones don't need update, but each object must have update method
    update() {
    
    }
}

