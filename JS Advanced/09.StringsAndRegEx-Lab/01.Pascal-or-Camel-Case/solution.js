function solve() {
  let array = document.getElementById('str1').value.toLowerCase().split(' ').filter(x => x !== '');
  let secondString = document.getElementById('str2').value;
  let result = '';

  switch (secondString) {
    case 'Camel Case':
      result += array[0];
      for (let i = 1; i < array.length; i++) {
        let firstLetter = array[i][0].toUpperCase();
        let word = `${firstLetter}${array[i].substr(1)}`;
        result += word;
      }
      break;
    case 'Pascal Case':
      for (let word of array) {
        let firstLetter = word[0].toUpperCase();
        result += `${firstLetter}${word.substr(1)}`;
      }
      break;
    default:
      result = 'Error!';
      break;
  }

  document.getElementById('result').textContent = result;
}