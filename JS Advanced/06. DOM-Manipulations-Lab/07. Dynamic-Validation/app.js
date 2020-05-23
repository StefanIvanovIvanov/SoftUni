function validate() {
    let input = document.getElementById('email');
    input.addEventListener('change', validate);
    let pattern = /^[a-z]+@[a-z]+\.[a-z]+$/;

    function validate() {
        let email = this.value;

        if (pattern.test(email)) {
            this.classList.remove('error');
        } else {
            this.classList.add('error');
        }
    }
}