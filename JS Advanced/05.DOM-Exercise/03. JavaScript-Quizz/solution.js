function solve() {
  let answers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let correctAnswers = 0;
  let currentStep = 0;

  let quizzie = document.getElementById('quizzie');
  let sections = document.getElementsByTagName('section');

  quizzie.addEventListener('click', e => {
    if (e.target.className === 'answer-text') {
      sections[currentStep].style.display = 'none';
      let isCorrect = answers.includes(e.target.innerHTML);
      if (isCorrect) {
        correctAnswers++;
      }

      currentStep++;

      if (currentStep < answers.length) {
        sections[currentStep].style.display = 'block';
      }

      if (currentStep === answers.length) {
        document.querySelector('#results').style.display = 'block';

        let result = document.querySelector('.results-inner h1');
        result.innerHTML = answers.length === correctAnswers ?
          "You are recognized as top JavaScript fan!" : `You have ${correctAnswers} right answers`;
      }
    }
  })
}
