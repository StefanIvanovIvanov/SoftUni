function createCar(
    carBody: carBodyType & diagnostics,
    tires: tiresType & diagnostics,
    engine: engineType & diagnostics,
) {}

let carBody = { material: 'aluminum', state: 'scratched'};
let tires = { airPressure: 30, condition: 'needs change' };
let engine = { horsepower: 300, oilDensity: 780 };

type carBodyType = typeof carBody;
type tiresType = typeof tires;
type engineType = typeof engine;
type diagnostics = { partName: string, runDiagnostics: () => string };

createCar({ material: 'aluminum', state: 'scratched', partName: 'Car Body', runDiagnostics() {return this.partName} },
{ airPressure: 30, condition: 'needs change', partName: 'Tires', runDiagnostics() {return this.partName} },
{ horsepower: 300, oilDensity: 780, partName: 'Engine', runDiagnostics() {return this.partName} });