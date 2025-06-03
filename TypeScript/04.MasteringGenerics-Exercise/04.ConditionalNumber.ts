function conditionalNumber<T>(input: InputParamType<T>): void {
    if(typeof input == 'number') {
        console.log(input.toFixed(2));
    } else {
        console.log(input);
    }
}

type InputParamType<T> = T extends number ? number : string;

conditionalNumber<number>(20.3555);
conditionalNumber<string>('wow');
conditionalNumber<boolean>('a string');

// conditionalNumber<boolean>(30); TS error
// conditionalNumber<number>('test');  TS error