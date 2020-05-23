function solve() {

    let toMenuList = document.getElementById('selectMenuTo');

    let binaryOption = document.createElement('option');
    binaryOption.innerText = 'Binary';
    binaryOption.value = 'binary';
    toMenuList.appendChild(binaryOption);

    let hexadecimalOption = document.createElement('option');
    hexadecimalOption.innerText = 'Hexadecimal';
    hexadecimalOption.value = 'hexadecimal';
    toMenuList.appendChild(hexadecimalOption);

    let convertButton = document.getElementsByTagName('button')[0];
    convertButton.addEventListener('click', e => {
        let inputNumber = Number(document.getElementById('input').value);

        let toValue = toMenuList.value;

        let result = document.getElementById('result');

        if (toValue === 'binary') {
            result.value = inputNumber.toString(2);
        } else if (toValue === 'hexadecimal') {
            result.value = inputNumber.toString(16).toUpperCase();
        }
    })
}