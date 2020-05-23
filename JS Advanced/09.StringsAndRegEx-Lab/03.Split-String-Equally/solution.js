function solve() {
  let str = document.getElementById("str").value;
  let number = Number(document.getElementById("num").value);

  let result = [];
  let counter = 0;
  if (str.length % number !== 0) {
    let length = str.length;
    let count = 0;
    while (length % number !== 0) {
      length %= number;
      length++;
      count++;
    }
    for (let i = 0; i < count; i++) {
      str += str[counter];
      counter++;
    }
  }
  
  for (let i = 0; i < str.length; i += number) {
    result.push(str.substr(i, number));
  }

  document.getElementById('result').textContent = result.join(' ');
}
