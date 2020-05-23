function addItem() {
    let newItemText = document.getElementById('newItemText').value;
    let newItemValue = document.getElementById('newItemValue').value;

    let newOption = document.createElement('option');
    newOption.textContent = newItemText;
    newOption.value = newItemValue;

    let menu = document.getElementById('menu');

    menu.appendChild(newOption);

    document.getElementById('newItemText').value = '';
    document.getElementById('newItemValue').value = '';
}