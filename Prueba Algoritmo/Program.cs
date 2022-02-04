using System;
using System.Collections;
using System.Collections.Generic;


namespace Prueba_Algoritmo
{
    class Program
    {
        private static List<int> listaNumero = new List<int>();

        private static int menor = 0;
        private static int mayor = 0;

        private static bool presEsc = false;

        static void Main(string[] args)
        {

            int x = 0;
            int nCons = 0;


            Console.Write("Cantidad de Numeos a Ingresar: ");
            x = int.Parse(Console.ReadLine());

            AgregarNumeros(x);

            IndexarNumeros(x);

            Console.WriteLine("");

            do
            {
                Console.Write("Numero a Consultar: ");
                nCons = int.Parse(Console.ReadLine());

                BuscarNumero(nCons, x);

                Console.WriteLine("");
                Console.WriteLine("Presiona Enter para continuar, Esc para terminar");
                var esc = Console.ReadKey();
                if (esc.Key == ConsoleKey.Escape)
                    presEsc = true;
                Console.WriteLine("");

            } while ( presEsc == false);
            


        }


        /// <summary>
        /// Se agrega a la lista la cantidad de numeros indicada
        /// </summary>
        /// <param name="x">Cantidad de numeros indicada</param>
        private static void AgregarNumeros( int x)
        {
            int index = 0;
            string sTemp = "";

            while (index < x)
            {
                var a = Console.ReadKey();
                if (Char.IsLetter(a.KeyChar)) //Si la tecla es algun caracter se elimina de la pantalla
                {
                    Console.Write((Char)8); //Backspace
                    Console.Write((Char)32); //Space
                    Console.Write((Char)8); //Backspace
                }
                if (Char.IsWhiteSpace(a.KeyChar) || a.Key == ConsoleKey.Enter) //Si la tecla es espacio o Enter se agrega el numero a a lista
                {
                    listaNumero.Add(int.Parse(sTemp));
                    index++;
                    sTemp = "";
                }
                else if (Char.IsDigit(a.KeyChar)) //Si la tecla es un digito se agreag a 'temp' para ir formando el numero
                    sTemp += a.KeyChar.ToString();
            }
        }


        /// <summary>
        /// Se crea el indice ordenado de menor a mayor con respecto a la cantidad de numeros indicada
        /// </summary>
        /// <param name="x">Cantidad de numeros indicada</param>
        private static void IndexarNumeros(int x)
        {
            int temp = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (listaNumero[i] < listaNumero[j])
                    {
                        temp = listaNumero[i];
                        listaNumero[i] = listaNumero[j];
                        listaNumero[j] = temp;
                    }
                }
            }
        }


        /// <summary>
        /// Busca la secuencia de numeros de acuerdo al numero buscado
        /// </summary>
        /// <param name="nCons">Numero Buscado</param>
        /// <param name="index">Cantidad de items de la lista</param>
        private static void BuscarNumero(int nCons, int index)
        {
            //Si el primer numero de la lista es igual al numero buscado
            if (listaNumero[0] == nCons)
            {
                Console.WriteLine($"X {listaNumero[1]}");
                return;
            }
            //Si no, revisa si es igual al ultimo numero de la lista
            else if (listaNumero[index - 1] == nCons)
            {
                Console.WriteLine($"{listaNumero[index - 2]} X");
                return;
            }

            //Si llega a este punto, se recorre cada elemento de la lista para revisar si el numero buscado
            //es igual a algun elemento de la lista
            for (int i = 0; i < index; i++)
            {
                if (listaNumero[i] == nCons)
                {
                    Console.WriteLine($"{listaNumero[i - 1]} {listaNumero[i + 1]}");
                    return;
                }
            }

            //Si llega a este punto, no se encuentra el numero buscado dentro de la lista, asi que
            //Se busca el numero menor mas cercano
            for (int i = 0; i < listaNumero.Count; i++)
            {
                if (listaNumero[i] < nCons)
                    menor = listaNumero[i];
                else if (listaNumero[i] > nCons && listaNumero[0] < nCons)
                {
                    Console.WriteLine($"{listaNumero[i - 1]} {listaNumero[i]}");
                    return;
                }
                else
                    menor = listaNumero[0];
            }

            if (Extremos(menor, index)) return;

            //Si llega a este punto, se busca el numero mayor mas cercano
            for (int i = listaNumero.Count; i > 0; i--)
            {
                if (listaNumero[i] > nCons)
                    mayor = listaNumero[i];
                else if (listaNumero[i] < nCons && listaNumero[index-1] > nCons)
                {
                    Console.WriteLine($"{listaNumero[i]} {listaNumero[i + 1]}");
                    return;
                }
                else
                    mayor = listaNumero[index - 1];
            }
            
            if (Extremos(mayor, index)) return;
        }


        /// <summary>
        /// Encuentra el numero del extremo correspondiente de la lista, de a cuerdo con el numero buscado
        /// </summary>
        /// <param name="numero">Numero buscado</param>
        /// <param name="index">Cantidad de items de la lista</param>
        /// <returns>Si encuentra coincidencia retona True, de lo contrario, retorna false</returns>
        private static bool Extremos(int numero, int index)
        {
            if (listaNumero[0] == numero)
            {
                Console.WriteLine($"X {listaNumero[0]}");
                return true;
            }
            else if (listaNumero[index - 1] == numero)
            {
                Console.WriteLine($"{listaNumero[index - 1]} X");
                return true;
            }
            return false;
        }
    }
}
