// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Функция для отображения текущего времени
function showCurrentTime() {
    const now = new Date();
    const timeElement = document.getElementById('current-time');
    if (timeElement) {
        timeElement.textContent = now.toLocaleTimeString();
    }
}

// Функция для обработки клика по кнопке
function handleButtonClick() {
    const button = document.querySelector('.button');
    if (button) {
        button.addEventListener('click', function() {
            alert('Кнопка была нажата!');
        });
    }
}

// Инициализация при загрузке страницы
document.addEventListener('DOMContentLoaded', function() {
    showCurrentTime();
    handleButtonClick();
    
    // Обновление времени каждую секунду
    setInterval(showCurrentTime, 1000);
});
