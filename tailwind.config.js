/** @type {import('tailwindcss').Config} **/
module.exports = {
    darkMode: 'class', // Certifique-se de que está definido como 'class'
    content: [
        './Pages/**/*.cshtml',
        './Views/**/*.cshtml',
        './**/*.cshtml',
        './**/*.js',
        './**/*.ts',
        "./Views/**/*.cshtml", // Inclui todas as views do MVC
        "./Views/**/*.cshtml",
        "./wwwroot/js/**/*.js"
    ], // Inclua os arquivos onde Tailwind será usado
    theme: {
        extend: {},
    },
    plugins: [],
};