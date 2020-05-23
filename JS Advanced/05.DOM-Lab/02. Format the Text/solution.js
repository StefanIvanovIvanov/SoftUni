function solve() {
let text = document.getElementById('input');
let sentences = text.innerHTML.split('.');
sentences.pop();
 
let result = document.getElementById('output');

for(let i=0; i<sentences.length; i+=3) {
  let newParagrapghText = sentences.slice(i,i+3).join('.');
  let p = document.createElement('p');
  p.innerHTML = newParagrapghText+'.';
  result.appendChild(p);
}
}