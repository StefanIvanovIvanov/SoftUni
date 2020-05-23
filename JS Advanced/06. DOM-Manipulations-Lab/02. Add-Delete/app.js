function addItem() {
    const list = document.getElementById('items');
    const input = document.getElementById('newText').value;
    let newItem = document.createElement('li');
    newItem.innerHTML = input;

    let del = document.createElement('a');
    del.innerHTML = '[Delete]';
    del.href = '#';

    del.addEventListener('click', function (e) {
        e.preventDefault();

        this.parentNode.parentNode.removeChild(this.parentNode);
    })
    newItem.appendChild(del);
    list.appendChild(newItem);
    document.getElementById('newText').value = '';
}