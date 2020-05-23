function focus() {
    let sectionInputs = document.getElementsByTagName('div')[0].children;

    for (let i = 0; i < sectionInputs.length; i++) {
        sectionInputs[i].lastElementChild.addEventListener('focus', focusSection);
    }

    function focusSection() {
        let currentSection = this.parentElement;

        for (let i = 0; i < sectionInputs.length; i++) {
            if (sectionInputs[i] !== currentSection) {
                sectionInputs[i].classList.remove('focused');
            }
        }

        currentSection.classList.add('focused');
    }
}