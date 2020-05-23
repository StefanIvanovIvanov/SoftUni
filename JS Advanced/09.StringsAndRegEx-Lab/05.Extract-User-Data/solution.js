function solve() {
  let array = JSON.parse(document.getElementById('arr').value);
  let pattern = /^([A-Z][a-z]* [A-Z][a-z]*) (\+359 \d{1} \d{3} \d{3}|\+359-\d{1}-\d{3}-\d{3}) ([a-z0-9]+@[a-z]+\.[a-z]{2,3})$/g;
  let resultElement = document.getElementById('result');

  for (let item of array) {
    let match = pattern.exec(item);
    if (match) {
      let nameElement = document.createElement('p');
      nameElement.textContent = `Name: ${match[1]}`;
      let phoneNumberElement = document.createElement('p');
      phoneNumberElement.textContent = `Phone Number: ${match[2]}`;
      let emailElement = document.createElement('p');
      emailElement.textContent = `Email: ${match[3]}`;

      resultElement.appendChild(nameElement);
      resultElement.appendChild(phoneNumberElement);
      resultElement.appendChild(emailElement);
    } else {
      let pElement = document.createElement('p');
      pElement.textContent = 'Invalid data';
      resultElement.appendChild(pElement);
    }
    let secondElement = document.createElement('p');
    secondElement.textContent = '- - -';
    resultElement.appendChild(secondElement);
  }
}