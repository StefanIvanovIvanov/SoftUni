function solve() {
    let buttons = document.getElementsByClassName('keys')[0];
    let clear = document.getElementsByClassName('clear')[0];
    let expression = document.getElementById('expressionOutput');
    let result = document.getElementById('resultOutput');
    let operators = ['+', '-', '*', '/', ','];

    buttons.addEventListener('click', ({ target: { value } }) => {
        clear.addEventListener('click', (e) => {
            expression.innerHTML = '';
            result.innerHTML = '';
        })

        if (!value) {
            return;
        }
        if (value === '=') {
            result.innerHTML = eval(expression.innerHTML);
        }
        if (operators.includes(value)) {
            value = ` ${value} `;
        }
        if (value === '=') {
            return;
        }
        expression.innerHTML += value;
    });
}