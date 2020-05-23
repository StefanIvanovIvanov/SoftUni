function stopwatch() {
    let startButton = document.getElementById('startBtn');
    startButton.addEventListener('click', start);

    let stopButton = document.getElementById('stopBtn');
    stopButton.addEventListener('click', stop);

    let output = document.getElementById('time');
    let timer = null;

    function start() {
        startButton.disabled = true;
        stopButton.disabled = false;

        let seconds = 0;

        timer = setInterval(tick, 1000);

        output.textContent = '00:00';

        function tick() {
            seconds++;

            let currentMinute = ('0' + Math.floor(seconds / 60)).slice(-2);
            let currentSecond = ('0' + seconds % 60).slice(-2);

            output.textContent = `${currentMinute}:${currentSecond}`;
        }
    }

    function stop() {
        stopButton.disabled = true;
        startButton.disabled = false;

        clearInterval(timer);
    }
}