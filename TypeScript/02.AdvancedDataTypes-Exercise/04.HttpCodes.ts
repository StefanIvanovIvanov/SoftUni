type HttpCode = {
    code : 200 | 201 | 301 | 400 | 404| 500,
    text : string,
    printChars? : number,
}

function httpCodes(code : HttpCode) : void {
    if (code.printChars){
        let charsToPrint = code.text.substring(0, code.printChars)
        console.log(charsToPrint);
    } else {
        console.log(code.text)
    }
}

httpCodes({ code: 200, text: 'OK'});
httpCodes({ code: 201, text: 'Created'});
httpCodes({ code: 400, text: 'Bad Request', printChars: 4});
httpCodes({ code: 404, text: 'Not Found'});
httpCodes({ code: 404, text: 'Not Found', printChars: 3});
httpCodes({ code: 500, text: 'Internal Server Error', printChars: 1});