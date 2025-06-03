type FunctionKeys<T> = {
    [K in keyof T]: T[K] extends Function ? K : never;
}[keyof T]

type AllFunctions<T> = Pick<T, FunctionKeys<T>>;


type testObj = { 
   name: string,
   age: number,
   test:() => string;
}

type extractedFunctions = AllFunctions<testObj>



type Employee = {
    name: string,
    salary: number,
    work: () => void,
    takeBreak: () => string
};

type extractedFunctions2 = AllFunctions<Employee>;



type Nope = {
    name: string
};

type extracted3 = AllFunctions<Nope>;