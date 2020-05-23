function attachEventsListeners() {
    document.getElementById('convert').addEventListener('click', onBtnClick);

    function onBtnClick() {
        let inputDistance = Number(document.getElementById('inputDistance').value);
        let outputDistance = document.getElementById('outputDistance');
        let inputUnits = document.getElementById('inputUnits').value;
        let outputUnits = document.getElementById('outputUnits').value;

        let inputToMeters = 0;
        let result = 0;

        switch (inputUnits) {
            case 'km':
                inputToMeters = inputDistance * 1000;
                break;
            case 'm':
                inputToMeters = inputDistance;
                break;
            case 'cm':
                inputToMeters = inputDistance * 0.01;
                break;
            case 'mm':
                inputToMeters = inputDistance * 0.001;
                break;
            case 'mi':
                inputToMeters = inputDistance * 1609.34;
                break;
            case 'yrd':
                inputToMeters = inputDistance * 0.9144;
                break;
            case 'ft':
                inputToMeters = inputDistance * 0.3048;
                break;
            case 'in':
                inputToMeters = inputDistance * 0.0254;
                break;
        }

        switch (outputUnits) {
            case 'km':
                result = inputToMeters / 1000;
                break;
            case 'm':
                result = inputToMeters;
                break;
            case 'cm':
                result = inputToMeters / 0.01;
                break;
            case 'mm':
                result = inputToMeters / 0.001;
                break;
            case 'mi':
                result = inputToMeters / 1609.34;
                break;
            case 'yrd':
                result = inputToMeters / 0.9144;
                break;
            case 'ft':
                result = inputToMeters / 0.3048;
                break;
            case 'in':
                result = inputToMeters / 0.0254;
                break;
        }

        outputDistance.value = result;
    }
}