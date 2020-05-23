function createArticle() {
let title = document.getElementById('createTitle');
let content = document.getElementById('createContent');
let articles = document.getElementById('articles');

let newArticle = document.createElement('article');
let newTitle = document.createElement('h3');
let newContent = document.createElement('p');

if(title.value===null||content.value===null||articles===null){
    throw new Error('Element not found')
}

if(title.value===''||content.value===''){
    return;
}

newTitle.innerHTML = title.value;
newContent.innerHTML = content.value;

newArticle.appendChild(newTitle);
newArticle.appendChild(newContent);

articles.appendChild(newArticle);

title.value='';
content.value='';
}