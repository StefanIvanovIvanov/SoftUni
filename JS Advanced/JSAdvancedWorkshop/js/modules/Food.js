import GameObject from './GameObject.js';
import * as Helper from './helper.js';

//Food definition
//This class represents Food objects in the game. It inherits GameObject
export default class Food extends GameObject {
    constructor(x,y) {
        super(x, y, true, document.getElementById('apple'));
        this.color = 'red';
    }

    //Specific update method for all instances of Food class. If destroyed, 
    // food disappears and appears on different spot
    update() {
        if (this.isDestroyed) {
            this.position.X = Helper.getRandomPositionX(0, Helper.FieldSize.WIDTH - this.size.WIDTH);
            this.position.Y = Helper.getRandomPositionY(0, Helper.FieldSize.HEIGHT - this.size.HEIGHT);

            this.isDestroyed = false;
        }
    }
}