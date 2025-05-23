"use strict";
function createCar(carBody, tires, engine) { }
let carBody = { material: 'aluminum', state: 'scratched' };
let tires = { airPressure: 30, condition: 'needs change' };
let engine = { horsepower: 300, oilDensity: 780 };
createCar({ material: 'aluminum', state: 'scratched', partName: 'Car Body', runDiagnostics() { return this.partName; } }, { airPressure: 30, condition: 'needs change', partName: 'Tires', runDiagnostics() { return this.partName; } }, { horsepower: 300, oilDensity: 780, partName: 'Engine', runDiagnostics() { return this.partName; } });
//# sourceMappingURL=03.CarDiagnostics.js.map