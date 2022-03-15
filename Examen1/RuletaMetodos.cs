using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen1.Modelos;

namespace Examen1
{
    class RuletaMetodos
    {

        private Jugador _jugador;
        private Ruleta _ruleta;
        private List<int> _rojos;
        private List<int> _negros;
        private List<int> _contadorPos;
        private int giros = 0;
        private List<int> _numeros;
        private int resultadosRojos = 0;
        private int resultadosNegros = 0;
        private int resultadosPares = 0;
        private int resultadosImpares = 0;


        public RuletaMetodos()
        {
            this._rojos = new List<int>() {
            1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34 ,36};
            this._negros = new List<int>() {
            2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33 ,35};
            this._numeros = new List<int> {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,
            25,26,27,28,29,30,31,32,33,34,35,36};

            this._ruleta = new Ruleta(_rojos, _negros, _contadorPos, 0);
            this._contadorPos = new List<int>();
            
        }

        //Muestra el menu principal
        public void showMenuPrincipal()
        {
            int opcion = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Binvenido al juego de la Ruleta");
                Console.WriteLine("1. Apostar");
                Console.WriteLine("2. Estadisticas");
                Console.WriteLine("3. Terminar");
            } while (!validaMenu(3, ref opcion));
            switch (opcion)
            {
                case 1:
                    apostarMenu();
                    break;
                case 2:
                    estadisticas();
                    break;
                case 3:
                    terminar();
                    break;

            }
        }

        // valida la opcion ingresada
        private bool validaMenu(int opciones, ref int opcionSeleccionada)
        {
            int n;
            if (int.TryParse(Console.ReadLine(), out n))
            {
                if (n <= opciones)
                {
                    opcionSeleccionada = n;
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opción Invalida.");
                    return false;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("El valor ingresado no es válido, debes ingresar un número.");
                return false;
            }
        }

        //pide un string/cadena
        private string pedirValorString(string texto)
        {
            string? valor;
            do
            {
                Console.Write($"{texto}: ");
                valor = Console.ReadLine();
                if (valor == null || valor == "")
                {
                    Console.WriteLine("Valor inválido.");
                }
            } while (valor == null || valor == "");
            return valor;
        }
        private int pedirValorInt(string texto)
        {
            int valor;
            Console.Write($"{texto}: ");
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Valor inválido. Debes ingresar un número.");
                Console.Write($"{texto}: ");
            }
            return valor;
        }

        private int obtenerRandom() {
            Random r = new Random();
            int numeroRandom = r.Next(0, 37);
            return numeroRandom;
        }

        private Boolean esMultiplo(int numero, int multiplo) {
            if (numero % multiplo == 0)
            {
                return true;
            }
            else { 
                return false;
            }
        }

        private Boolean esPar(int numero) {
            return (numero % 2 == 0);
        }

        private Boolean validarApuesta(int apuesta) {
            if (esMultiplo(apuesta, 10))
            {
                return true;
            }
            else {
                return false;
            }
        }

