import * as Helper from './helper.js'; 

//Game Field definition
// This class represents canvas element on which the game objects are drawn
export default class GameField {
    // constructor receives canvas, has size and context
    constructor(canvas) {
        canvas.height = Helper.FieldSize.HEIGHT;
        canvas.width = Helper.FieldSize.WIDTH;

        this.ctx = canvas.getContext('2d');
    }    

    // receives game objects, clears canvas and draws them
    draw(gameObjects) {
        this.ctx.clearRect(0, 0, Helper.FieldSize.WIDTH, Helper.FieldSize.HEIGHT);
        for(var i=0; i<gameObjects.length; i++){
            gameObjects[i].draw(this.ctx);
        }
    }
}
