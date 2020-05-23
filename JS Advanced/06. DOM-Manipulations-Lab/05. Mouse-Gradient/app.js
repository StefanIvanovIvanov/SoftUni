function attachGradientEvents() {
    let gradientBox = document.getElementById('gradient');
    let result = document.getElementById('result');

    gradientBox.addEventListener('mousemove', getPercent);
    gradientBox.addEventListener('mouseout', clearPercent);

    function getPercent(e) {
        let currentMouseX = e.offsetX;
        let percentage = Math.floor(currentMouseX / this.clientWidth * 100);
        result.textContent = percentage + '%';
    }

    function clearPercent() {
        result.textContent = '';
    }
}