        private void apostarMenu() {
            int opcion = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Apostar");
                Console.WriteLine("1. Apostar numero especifico (0-36)");
                Console.WriteLine("2. Apostar a color rojo o negro");
                Console.WriteLine("3. Apostar si sera impar o par");
                Console.WriteLine("4. Regresar");
            } while (!validaMenu(4, ref opcion));
            switch (opcion)
            {
                case 1:
                    apostarNumeroEspecifico();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuPrincipal();
                    break;
                case 2:
                    apostarColor();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuPrincipal();
                    break;
                case 3:
                    apostarImparPar();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuPrincipal();
                    break;
                case 4:
                    showMenuPrincipal();
                    break;

            }
        }

        private void apostarNumeroEspecifico() { 
            int numeroRandom = obtenerRandom();
            giros++;
            int dineroActual;
            int dineroPerdido;
            int numero = pedirValorInt("Numero (0-36)");
            if ((numero >= 0) && (numero <= 36))
            {
                int apuesta = pedirValorInt("Apuesta");
                if (validarApuesta(apuesta))
                {
                    if (numero == numeroRandom)
                    {

                        apuesta = apuesta * 10;
                        dineroActual = _jugador.dineroActual;
                        dineroActual = dineroActual + apuesta;
                        _jugador.dineroActual = dineroActual;
                        Console.WriteLine("Apuesta ganada!\n");

                    }
                    else
                    {
                        dineroActual = _jugador.dineroActual;
                        dineroActual = dineroActual - apuesta;
                        _jugador.dineroActual = dineroActual;
                        dineroPerdido = _jugador.dineroPerdido;
                        dineroPerdido = dineroPerdido + apuesta;
                        _jugador.dineroPerdido = dineroPerdido;
                        Console.WriteLine($"Apuesta perdida! el número era: {numeroRandom}\n");
                    }
                }
                else
                {
                    Console.WriteLine("Apuesta inválida...");
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    apostarMenu();
                }
            }
            else {
                Console.WriteLine("Número apostado inválido...");
                Console.WriteLine("Presiona 'Enter' para continuar...");
                Console.ReadLine();
                apostarMenu();
            }


        }

        private void apostarColor() {
            int numeroRandom = obtenerRandom();
            giros++;
            
            int dineroActual = 0;
            int dineroPerdido = 0; 
            int apuesta = pedirValorInt("Apuesta");
            if (validarApuesta(apuesta))
            {
                string color = pedirValorString("Color (rojo/negro)");
                if (color.Equals("Rojo", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (int item in _rojos)
                    {
                        if (item == numeroRandom)
                        {
                            apuesta = apuesta * 5;
                            dineroActual = _jugador.dineroActual;
                            dineroActual = dineroActual + apuesta;
                            _jugador.dineroActual = dineroActual;
                            Console.WriteLine("Acertado!");
                            resultadosRojos++;
                            break;

                        }
                        else
                        {
                            dineroActual = _jugador.dineroActual;
                            dineroActual = dineroActual - apuesta;
                            _jugador.dineroActual = dineroActual;
                            dineroPerdido = _jugador.dineroPerdido;
                            dineroPerdido = dineroPerdido + apuesta;
                            _jugador.dineroPerdido = dineroPerdido;
                            Console.WriteLine($"Apuesta perdida! era negro\n ");
                            resultadosNegros++;
                            break;
                        }
                    }
                }
                else {
                    if (color.Equals("Negro", StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (int item in _negros)
                        {
                            if (item == numeroRandom)
                            {
                                apuesta = apuesta * 5;
                                dineroActual = _jugador.dineroActual;
                                dineroActual = dineroActual + apuesta;
                                _jugador.dineroActual = dineroActual;
                                Console.WriteLine("Acertado!");
                                resultadosNegros++;
                                break;

                            }
                            else
                            {
                                dineroActual = _jugador.dineroActual;
                                dineroActual = dineroActual - apuesta;
                                _jugador.dineroActual = dineroActual;
                                dineroPerdido = _jugador.dineroPerdido;
                                dineroPerdido = dineroPerdido + apuesta;
                                _jugador.dineroPerdido = dineroPerdido;
                                Console.WriteLine($"Apuesta perdida! era rojo\n ");
                                resultadosRojos++;
                                break;
                            }
                        }
                    }
                }
                
            }
            else {
                Console.WriteLine("Apuesta inválida...");
                Console.WriteLine("Presiona 'Enter' para continuar...");
                Console.ReadLine();
                apostarMenu();
            }

            
        }


        private void apostarImparPar() {
            int numeroRandom = obtenerRandom();
            giros++;
            int dineroActual = 0;
            int dineroPerdido = 0;
            int apuesta = pedirValorInt("Apuesta");
            if (validarApuesta(apuesta)) {
                string parImpar = pedirValorString("Par o Impar");
                if (parImpar.Equals("Par", StringComparison.OrdinalIgnoreCase))
                {
                    if (esPar(numeroRandom))
                    {
                        apuesta = apuesta * 2;
                        dineroActual = _jugador.dineroActual;
                        dineroActual = dineroActual + apuesta;
                        _jugador.dineroActual = dineroActual;
                        Console.WriteLine($"Acertado!, Número: {numeroRandom}");
                        resultadosPares++;

                    }
                    else
                    {
                        dineroActual = _jugador.dineroActual;
                        dineroActual = dineroActual - apuesta;
                        _jugador.dineroActual = dineroActual;
                        dineroPerdido = _jugador.dineroPerdido;
                        dineroPerdido = dineroPerdido + apuesta;
                        _jugador.dineroPerdido = dineroPerdido;
                        Console.WriteLine($"Apuesta perdida! era impar, Número: {numeroRandom}\n ");
                        resultadosImpares++;

                    }
                }
                else {
                    if (parImpar.Equals("Impar", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!esPar(numeroRandom))
                        {
                            apuesta = apuesta * 2;
                            dineroActual = _jugador.dineroActual;
                            dineroActual = dineroActual + apuesta;
                            _jugador.dineroActual = dineroActual;
                            Console.WriteLine($"Acertado!, Número: {numeroRandom}");
                            resultadosImpares++;

                        }
                        else
                        {
                            dineroActual = _jugador.dineroActual;
                            dineroActual = dineroActual - apuesta;
                            _jugador.dineroActual = dineroActual;
                            dineroPerdido = _jugador.dineroPerdido;
                            dineroPerdido = dineroPerdido + apuesta;
                            _jugador.dineroPerdido = dineroPerdido;
                            Console.WriteLine($"Apuesta perdida! era par, Número: {numeroRandom}\n ");
                            resultadosPares++;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Apuesta inválida...");
                Console.WriteLine("Presiona 'Enter' para continuar...");
                Console.ReadLine();
                apostarMenu();
            }
        }

        private void estadisticas() {
            Console.WriteLine("ESTADISTICAS");
            Console.WriteLine($"Balance: {_jugador.dineroActual}");
            Console.WriteLine($"Cantidad de giros: {giros}");
            Console.WriteLine($"Cantidad resultados rojos: {resultadosRojos}");
            Console.WriteLine($"Cantidad resultados negros: {resultadosNegros}");
            Console.WriteLine($"Cantidad resultados pares: {resultadosPares}");
            Console.WriteLine($"Cantidad resultados impares: {resultadosImpares}");
            Console.WriteLine("Presiona 'Enter' para continuar...");
            Console.ReadLine();
            showMenuPrincipal();
        }
        private void terminar() {
            Console.WriteLine(_jugador.ToString());
        }
        public void inicializarDatos() {
            _jugador = new Jugador("Aaron", 1, 300, 0);

        }

    }
}
