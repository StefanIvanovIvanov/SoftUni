function Square (x, y, color, id){
    this.pos = createVector(x, y);
    this.w = 80;
    this.mainValue = '';
    this.secondaryValue = '';
    this.col = color;
    this.id = id;
}

Square.prototype.show = function(){
    fill(this.col.x, this.col.y, this.col.z);
    stroke(255);
    strokeWeight(3);
    rect(this.pos.x, this.pos.y, this.w, this.w, 10);
    if(this.mainValue && this.secondaryValue){
    fill(255);
    textSize(30);
    text(this.mainValue,this.pos.x+20,this.pos.y+50);
    fill(255);
    textSize(18);
    text(this.secondaryValue, this.pos.x+50,this.pos.y+55)
    } else {
        fill (255);
       textSize(30);
        text(this.mainValue,this.pos.x+30,this.pos.y+50)
    }
}