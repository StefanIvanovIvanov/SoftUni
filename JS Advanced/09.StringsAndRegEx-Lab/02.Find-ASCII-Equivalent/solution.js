function solve() {
  let array = document.getElementById('str').value.split(' ').filter(x => x !== '');
  let result = '';
  let resultElement = document.getElementById('result');

  for (let item of array) {
    if (Number(item)) {
      result += String.fromCharCode(item);
    } else {
      let itemArray = item.split('');
      let symbols = [];
      for (let char of itemArray) {
        symbols.push(char.charCodeAt(0));
      }

      let pElement = document.createElement('p');
      pElement.textContent = symbols.join(' ');
      resultElement.appendChild(pElement);
    }
  }

  let pResultElement = document.createElement('p');
  pResultElement.textContent = result;
  resultElement.appendChild(pResultElement);
}