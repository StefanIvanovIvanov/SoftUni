let stringOrNumber : string | number;

function optionalMultiplier(par1?: string | number, par2?: string | number, par3?: string | number) : void {

    let num1 =  par1 == undefined ? 1 : Number(par1);
    let num2 = par2 == undefined ? 1 : Number(par2);
    let num3 = par3 == undefined ? 1 : Number(par3);
    console.log(num1 * num2 * num3);
}

optionalMultiplier('3', 5, '10')
optionalMultiplier('2', '2')
optionalMultiplier(undefined, 2, 3)
optionalMultiplier(7, undefined, '2')
optionalMultiplier();