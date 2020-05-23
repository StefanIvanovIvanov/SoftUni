function subtract() {
    let firstNumber = document.getElementById('firstNumber').value;
    let secondNumber = document.getElementById('secondNumber').value;
    document.getElementById('result').innerText = +firstNumber - +secondNumber;

    // let firstNumber = Number(document.getElementById('firstNumber').value);
    // let secondNumber = Number(document.getElementById('secondNumber').value);
    // let result = document.getElementById('result');
    // result.innerHTML = firstNumber - secondNumber;
}