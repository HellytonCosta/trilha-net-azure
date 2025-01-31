document.addEventListener('DOMContentLoaded', () => {
    const themeToggle = document.getElementById('theme-toggle');
    const body = document.body;

    // Verifica a preferência salva no localStorage
    const savedTheme = localStorage.getItem('theme');
    if (savedTheme) {
        body.classList.toggle('dark', savedTheme === 'dark');
    }

    // Alterna o tema e salva a preferência
    themeToggle.addEventListener('click', () => {
        const isDarkMode = body.classList.toggle('dark'); // Alterna a classe 'dark'
        localStorage.setItem('theme', isDarkMode ? 'dark' : 'light'); // Salva a preferência no localStorage

        console.log(isDarkMode);
    });
});

//const themeToggle = document.getElementById('theme-toggle');
//const body = document.body;

//themeToggle.addEventListener('click', () => {
//    // Toggle the data-theme attribute
//    const isDarkMode = body.hasAttribute('data-theme') && body.getAttribute('data-theme') === 'dark';
//    if (isDarkMode) {
//        body.removeAttribute('data-theme');
//    } else {
//        body.setAttribute('data-theme', 'dark');
//    }
//});

