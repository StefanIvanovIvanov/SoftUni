function deleteByEmail() {
    const tableValues = document.querySelectorAll('td');
    const email = document.getElementsByName('email')[0].value;
    const result = document.getElementById('result');

    let isFound = false;
    for (const tableData of tableValues) {
        if (tableData.innerHTML === email) {
            tableData.parentNode.parentNode.removeChild(tableData.parentNode);
            isFound = true;
        }
    }
    result.innerHTML = isFound ? 'Deleted' : 'Not found';
    document.getElementsByName('email')[0].value = '';
}