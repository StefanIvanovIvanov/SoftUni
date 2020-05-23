function solve() {
let children = document.querySelector('.middled').children;

for (let i = 0; i < children.length; i++) {
  
let currentChild = children[i];
let currentParagraph = currentChild.querySelector('p')

currentChild.addEventListener('click', function() {
      let count = currentChild.textContent.match(/\d+/);
      currentParagraph.textContent = currentParagraph.textContent.replace(/\d+/, ++count);
    });
  }
}