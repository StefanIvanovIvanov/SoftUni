function solve() {
    const addButton = document.querySelector('button');
    const list = document.querySelectorAll('li');

    addButton.addEventListener('click', function (e) {
        e.preventDefault();

        let input = document.querySelector('input').value;
        let firstLetter = input[0].toUpperCase();
        let index = Number(firstLetter.charCodeAt()) - 65;
        let oldValue = list[index].innerHTML;

        let name = firstLetter + input.substring(1).toLocaleLowerCase();

        if (oldValue === '') {
            list[index].innerHTML = name;
        } else {
            list[index].innerHTML += `, ${name} `;
        }
    })
}