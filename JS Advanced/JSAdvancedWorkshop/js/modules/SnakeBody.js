import GameObject from './GameObject.js';

//Snake body definition
//This class represents snake's body parts.
export default class SnakeBody extends GameObject {
    constructor(x, y) {
        super(x, y, false);
        this.color = 'lightgreen';
    }

    //SnakeBody don't need update, but each object must have update method
    update() {
    
    }
}
