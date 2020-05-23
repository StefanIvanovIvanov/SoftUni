import GameObject from './GameObject.js';
import SnakeBody from './SnakeBody.js';
import * as Helper from './helper.js';
import * as Engine from './gameEngine.js';

//This class represents the snake itself
export default class Snake extends GameObject {
    constructor(x, y, length, direction) {
        super(x, y, false, document.getElementById('snake'));
        // Here we can specify number of lives the snake has
        this.lives = 5;
        
        // Snake has the ability to grow, so this field is not constant
        this.length = length;

        // the snake is green
        this.color = 'green';

        //Here we are logging positions which were visited by snake's head 
        // in order to know the way of the rest body parts
        this.positionStack = [];
        
        //This array holds snake's body parts - everything but the head
        this.bodyArray = [];
        
        //This field must be updated only using enumeration Directions. 
        // It keeps the direction in which the snake is moving.
        this.direction = direction;
        
        //This field holds number of eaten food in order to know when to grow. 
        // It is reset each time the snake grows.
        this.foodEaten = 0;
        
        //This field is holding the total number of eaten food aka the score.
        this.totalFood = 0;
    }

    //This method is called on update instead of GameObject default method
    update() {
        var i;
        //Creates new position from the current snake's head position to store in the position stack
        var position = {
            X: this.position.X,
            Y: this.position.Y
        };

        //adds position to the stack
        this.positionStack.unshift(position);

        //removes unneeded position from the stack's end
        this.positionStack.pop();

        //calculates new position depending on the current direction
        switch (this.direction) {
            case Helper.Directions.DOWN:
                this.position.Y += this.size.HEIGHT;
                break;
            case Helper.Directions.LEFT:
                this.position.X -= this.size.WIDTH;
                break;
            case Helper.Directions.RIGHT:
                this.position.X += this.size.WIDTH;
                break;
            case Helper.Directions.UP:
                this.position.Y -= this.size.HEIGHT;
                break;
        
            default:
                throw new Error('Please, use Directions enumeration');
                break;
        }
        
        //updates all body parts' positions
        for(i=0; i<this.length; i++){
            this.bodyArray[i].position = this.positionStack[i];
        }
    
        //checks if the snake has eaten enough food and if so makes it grow
        if (this.foodEaten == 3) {
            this.foodEaten = 0;
            this.grow();
        }
    }

    //This method can be used with any user interface to change the snake's direction 
    //(may be it could be made public so the snake could be controlled from outside the engine)
    changeDirection(direction) {
        this.direction = direction;
    }

    //This method describes how the snake manages collisions 
    onCollision(collisionObject) {
        // if the collision object is food it increases its foodEaten and totalFood fields
        if (collisionObject.canBeEaten) {
            this.foodEaten++;
            this.totalFood++;
        } else {
            if (this.lives === 0) {
                Engine.endGame();
            } else {
                this.lives--;
                this.reset();
            }
        }
        // if the collision object is not food, 
        // it checks number of lives and if it is equal to 0 - dies, 
        //if not - decreases number of lives and resets it self
    }

    // This method makes the snake grow
    // It is creating new body element on the top of the last element 
    // (it is done to avoid difficult calculations)
    // on the next update they will have different positions and the snake will be longer
    grow() {
        // Create new position
        var position = {
            X: this.bodyArray[this.length - 1].position.X,
            Y: this.bodyArray[this.length - 1].position.Y,
        };

        // Create new body part
        var bodyPart = new SnakeBody(position.X, position.Y);

        // Push body part to bodyArray and position to position stack
        this.bodyArray.push(bodyPart);
        this.positionStack.push(position);

        // increase length
        this.length++;
    }

    //This method is called when the snake dies, but have more lives. 
    //It wipes the snake and positions it in the left part of the field and sets direction to right
    reset() {
        // Set direction
        this.direction = Helper.Directions.RIGHT;
        
        // Set snake head position (x is calculated, y is random)
        var x = (this.length + 2) * this.size.WIDTH;
        var y = Helper.getRandomPositionY(0, Helper.FieldSize.HEIGHT - this.size.HEIGHT);
        this.position.X = x;
        this.position.Y = y;

        // Set all body parts positions according to head
        for(var i=0; i<this.length; i++){
            this.bodyArray[i].position.Y = y;
            this.bodyArray[i].position.X = x - ((i + 1) * this.size.WIDTH);
            this.positionStack[i] = this.bodyArray[i].position;
        }
        // Update position stack
    }

    //This method draws the snake, including all it's body parts and some statistics
    draw(ctx) {
        // Draw the head
        // ctx.fillStyle = this.color;
        // ctx.moveTo(this.position.X, this.position.Y);
        // if (this.icon) {
        //     ctx.drawImage(this.icon, this.position.X, this.position.Y);
        // } else {
        //     ctx.fillRect(this.position.X, this.position.Y, this.size.WIDTH, this.size.HEIGHT);
        // }

        super.draw(ctx);

        // Draw all body parts
        for(var i=0; i<this.length; i++){
            this.bodyArray[i].draw(ctx);
        }

        // Output number of lives and score
        document.getElementById('lives').innerHTML = this.lives;
        document.getElementById('points').innerHTML = this.totalFood;
    }
    
    //This method returns true if the snake collides with itself
    hasBittenHerSelf() {
        var result = false;

        for(var i=0; i<this.length; i++){
            if (this.position.X === this.bodyArray[i].position.X &&
                this.position.Y === this.bodyArray[i].position.Y) {
                result = true;
                break;
            }
        }

        return result;
    }

    //This method returns true if the snake leaves the game field
    isOutOfGameField() {
        return this.position.X < 0 || 
            this.position.X > Helper.FieldSize.WIDTH ||
            this.position.Y < 0 ||
            this.position.Y > Helper.FieldSize.HEIGHT;

    }
}