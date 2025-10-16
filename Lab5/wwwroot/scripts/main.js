document.addEventListener('DOMContentLoaded', function() {
    const testButton = document.getElementById('testButton');
    if (testButton) {
        testButton.addEventListener('click', function() {
            alert('Статические файлы работают корректно!');
        });
    }
}); 