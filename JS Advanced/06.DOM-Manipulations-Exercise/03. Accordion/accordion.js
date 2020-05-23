function toggle() {
    let button = document.querySelector('div.head span.button');
    let textPanel = document.querySelector('#extra');

    if (textPanel.style.display !== 'block') {
        textPanel.style.display = 'block';
        button.textContent = 'Less';
    } else {
        textPanel.style.display = 'none';
        button.textContent = 'More';
    }
}