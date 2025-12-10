/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        //  Colores institucionales principales
        cultura: {
          violeta: '#4B3B8C',   // Violeta institucional MinCultura
          'violeta-dark': '#3A316A',
          'violeta-darker': '#281E52',
          azul: '#6CE4E5',      // Azul claro complementario
          magenta: '#CB6EDC',   // Magenta - cultura popular
          fucsia: '#FF6BD7',    // Fucsia - energía cultural
          amarillo: '#FFC200',  // Amarillo Gobierno Nacional
          rojo: '#FF5600',      // Rojo vibrante - acción o advertencia
          naranja: '#EA823A',   // Naranja cálido - apoyo visual
          gris: '#F5F5F5',      // Gris claro - fondos neutros
        },

        //  Paleta funcional (opcional para semántica UI)
        ui: {
          primary: '#281E52',    // Principal (botones, encabezados)
          secondary: '#4B3B8C',  // Complementario (acento)
          accent: '#FFC200',     // Llamadas a la acción
          background: '#F5F5F5', // Fondo general
          error: '#FF5600',      // Alertas o errores
          highlight: '#FF6BD7',  // Destacados visuales
        },
      },
      fontFamily: {
        sans: ['Nunito', 'sans-serif'],
      },
    },
  },
  plugins: [],
}
