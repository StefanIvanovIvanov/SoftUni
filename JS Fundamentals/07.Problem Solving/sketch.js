let field = [];

function setup() {
    createCanvas(600, 600);
    background(255, 201,147);
    createGame();
    fillSquares();
}

function draw() {
    checkIfWon();
   for(let square of field){
       square.show();
   }
}

function createGame(){
    let id = 1;
    let xOff = 100;
    let yOff= 100;
    for (let i = 0; i<4;i++){
        for(let j = 0; j<4;j++){
            let col = null;
            if(i>=1 && i<=2 && j>=1 && j<=2){
                col = createVector(213, 113, 96)
            } else {
                col = createVector(115,138,239)
            }

            let square = new Square(xOff, yOff, col, id);
            id++;
            field.push(square);
            xOff += 100;
        }

        yOff+=100;
        xOff=100;
    } 
}

function fillSquares(){
    for (let square of field){
        switch(square.id){
            case 1:
                square.mainValue=1;
                square.secondaryValue=2;
                break;
            case 2:
                square.mainValue=1;
                square.secondaryValue=4;
                 break;
            case 3:
                square.mainValue=2;
                square.secondaryValue=3;
                break;
            case 4:
                square.mainValue=3;
                square.secondaryValue=4;
                break;
            case 5:
                square.mainValue=2;
                square.secondaryValue=3;
                break;
            case 6:
                square.mainValue=4;
                break;
            case 7:
                square.mainValue=2;
                break;
            case 8:
                square.mainValue=1;
                square.secondaryValue=4;
                break;
            case 9:
                square.mainValue=2;
                square.secondaryValue=1;
                break;
            case 10:
                square.mainValue=2;
                break;
            case 11:
                square.mainValue=4;
                break;
            case 12:
                square.mainValue=1;
                square.secondaryValue=3;
                break;
            case 13:
                square.mainValue=4;
                square.secondaryValue=3;
                break;
            case 14:
                square.mainValue=4;
                square.secondaryValue=3;
                break;
            case 15:
                square.mainValue=2;
                square.secondaryValue=1;
                break;
            case 16:
                square.mainValue=1;
                square.secondaryValue=2;
                break;        
            default:
                square.mainValue=0;
                square.secondaryValue=0;
                break;        
        }
    }
}

function mouseClicked(){
    for (let square of field) {
        if(mouseX >= square.pos.x && mouseX <= square.pos.x + square.w 
            && mouseY >= square.pos.y && mouseY <= square.pos.y + square.w) {
                if(square.mainValue && square.secondaryValue){
                    let temp = square.mainValue;
                    square.mainValue = square.secondaryValue;
                    square.secondaryValue=temp;
                }
            }
    }
}

function checkIfWon(){
    let rightQuesses =0;
    for (let square of field){       
        if(square.id===1){
            if(square.mainValue===2) {
                rightQuesses++;
            }
        } else if (square.id === 2) {
            if (square.mainValue === 1) {
                rightQuesses++;
            }
        } else if (square.id === 3) {
            if (square.mainValue === 3) {
                rightQuesses++;
            }
        } else if (square.id === 4) {
            if (square.mainValue === 4) {
                rightQuesses++;
            }
        } else if (square.id === 5) {
            if (square.mainValue === 3) {
                rightQuesses++;
            }
        } else if (square.id === 8) {
            if (square.mainValue === 1) {
                rightQuesses++;
            }
        } else if (square.id === 9) {
            if (square.mainValue === 1) {
                rightQuesses++;
            }
        } else if (square.id === 12) {
            if (square.mainValue === 3) {
                rightQuesses++;
            }
        } else if (square.id === 13) {
            if (square.mainValue === 4) {
                rightQuesses++;
            }
        } else if (square.id === 14) {
            if (square.mainValue === 3) {
                rightQuesses++;
            }
        } else if (square.id === 15) {
            if (square.mainValue === 1) {
                rightQuesses++;
            }
        } else if (square.id === 16) {
            if (square.mainValue === 2) {
                rightQuesses++;
            }
        }
    }

    if (rightQuesses===12){
        fillSquares(255);
        textSize(50);
        text('You won!', 200, 50);
        noLoop();
    }
}