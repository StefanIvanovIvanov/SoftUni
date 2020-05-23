function addItem() {
    const list = document.getElementById('items');
    const input = document.getElementById('newItemText').value;
    let newItem = document.createElement('li');
    newItem.innerHTML = input;
    list.appendChild(newItem);
    document.getElementById('newItemText').value = '';
}