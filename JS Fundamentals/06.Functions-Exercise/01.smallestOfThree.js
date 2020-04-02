function smallestOfThree(numOne, numTwo, numThree) {
    if (numOne <= numTwo && numOne <= numThree) {
        console.log(numOne);
    } 
    else if (numTwo <= numOne && numTwo <= numThree) {
        console.log(numTwo);
    } else {
        console.log(numThree);
    }
}

smallestOfThree(2, 5, 3);