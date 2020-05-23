function solve() {
   let search = document.getElementById('searchBtn');

   search.addEventListener('click', e => {
      let inputField = document.getElementById('searchField');
      let inputValue = inputField.value;

      if (inputValue === '') {
         return;
      }

      let table = document.getElementsByTagName('tbody')[0];
      let rows = table.getElementsByTagName('tr');
      let rowArr = Array.from(rows);

      rowArr.forEach(r => {
         r.removeAttribute('class');
      });

      for (let i = 0; i < rowArr.length; i++) {
         const el = rowArr[i].innerHTML.toLowerCase();
         if (el.includes(inputValue.toLowerCase())) {
            rowArr[i].className = 'select';
         }
      }

      inputField.value = '';
   })
}