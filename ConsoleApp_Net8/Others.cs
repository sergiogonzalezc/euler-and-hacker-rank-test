using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using System.Reflection;
using System.Collections;
using System.Data.Common;
using System.Diagnostics;


namespace ConsoleApp_Net8
{    
    public class OthersProgram
    {
        public static int getTotalX(List<int> a, List<int> b)
        {
            int salida = 0;

            a = a.OrderBy(x => x).ToList();
            b = b.OrderBy(x => x).ToList();

            List<int> listaA = new List<int>();
            List<int> listaN = new List<int>();

            for (int k = 0; k < a.Count; k++)
            {
                for (int k2 = 0; k2 < a.Count; k2++)
                {
                    if (a[k] % a[k2] == 0 && a[k] >= a[k2])
                    {
                        if (!listaA.Exists(x => x == a[k])) // si no está en la lista de los posibles, lo incorpora
                            listaA.Add(a[k]);
                    }
                    else // lo quita
                        listaA.Remove(a[k]);
                }
            }

            for (int k = 0; k < listaA.Count; k++)
            {
                for (int k2 = 0; k2 < b.Count; k2++)
                {
                    if (b[k2] % listaA[k] == 0)
                    {
                        if (!listaN.Exists(x => x == listaA[k])) // si no está en la lista de los definitivos, lo incorpora
                            listaN.Add(listaA[k]);  // lista final
                    }
                }
            }

            salida = listaN.Count;
            return salida;
        }

        public static int diagonalDifference(List<List<int>> arr)
        {
            int sumaPrimaria = 0;
            int sumaSecundaria = 0;
            for (int x = 0; x < arr.ToArray().Length; x++)
            {
                for (int j = 0; j < arr[x].ToArray().Length; j++)
                {
                    if (x == j)
                        sumaPrimaria += arr[x][j];
                }
            }

            int cursor = 0;
            for (int x = arr.ToArray().Length - 1; x >= 0; x--)
            {
                sumaSecundaria += arr[x][cursor];
                cursor++;
            }

            return Math.Abs(sumaPrimaria - sumaSecundaria);
        }

        static double recuFactorial(int n, double acum)
        {
            if (n >= 1)
            {
                acum = acum + (n * recuFactorial(n - 1, acum));
                return acum;
            }
            else
                return 1;
        }

        public static List<string> sortRoman(List<string> names)
        {
            // SGC - Se valida los parametros de entrada
            if (names.Count > 50 || names.Count < 1)
            {
                Console.WriteLine("Error parametros invalidos");
                return null;
            }

            names = names.OrderBy(x => x).ToList(); // aplica orden inicial para faciltar el proceso

            List<string> salida = new List<string>();
            List<objRoman> arrTmp = new List<objRoman>();

            for (int k = 0; k < names.Count; k++)
            {
                string[] arr = names[k].Split(' ');

                if (!arrTmp.Exists(x => x.Nombre == arr[0])) // si no existe el nombre en la lista, lo grega a la lista (primer caso)
                {
                    objRoman obj = new objRoman();
                    obj.Nombre = arr[0];
                    obj.Numero = arr[1];
                    obj.NumeroConvertido = ConvertRoman(arr[1]);
                    arrTmp.Add(obj);
                }
                else
                // si existe el nombre, hay que ver si queda antes o despues del elemento existente
                {
                    int indice = arrTmp.FindIndex(x => x.Nombre == arr[0]); // ubica el indice donde se encuentra el primer elemento

                    objRoman objNew = new objRoman();
                    objNew.Nombre = arr[0];
                    objNew.Numero = arr[1];  // numero en formato Romano
                    objNew.NumeroConvertido = ConvertRoman(arr[1]);   // numero en formato Numerico (entero)

                    int pos = 0;

                    for (int j = indice; j < arrTmp.Count; j++)
                    {
                        // busca la ultima posicion del mismo nombre
                        if (objNew.Nombre == arrTmp[j].Nombre && objNew.NumeroConvertido > arrTmp[j].NumeroConvertido)
                            pos++;
                        else
                            break;  // abandona

                    }

                    // lo inserta en el la posicion INDICE + POS
                    arrTmp.Insert(indice + pos, objNew);
                }
            }

            // imprime la salida
            foreach (var item in arrTmp)
            {
                salida.Add(item.Nombre + " " + item.Numero);
                Console.WriteLine(item.Nombre + " " + item.Numero);
            }

            return salida;
        }

        public static int ConvertRoman(string N)
        {
            if (N == "I")
                return 1;
            else if (N == "II")
                return 2;
            else if (N == "III")
                return 3;
            else if (N == "IV")
                return 4;
            else if (N == "V")
                return 5;
            else if (N == "VI")
                return 6;
            else if (N == "VII")
                return 7;
            else if (N == "VIII")
                return 8;
            else if (N == "IX")
                return 9;
            else if (N == "X")
                return 10;

            else if (N == "XI")
                return 11;
            else if (N == "XII")
                return 12;
            else if (N == "XIII")
                return 13;
            else if (N == "XIV")
                return 14;
            else if (N == "XV")
                return 15;
            else if (N == "XVI")
                return 16;
            else if (N == "XVII")
                return 17;
            else if (N == "XVIII")
                return 18;
            else if (N == "XIX")
                return 19;
            else if (N == "XX")
                return 20;

            else if (N == "XX")
                return 20;
            else if (N == "XXI")
                return 21;
            else if (N == "XXII")
                return 22;
            else if (N == "XXIII")
                return 23;
            else if (N == "XXIV")
                return 24;
            else if (N == "XXV")
                return 25;
            else if (N == "XXVI")
                return 26;
            else if (N == "XXVII")
                return 27;
            else if (N == "XXVIII")
                return 28;
            else if (N == "XXVIII")
                return 29;
            else if (N == "XXX")
                return 30;

            else if (N == "XXXI")
                return 31;
            else if (N == "XXXII")
                return 32;
            else if (N == "XXXIII")
                return 33;
            else if (N == "XXXIV")
                return 34;
            else if (N == "XXXV")
                return 35;
            else if (N == "XXXVI")
                return 36;
            else if (N == "XXXVII")
                return 37;
            else if (N == "XXXVIII")
                return 38;
            else if (N == "XXXIX")
                return 39;

            else if (N == "XL")
                return 40;
            else if (N == "XLI")
                return 41;
            else if (N == "XLII")
                return 42;
            else if (N == "XLIII")
                return 43;
            else if (N == "XLIV")
                return 44;
            else if (N == "XLV")
                return 45;
            else if (N == "XLVI")
                return 46;
            else if (N == "XLVII")
                return 47;
            else if (N == "XLVIII")
                return 48;
            else if (N == "XLIX")
                return 49;

            else if (N == "L")
                return 50;
            else
                return -1;
        }

        static void superStack(string[] operations)
        {
            Stack<int> objStack = new Stack<int>();

            if (operations.Length == 0)
            {
                Console.WriteLine("error");
                return;
            }

            for (int j = 0; j < operations.Length; j++)
            {
                if (string.IsNullOrEmpty(operations[j]))
                {
                    Console.WriteLine("error operacion sin nonbre");
                    return;
                }

                else if (operations[j] == "pop")
                {
                    int elem = objStack.Pop();

                    if (objStack.Count == 0)
                        Console.WriteLine("EMPTY");
                    else
                    {
                        int last = objStack.ElementAt(0);
                        Console.WriteLine(last);
                    }
                }
                else if (operations[j].ToLower().StartsWith("push"))
                {
                    string[] arr = operations[j].Split(' ');

                    if (arr.Length != 2)
                        return;
                    else
                    {
                        int cantidad = Convert.ToInt32(arr[1]);
                        objStack.Push(cantidad);

                        Console.WriteLine(arr[1]);
                    }
                }
                else if (operations[j].ToLower().StartsWith("inc"))
                {
                    string[] arr = operations[j].Split(' ');

                    if (arr.Length != 3)
                        return;
                    else
                    {
                        Stack<int> objStackTemp = new Stack<int>();

                        int cantidadAprocesar = Convert.ToInt32(arr[1]);
                        int montoSumar = Convert.ToInt32(arr[2]);
                        int cantidadRestada = 0;

                        for (int h = objStack.Count - 1; h >= 0; h--)
                        {
                            int encontrado = objStack.ElementAt(h);
                            encontrado = encontrado + montoSumar;

                            objStackTemp.Push(encontrado);

                            cantidadRestada++;
                            if (cantidadAprocesar == cantidadRestada)
                                break;
                        }

                        if (objStack.Count == objStackTemp.Count)
                        {
                            objStack = objStackTemp;

                            int last = objStack.ElementAt(0);
                            Console.WriteLine(last);
                        }
                        else
                        {
                            // agrega los elementos fuera de la copia
                            for (int h = objStack.Count - 1 - cantidadRestada; h >= 0; h--)
                            {
                                int encontrado = objStack.ElementAt(h);
                                objStackTemp.Push(encontrado);
                            }

                            objStack = objStackTemp;

                            int last = objStackTemp.ElementAt(0);
                            Console.WriteLine(last);
                        }
                    }
                }
            }
        }

        public static int numDuplicates(List<string> name, List<int> price, List<int> weight)
        {

            //string[] arrDuplicado = new string[10];
            // buscamos si hay duplicados de nombres

            if (name.Count <= 1)
                return 0;
            else
            {
                List<objSalida> arrNombreDuplicado = new List<objSalida>();
                List<objSalida> arrNombreOrig = new List<objSalida>();
                int iDuplicados = 0;

                int limite = name.Count;
                if (limite > 100000)
                    limite = 100000;

                for (int k = 0; k < limite; k++)
                {
                    string temp = name[k];  // guardo el nombre           

                    if (k + 1 < name.Count)  // si no quedan por revisar
                    {
                        for (int j = k + 1; j < name.Count; j++)
                        {
                            if (name[j] == temp) // hay duplicado de nombre      
                            {
                                // agrego al original
                                if (!arrNombreOrig.Exists(x => x.Nombre == name[k]))
                                {
                                    objSalida objOrig = new objSalida();
                                    objOrig.Indice = k;
                                    objOrig.Peso = weight[k];
                                    objOrig.Precio = price[k];
                                    objOrig.Nombre = name[k];
                                    arrNombreOrig.Add(objOrig);
                                }
                                //objSalida obj = new objSalida();
                                //obj.Indice = j;
                                //obj.Peso = weight[j];
                                //obj.Precio = price[j];
                                //obj.Nombre = name[j];
                                //arrNombreDuplicado.Add(obj);
                                //break;
                            }
                        }
                    }
                }

                // agrego al nuevo solo si el peso o precio es identipo a otro de la lista original
                foreach (var item in arrNombreOrig)
                {
                    for (int j = 0; j < name.Count; j++)
                    {
                        if (item.Indice != j && name[j] == item.Nombre && price[j] == item.Precio && weight[j] == item.Peso)
                        {
                            if (!arrNombreDuplicado.Exists(x => x.Indice == j && x.Nombre == name[j] && x.Precio == price[j] && x.Peso == weight[j]))
                            {
                                objSalida obj = new objSalida();
                                obj.Indice = j;
                                obj.Peso = weight[j];
                                obj.Precio = price[j];
                                obj.Nombre = name[j];
                                arrNombreDuplicado.Add(obj);

                                // si todo coincide, aumente al contador global de duplicados
                                iDuplicados++;

                                //continue;
                            }
                        }
                    }
                }

                return iDuplicados;
            }
        }

        /* SGC: Cuenta las apariciones de numeros del arreglo y devuelve la cantidad de apariciones en *. Usa solo arreglos
         * Devuelve: 
         * 5:******
         * 4:***
         * 3:
         * 2:**
         * */
        private static void Demo()
        {
            int[] myArray = { 1, 2, 1, 3, 3, 1, 2, 1, 5, 1 };

            myArray = OrdenaBurbuja(myArray);

            int minimo = myArray[0];
            int maximo = myArray[myArray.Length - 1];

            int[] arrSalidaKey = new int[maximo - minimo + 1];
            string[] arrSalidaVal = new string[maximo - minimo + 1];


            // calculamos las repeticiones
            int contador = 0;

            for (int n = 0; n < myArray.Length; n++)
            {
                int pos = ExisteClave(arrSalidaKey, myArray[n]);
                if (pos == -1)
                {
                    // si no existe lo agrega pro primera vez
                    arrSalidaKey[contador] = myArray[n];
                    arrSalidaVal[contador] = arrSalidaVal[contador] + "*";
                    contador++;
                }
                else
                {
                    // si existe en la lista, incrementa la cantidad de asteriscos
                    arrSalidaVal[pos] = arrSalidaVal[pos] + "*";

                }
            }


            // imprime la salida
            bool encontrado = false;

            for (int n = minimo; n <= maximo; n++)
            {
                encontrado = false;

                for (int k = 0; k < arrSalidaKey.Length; k++)
                {
                    if (arrSalidaKey[k] == n)
                    {
                        Console.WriteLine(arrSalidaKey[k] + ":" + arrSalidaVal[k]);
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                    Console.WriteLine(n + ":");

            }
        }

        private static int ExisteClave(int[] arrSalidaKey, int Valor)
        {
            for (int n = 0; n < arrSalidaKey.Length; n++)
            {
                if (arrSalidaKey[n] == Valor)
                    return n;
            }

            return -1;
        }

        // cuenta los numeros que sumados en el arreglo dan 10. Salida: [3 7]
        private static void ArregloSuma10()
        {
            int[] myArray = new int[] { 0, 10 };
            int salida = 10;
            string arrSalida = string.Empty;

            for (int j = 1; j <= myArray.Length; j++)
            {
                for (int k = 0; k <= myArray.Length; k++)
                {
                    if (myArray[j] + myArray[k] == salida)
                    {
                        arrSalida = myArray[j] + " " + myArray[k];
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(arrSalida))
                    break;
            }

            Console.WriteLine(arrSalida);
        }

        // SGC Devuelve el maximo elemento y la cantidad de iteraciones de este, usando solo arreglos
        private static void LongestNumer_Array()
        {
            //int[] myArray = { 15,12,15,15,15,1, 2,2,5,4,6,7,8,8,8 };
            int[] myArray = { 1, 2, 2, 5, 4, 6, 7, 8, 8, 8 };

            // primero ordenamos la lista
            myArray = OrdenaBurbuja(myArray);

            int minimo = myArray[0];
            int maximo = myArray[myArray.Length - 1];

            int[] arrSalidaKey = new int[maximo - minimo];
            int[] arrSalidaVal = new int[maximo - minimo];

            int Longest = 0;
            int Number = 0;
            int contador = 0;

            for (int n = 0; n < myArray.Length; n++)
            {
                int pos = ExisteClave(arrSalidaKey, myArray[n]);
                if (pos == -1)
                {
                    // si no existe lo agrega por primera vez
                    arrSalidaKey[contador] = myArray[n];
                    arrSalidaVal[contador] = arrSalidaVal[contador] + 1;
                    contador++;
                }
                else
                {
                    // si existe en la lista, incrementa la cantidad de apariciones
                    arrSalidaVal[pos] = arrSalidaVal[pos] + 1;
                }
            }

            // obtiene los maximos

            for (int j = 1; j < arrSalidaKey.Length; j++)
            {
                // guarda el valor anterior
                if (j <= 1)
                    Longest = arrSalidaVal[j - 1];

                // si es mayor, lo actualiza
                if (arrSalidaVal[j] >= Longest)
                {
                    Longest = arrSalidaVal[j];
                    Number = arrSalidaKey[j];
                }
            }

            Console.WriteLine("Longest: " + Longest);
            Console.WriteLine("Number: " + Number);
        }

        // SGC Devuelve el maximo elemento y la cantidad de iteraciones de este, usando clase <Dictionary>
        private static void LongestNumer_Diccionary()
        {
            int[] myArray = { 1, 8, 8, 8, 2, 2, 4, 5, 6, 7 };

            // primero ordenamos la lista


            myArray = OrdenaBurbuja(myArray); // myArray.OrderBy(x => x).ToArray();

            Dictionary<int, int> acumuladores = new Dictionary<int, int>();

            for (int j = 0; j <= myArray.Length; j++)
            {
                acumuladores[j] = 0;
            }

            for (int j = 0; j < myArray.Length; j++)
            {
                acumuladores[myArray[j]] = 1;
            }

            int temp = 0;

            for (int j = 1; j < myArray.Length; j++)
            {
                if (myArray[j] == myArray[j - 1])
                {
                    // acumula contador
                    if (temp == 0)
                        temp = j;

                    int valor = acumuladores[temp];
                    valor++;
                    acumuladores[temp] = valor;
                    temp = j;
                }
                else
                    temp = 0;
            }

            Dictionary<int, int> final = new Dictionary<int, int>();

            for (int j = 0; j < acumuladores.Count; j++)
            {
                if (acumuladores.Values.ElementAt(j) > 0)
                {
                    final.Add(j, acumuladores[j]);
                }
            }


            Console.WriteLine("Longest: " + final.Values.ElementAt(final.Count - 1));
            Console.WriteLine("Number: " + final.Keys.ElementAt(final.Count - 1));

        }



        /// <summary>
        /// SGC 20-02-2020 - Baires test
        /// </summary>
        /// <param name="arr">Lista de elementos (arreglo de enteros)</param>
        /// <param name="ent">Elemento a buscar</param>
        /// <returns></returns>
        private static int FuncionBairesCalc(int[] arr, int ent)
        {
            int iSalida = 0;
            try
            {
                // primero validamos que la lista tenga valores
                if (arr == null)
                    throw new Exception("Error lista NULA");

                if (arr.Length == 0)
                    throw new Exception("Error: lista vacia");

                // validamos si existe el elemento ent en el arreglo

                for (int n = 0; n < arr.Length; n++)
                {
                    if (ent == arr[n]) // si existe el elemento, incrementa el contador de coincidencias
                        iSalida++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }

            return iSalida;
        }



        /// <summary>
        /// SGC - Calcula la distancia de dos puntos en el espacio
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <returns></returns>
        private static double FuncionBairesDistance(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            double iSalida = 0;
            try
            {
                // pitagoras Distancia 1: x1 hasta x2

                double d1 = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));

                // pitagoras Distancia 2: x1 hasta x3
                double d2 = Math.Sqrt(Math.Pow((x3 - x1), 2) + Math.Pow((y3 - y1), 2));

                // pitagoras Distancia 3: x2 hasta x3
                double d3 = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));

                iSalida = (d1 + d2 + d3) / 3;

            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }

            return iSalida;
        }


        /// <summary>
        /// SGC - Calcula si una palabra de entrada es Palindrome o CasiPalindrome
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        private static bool IsCasiPalindromo(string Input)
        {
            try
            {
                // si es palindrome
                if (EsPalabraPalindromo(Input))
                    return true;
                else if (EsCasiPalindromo(Input))
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }

            return false;
        }


        /// <summary>
        /// SGC
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static bool EsPalabraPalindromo(string Input)
        {
            string[] arrString = Input.ToCharArray().Select(c => c.ToString()).ToArray();  // descompone el arreglo en arreglo de caracteres (char)

            for (int j = 0; j < arrString.Length; j++)
            {
                if (arrString[j] != arrString[arrString.Length - 1 - j]) // si al primero no es igual, cierra ciclo
                    return false;

            }

            return true;  // todas ok           

        }


        /// <summary>
        /// SGC 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        private static bool EsCasiPalindromo(string Input)
        {
            try
            {
                // si es casi palindrome, agrega o modifica una letra y hace el ajuste
                string[] myArray = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "i", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

                string[] arrString = Input.ToCharArray().Select(c => c.ToString()).ToArray();  // descompone el arreglo en arreglo de caracteres (char)

                for (int i = 0; i < myArray.Length; i++)
                {
                    //cambia la letra i y verifica
                    for (int j = 0; j < Input.Length; j++)
                    {
                        string anterior = arrString[j];
                        arrString[j] = myArray[i];

                        // une y arma la nueva cadena
                        string tmp = string.Join("", arrString);

                        if (EsPalabraPalindromo(tmp))
                            return true;
                        else
                            // deja el valor como estaba 
                            arrString[j] = anterior;
                    }
                }

                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }

        /// <summary>
        /// SGC
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="largo"></param>
        /// <returns></returns>
        private static int NumMasPopular(int[] myArray, int largo)
        {
            //int[] myArray = { 15,12,15,15,15,1, 2,2,5,4,6,7,8,8,8 };
            //int[] myArray = { 1, 2, 2, 5, 4, 6, 7, 8, 8, 8 };

            if (myArray.Length == 0)
                return 0;

            if (myArray.Length == 1)
                return myArray[0];  // primer elemento

            // primero ordenamos la lista
            myArray = OrdenaBurbuja(myArray);

            int minimo = myArray[0];
            int maximo = myArray[myArray.Length - 1];

            int[] arrSalidaKey = new int[maximo - minimo + 1];
            int[] arrSalidaVal = new int[maximo - minimo + 1];

            int Longest = 0;
            int Number = 0;
            int contador = 0;

            for (int n = 0; n < myArray.Length; n++)
            {
                int pos = ExisteClave(arrSalidaKey, myArray[n]);
                if (pos == -1)
                {
                    // si no existe lo agrega por primera vez
                    arrSalidaKey[contador] = myArray[n];
                    arrSalidaVal[contador] = arrSalidaVal[contador] + 1;
                    contador++;
                }
                else
                {
                    // si existe en la lista, incrementa la cantidad de apariciones
                    arrSalidaVal[pos] = arrSalidaVal[pos] + 1;
                }
            }

            // obtiene los maximos

            for (int j = 1; j < arrSalidaKey.Length; j++)
            {
                // guarda el valor anterior
                if (j <= 1)
                    Longest = arrSalidaVal[j - 1];

                // si es mayor, lo actualiza
                if (arrSalidaVal[j] > Longest)
                {
                    Longest = arrSalidaVal[j];
                    Number = arrSalidaKey[j];
                }
            }

            return Number; // returna el que mas veces se repite
        }


        static int[] OrdenaBurbuja(int[] arr)
        {
            int temp;

            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            return arr;
        }

        public static bool EsPalindrome(string Input)
        {
            string[] arrString = Input.ToCharArray().Select(c => c.ToString()).ToArray();  // descompone el arreglo en arreglo de caracteres (char)

            if (arrString.Length % 2 == 0) // si es par como 9009 o 1234 puede continuar; en caso contrario (numero impar como 90109, no es palindrome por defecto)
            {
                for (int j = 0; j < arrString.Length; j++)
                {
                    if (arrString[j] != arrString[arrString.Length - 1 - j]) // si al primero no es igual, cierra ciclo
                        return false;

                }

                return true;  // todas ok
            }

            return false;
        }

        // PRUEBA N° 4 - Calculo numeros primos   =======================================
        public static void NumerosPrimos(int input)
        {
            int maxPrime = 0;
            int cont = 0; //un contador, el cual si es mayor a dos indica que el numero no es primo
            for (int i = 1; i <= input; i++)
            {  //apertura del for1
                for (int j = 1; j <= i; j++)
                {   //apertura for2

                    if (i % j == 0)
                    {
                        cont = cont + 1;

                        if (cont > 2)
                        { // si ya es mayor a 2, abandona el numero actual (no es primo) ya que ya van mas de dos divisiones por dos numeros distintos

                            //cont = 0;
                            break;
                        }
                    }
                }


                // si ya es mayor a 2, abandona el numero actual (no es primo) ya que ya van mas de dos divisiones por dos numeros distintos
                // en caso que sea menor o igual, es primo (divisor por 1 si es uno, u divisor por uno y por si mismo si es un numero > 1)
                if ((i == 1 && cont == 1) || (i > 1 && cont == 2))
                {
                    Console.WriteLine(i);  // encontramos un primo!
                                           //if (600851475143 % i == 0)
                    maxPrime = i;


                }      //cierre for2
                cont = 0;               //igualamos a cero para hacer otra evaluacion con otro numero


            }//cierre del for1

            Console.WriteLine($"maxi es {maxPrime}");

            Console.ReadKey();

            //            // FIN PRUEBA N° 4 - Calculo numeros primos   =======================================

        }

        /*
    * Complete the 'divisibleSumPairs' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts following parameters:
    *  1. INTEGER n
    *  2. INTEGER k
    *  3. INTEGER_ARRAY ar
    */

        private static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            int count = 0;
            if (n < 2 || n > 100) throw new Exception("Error");
            if (k < 1 || k > 100) throw new Exception("Error");

            for (int x = 0; x < ar.Count; x++)
            {
                for (int j = 0; j < ar.Count; j++)
                {
                    if ((x < j) && (ar[x] + ar[j]) % k == 0)
                        count++;
                }
            }

            return count;
        }


        /*
   * Complete the 'dayOfProgrammer' function below.
   *
   * The function is expected to return a STRING.
   * The function accepts INTEGER year as parameter.
   */

        public static string dayOfProgrammer(int year)
        {
            string output = string.Empty;
            DateTime selectedDate = new DateTime();
            int cantDays = 0;
            int cantDaysFeb = 0;
            int LIMIT = 256;
            int day = 0;

            if (year < 1700 || year > 2700) throw new Exception("Error");

            cantDays = DateTime.DaysInMonth(year, 1); // ENERO

            // IF IS JULIAN (antes de 1918)
            if (year < 1917)
            {
                if (isLeapYear(year, false))
                    cantDaysFeb = 29;
                else
                    cantDaysFeb = 28;
            }
            //if TRANSICION: 1918
            else if (year > 1917 && year < 1919)
            {
                cantDaysFeb = 28 - 14 + 1;  // ese año 1918 mno fue bisiesto , por lo que la cantiad de dias 15 dias (desde 14 al 28)
            }
            else
            // IF IS GREGORIAN: desde 1919 en adelante
            {
                if (isLeapYear(year, true))
                    cantDaysFeb = 29;
                else
                    cantDaysFeb = 28;
            }

            cantDays += cantDaysFeb;
            cantDays += DateTime.DaysInMonth(year, 3);//MARZO
            cantDays += DateTime.DaysInMonth(year, 4);
            cantDays += DateTime.DaysInMonth(year, 5);
            cantDays += DateTime.DaysInMonth(year, 6);
            cantDays += DateTime.DaysInMonth(year, 7);
            cantDays += DateTime.DaysInMonth(year, 8);

            // si supera
            if (cantDays + DateTime.DaysInMonth(year, 9) > LIMIT)
            {
                day = LIMIT - cantDays;
                selectedDate = new DateTime(year, 9, day);
            }
            else // si falta, se suma dias de mes de septiembre
            {
                cantDays += DateTime.DaysInMonth(year, 9);

                if (cantDays + DateTime.DaysInMonth(year, 10) > LIMIT)
                {
                    day = LIMIT - cantDays;
                    selectedDate = new DateTime(year, 10, day);
                }
            }

            return selectedDate.Day.ToString() + "." + selectedDate.Month.ToString().PadLeft(2, '0') + "." + selectedDate.Year.ToString();
        }

        //Si año es biciesto
        private static bool isLeapYear(int year, bool isGregorian)
        {
            bool isLeapYear = false;
            if (isGregorian) // si es gregoriano, año es divisible por 400 O año es divisible por 4 y año no es divisible por 100
                isLeapYear = year % 400 == 0 || (year % 4 == 0 && year % 100 != 0);
            else // si es juliano, año es divisible por 4
                isLeapYear = (year % 4 == 0);

            return isLeapYear;
        }

        static void Main(string[] args)
        {
            //######################## INI #################################################################################
            Eurocorp_test.Fibonacci(30);
            //####################### FIN ##################################################################################


            //######################## INI #################################################################################
            // Obtiene la suma de los puntos de cada habilidad de cada candidato, y obtiene la suma de las habilidades ordernando del candidato que tenga mas habilidades
            Eurocorp_test.ObtieneAgrupaCandidatos();
            //####################### FIN ##################################################################################

            //######################## INI #################################################################################
            // Dia del programador dia 256
            var dddd = dayOfProgrammer(1800);
            //####################### FIN ##################################################################################


            //###########################INI ##############################################################################
            List<int> inputArray = new List<int>() { 1, 3, 2, 6, 1, 2 };
            int n = 6;
            int k = 3;

            int salida1 = divisibleSumPairs(6, 3, inputArray);

            //####################### FIN ##################################################################################

            //######################## INI #################################################################################
            NumerosPrimos(120);
            //########################## FIN ###############################################################################

            //for (int i = 2; i <= 14; i = i + 3)
            //{
            //    int k = 0;
            //}

            //Demo2Array();
            //########################### INI ##############################################################################
            int[] myArray = { 1, 2, 3, 4, 5, 6, 77, 2, 3, 3, 3, 5 };
            string ent = "abccfg";
            int varlor = NumMasPopular(myArray, 5);

            Console.WriteLine(varlor);
            Console.ReadKey();
            //########################### FIN ##############################################################################

            List<int> arrA = new List<int>() { 2, 4 };
            List<int> arrB = new List<int>() { 16, 92, 36 };

            int suma = getTotalX(arrA, arrB);

            Console.WriteLine(suma);
            Console.ReadKey();

            //List<List<int>> list = new List<List<int>>();
            //var rand = new Random();

            //List<int> sublist = new List<int>();

            //sublist.Add(11);
            //sublist.Add(2);
            //sublist.Add(4);
            //list.Add(sublist);

            //List<int> sublist2 = new List<int>();
            //sublist2.Add(4);
            //sublist2.Add(5);
            //sublist2.Add(6);
            //list.Add(sublist2);

            //List<int> sublist3 = new List<int>();
            //sublist3.Add(10);
            //sublist3.Add(8);
            //sublist3.Add(-12);

            //list.Add(sublist3);


            //int suma = diagonalDifference(list);

            List<string> arrDuplicado1 = new List<string>();
            arrDuplicado1.Add("Francois XLVIII");
            arrDuplicado1.Add("Francois V");
            arrDuplicado1.Add("Francois VI");
            arrDuplicado1.Add("Francois I");
            arrDuplicado1.Add("Anne II");
            arrDuplicado1.Add("Sergio II");
            arrDuplicado1.Add("Anne I");
            arrDuplicado1.Add("Sergio XIII");
            arrDuplicado1.Add("Sergio VIII");
            arrDuplicado1.Add("Sergio L");
            arrDuplicado1.Add("Sergio X");
            arrDuplicado1.Add("Sergio XLVIII");

            sortRoman(arrDuplicado1);

            Console.ReadKey();
            //string[] lista = new string[12];
            //lista[0] = "push 4";
            //lista[1] = "pop";
            //lista[2] = "push 3";
            //lista[3] = "push 5";
            //lista[4] = "push 2";
            //lista[5] = "inc 3 1";
            //lista[6] = "pop";
            //lista[7] = "push 1";
            //lista[8] = "inc 2 2";
            //lista[9] = "push 4";
            //lista[10] = "pop";
            //lista[11] = "pop";

            //superStack(lista);
            //Console.ReadKey();
            ///


            List<string> arrNobres = new List<string>() { "perro", "gato", "perro", "araña", "araña", "gato", "perro", "elefante" };
            List<int> arrPrecio = new List<int>() { 2, 1, 2, 8, 9, 1, 2, 6 };
            List<int> arrPeso = new List<int>() { 7, 3, 7, 5, 2, 3, 7, 5 };
            //List<int> arrPrecio = new List<int>() { 2, 2, 2, 2, 2, 2, 2, 2 };
            //List<int> arrPeso = new List<int>() { 7, 7, 7, 7, 7, 7, 7, 7 };


            int salida = numDuplicates(arrNobres, arrPrecio, arrPeso);

            Console.ReadKey();

            //// Suma de los naturales de 3 y 5 entre 1 y 999
            ////int acum = 0;
            ////for (int u = 1; u < 1000; u++)
            ////{
            ////    if (u % 3 == 0 || u % 5 == 0)
            ////    {
            ////        Console.WriteLine(u);
            ////        acum += u;
            ////    }
            ////}

            ////Console.WriteLine("SUMA = " + acum);
            ////Console.ReadKey();

            //// FIN problema CALCULO DE NUMEROS VISIBLES POR 3 Y 5 ================================

            //// PROBLEMA 2 - Calculo serie de Fibonacci 

            ////decimal temp = 0;
            //////Console.WriteLine("Ingrese el número de numeros de Fibonacci que desea mostrar");
            //////limite = int.Parse(Console.ReadLine());
            ////decimal limite = 1000;
            ////decimal suma = 0;
            ////decimal sumaAnt1 = 0;
            ////decimal sumaAnt2 = 0;
            ////decimal contador = 0;
            ////decimal sumaant = 0;
            ////decimal sumPares = 0;
            ////for (decimal k = 2; k <= 100; k++)
            ////{
            ////    if (k == 1)
            ////    {
            ////        suma = 0;
            ////        sumaAnt1 = 0;
            ////        sumaAnt2 = 0;
            ////    }
            ////    else if (k == 2)
            ////    {
            ////        suma = 1;
            ////        sumaAnt1 = suma;
            ////        sumaAnt2 = 0;
            ////    }
            ////    else
            ////    {
            ////        suma = sumaAnt1 + sumaAnt2;
            ////        sumaAnt2 = sumaAnt1;
            ////        sumaAnt1 = suma;
            ////    }

            ////    if (sumaant == suma)
            ////        continue; // se salta el 1 identico
            ////    else
            ////    {
            ////        sumaant = suma;

            ////        if (suma > 4000000)
            ////            break;

            ////        contador++;
            ////        if (contador > limite)
            ////            break;
            ////    }

            ////    Console.WriteLine(suma);

            ////    if (suma % 2 == 0)
            ////        sumPares += suma;
            ////}
            ////Console.WriteLine("SUMA PARES = " + sumPares);
            ////Console.ReadKey();

            //// FIN PROBLEMA 2 - FIBONACCI ================================

            //// PROBLEMA 3 - CALCULO FACTORIAL
            ////int h = 0;
            ////int aux = 1;
            ////double sal = recuFactorial(100, 0);

            ////NumberFormatInfo setPrecision = new NumberFormatInfo();

            ////setPrecision.NumberDecimalDigits = 99;

            ////Console.Write(sal.ToString("N", setPrecision)); //Should write 1.23


            ////string ssalida = sal.ToString();
            ////string[] arr = new string[ssalida.Length];

            ////string[] arrString = ssalida.ToCharArray().Select(c => c.ToString()).ToArray();
            ////decimal ggg = 0;
            ////for (int u = 0; u < arrString.Length; u++)
            ////{
            ////    ggg += Convert.ToDecimal(arrString[u]);

            ////}

            ////Console.WriteLine(ggg);
            ////Console.ReadKey();

            ////// FIN PROBLEMA 3 - CALCULO FACTORIAL =======================================


            ////System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

            ////string valor = "12227446.1936";
            ////decimal ccc = Convert.ToDecimal(valor.Replace(",", "."));



            //// PRUEBA N° 4 - Calculo numeros primos   =======================================

            ////int maxPrime = 0;
            ////int cont = 0; //un contador, el cual si es mayor a dos indica que el numero no es primo
            ////for (int i = 1; i <= 13195; i++)
            ////{  //apertura del for1
            ////    for (int j = 1; j <= i; j++)
            ////    {   //apertura for2

            ////        if (i % j == 0)
            ////        {
            ////            cont = cont + 1;

            ////            if (cont > 2)
            ////            { // si ya es mayor a 2, abandona el numero actual (no es primo) ya que ya van mas de dos divisiones por dos numeros distintos

            ////                //cont = 0;
            ////                break;
            ////            }
            ////        }
            ////    }


            ////    // si ya es mayor a 2, abandona el numero actual (no es primo) ya que ya van mas de dos divisiones por dos numeros distintos
            ////    // en caso que sea menor o igual, es primo (divisor por 1 si es uno, u divisor por uno y por si mismo si es un numero > 1)
            ////    if ((i == 1 && cont == 1) || (i > 1 && cont == 2))
            ////    {
            ////          Console.WriteLine(i);  // encontramos un primo!
            ////        if (600851475143 % i == 0)
            ////            maxPrime = i;


            ////    }      //cierre for2
            ////    cont = 0;               //igualamos a cero para hacer otra evaluacion con otro numero


            ////}//cierre del for1

            ////Console.WriteLine(maxPrime);

            ////Console.ReadKey();

            //// FIN PRUEBA N° 4 - Calculo numeros primos   =======================================


            ////// PRUEBA N° 5 - Calculo de palindromos  =======================================

            ////int tmpPal = 0;
            ////int jtmp = 0;
            ////int ktmp = 0;
            //////EsPalindrome(90109);

            ////for (int j = 100; j < 1000; j++)
            ////{
            ////    for (int k = 100; k < 1000; k++)
            ////    {
            ////        if (EsPalindrome(j * k))
            ////        {
            ////            if (j * k > tmpPal)
            ////            {
            ////                tmpPal = j * k;  //deja al ultimo
            ////                jtmp = j;
            ////                ktmp = k;
            ////                Console.WriteLine("P --> " + tmpPal);
            ////            }
            ////        }
            ////    }
            ////}

            ////Console.WriteLine("Maxima palindrome --> " + tmpPal);
            ////Console.ReadKey();
            //// FIN PRUEBA N° 5 - Calculo de palindromos =======================================

            //// PRUEBA N° 6 - Multiplo mas pequeño =======================================
            ////for (long k = 1; k < 10000000000; k++)
            ////{
            ////    if (IsDivisible(k, 1, 20))
            ////    {
            ////        Console.WriteLine("Menor --> " + k);
            ////        break;
            ////    }
            ////}

            ////Console.ReadKey();

            //// FIN PRUEBA N° 6 - Diferencia de la suma de los cuadrados =======================================

            //// PRUEBA N° 7 - Diferencia de la suma de los cuadrados =======================================
            ////long suma = 0;
            ////decimal potencia = 0;
            ////decimal sumaIndivisual = 0;

            ////for (long k = 1; k < 101; k++)
            ////{
            ////    decimal actualElevado = (decimal)Math.Pow(k, 2);
            ////    sumaIndivisual += actualElevado;
            ////    suma += k;
            ////}

            ////potencia = (decimal)Math.Pow(suma, 2);

            ////Console.WriteLine("DIFERENCIA = " + (potencia - sumaIndivisual));
            ////Console.ReadKey();

            //// FIN PRUEBA N° 7 - Diferencia de la suma de los cuadrados =======================================



            //string valorCampo = "                                                                                ";

            //string ValorTxt = valorCampo.PadLeft(Convert.ToInt32(80), ' ');

            //if (!ValorTxt.Trim().Equals(""))
            //    throw new Exception("Ok");
            //else
            //    throw new Exception("error");

            //string sDteRutBolElc = "96705150";
            //string sRutReceptor = sDteRutBolElc.Replace(".", "");
            //sRutReceptor = sRutReceptor.Substring(0, sRutReceptor.Length - 2);
            //string sDigitoVerificadorReceptor = sDteRutBolElc.Substring(sDteRutBolElc.Length - 1, 1);

            //char sss = Digito_Verificador("11-6");

            //string texto = "1/Autorefractometro Portátil/6427476";
            //string[] linea = null;
            //double cantidad = 0d;
            //double precio = 0d;
            //long totalLinea = 0;

            //if (LineaTextoValida(texto))
            //{

            //    linea = texto.Split('/');
            //    cantidad = double.Parse(linea[0]);
            //    precio = double.Parse(linea[1]);
            //    totalLinea = Convert.ToInt64(cantidad * precio);  //Correcciones SCM 20-07-2017 ticket 32211 ATM 

            //}


            //string tmp = "28-09-2019 23:13:30";

            //DateTime? salida = null;
            //DateTime dTemp;
            //bool success = DateTime.TryParse(tmp, out dTemp);
            //if (success) salida = dTemp;

            //DateTime FechaAcuseRM = DateTime.ParseExact(tmp, "dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture);


            //string llave = Guid.NewGuid().ToString();

            //string nn = Enum.GetName(typeof(EnumEstadoDte), 3);

            //// 2019-06-22 08:24:24.000
            //DateTime frSII = new DateTime(2019, 6, 22, 8, 24, 24);

            //// 2019-07-09 09:43:32.9588
            //DateTime ahora = new DateTime(2019, 7, 9, 9, 43, 32);

            //double diasDesdeRecepcionSii = Math.Round((ahora - frSII).TotalDays, 0);
            //if (diasDesdeRecepcionSii >= 8)
            //{
            //    // _gestorLog.RegistrarLog(Enumeradores.EnumTiposLog.Info, "ObtieneFechaAcuseReciboMercancia IdDte[" + dte.IdDte + "] tiene [" + diasDesdeRecepcionSii + "] después de la recepción en el SII. FechaRecepcionSII [" + dte.FechaRecepcionSII + "]");
            //    //Al octavo día se asume aceptada si no hay reclamo
            //    var fechaAceptacionAutomatica = frSII.AddDays(8);
            //    //Si el día de aceptación automática es específicamente el día 31 del mes, la contabilización es al mes siguiente,
            //    //por lo tanto se retorna un día adicional. Día 1 del mes siguiente
            //    if (fechaAceptacionAutomatica.Day == 31)
            //    {
            //        DateTime fechaAceptacionAutomaticaNew = fechaAceptacionAutomatica.AddDays(1);
            //        //_gestorLog.RegistrarLog(Enumeradores.EnumTiposLog.Info, "ObtieneFechaAcuseReciboMercancia IdDte[" + dte.IdDte + "] - Se asigna fechaAceptacionAutomatica a [" + fechaAceptacionAutomaticaNew + "] dado que fechaAceptacionAutomatica [" + fechaAceptacionAutomatica + "] cae 31 del mes");

            //        //return fechaAceptacionAutomaticaNew;
            //    }

            //    //return fechaAceptacionAutomatica;
            //}
        }

        public static bool IsDivisible(long Number, int min, int max)
        {
            for (int j = min; j < max + 1; j++)
            {
                if (Number % j != 0)
                    return false;
            }

            return true;
        }

        public static bool EsPalindrome(long Number)
        {
            string sNumer = Number.ToString();
            string[] arrString = sNumer.ToCharArray().Select(c => c.ToString()).ToArray();

            if (arrString.Length % 2 == 0) // si es par como 9000 o 1234 puede continuar; en caso contrario (numero impar como 90109, no es palindrome por defecto)
            {
                for (int j = 0; j < arrString.Length; j++)
                {
                    if (arrString[j] != arrString[arrString.Length - 1 - j]) // si al primero no es igual, cierra ciclo
                        return false;

                }

                return true;  // todas ok
            }

            return false;
        }

        public enum EnumEstadoDte
        {
            Recibido = 1,
            Validado = 2,
            EnviadoErp = 3,
            Rechazado = 4,
            VBPago = 5,
            PagoRealizado = 6,
            PagoRechazado = 7,
            RechazadoDeAprobacion = 8
        }


        //WLS 07-04-2017: Se debe validar el formato de la linea de texto para el reemplazo del ITEM.
        /// <summary>
        /// Método para validación 
        /// </summary>
        /// <param name="lineaTexto"></param>
        /// <returns></returns>
        public static bool LineaTextoValida(string lineaTexto)
        {
            bool flag = false;
            string[] textoSeparado = null;
            try
            {
                //Primero se va a validar la cantidad de separadores de texto. el Formato es NN/PPPPPP/Descripcion
                textoSeparado = lineaTexto.Split('/');
                //Validación de separador
                if (textoSeparado.Length == 3)
                {
                    if (EsNumerico(textoSeparado[0]) && EsNumerico(textoSeparado[1]))
                    {
                        flag = true;
                    }
                }
            }
            catch
            {
                flag = false;
            }

            return flag;
        }

        /// <summary>
        /// char  digito = Utils.Digito_Verificador("10459280");
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static public char Digito_Verificador(string number)
        {
            bool bErr = false;

            if (number == "")
                return ' ';
            else
            {
                int largo, resto, suma = 0;
                char ch;

                largo = number.Length;
                for (int i = 1; i <= largo; i++)
                {
                    ch = number[largo - i];
                    bErr |= ((ch < '0') || (ch > '9'));
                    suma = suma + ((ch - '0') * ((i - 5 + (i < 7 ? 6 : 0)) % 8));
                }
                if (bErr)
                    return ' ';
                resto = suma - ((int)(suma / 11)) * 11;
                switch (resto)
                {
                    case 0: return '0';
                    case 1: return 'K';
                    default: return (char)('9' + 2 - resto);
                }
            }
        }

        /// <summary>
        /// Método que retorna TRUE si la expresion es NUMERICA. En caso contrario devuelve FALSE.
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static System.Boolean EsNumerico(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime || Expression is Boolean)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false
            return false;
        }

    }

    public class objSalida
    {
        public int Indice { get; set; }
        public int Peso { get; set; }
        public int Precio { get; set; }
        public string Nombre { get; set; }
    }

    public class objRoman
    {
        public string Nombre { get; set; }

        public string Numero { get; set; }

        public int NumeroConvertido { get; set; }

    }
}


    //using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using System.Text;
    //using System.Globalization;

    //namespace TEST
    //{
    //    class Program
    //    {
    //        public enum EnumEstadoDte
    //        {
    //            Recibido = 1,
    //            Validado = 2,
    //            EnviadoErp = 3,
    //            Rechazado = 4,
    //            VBPago = 5,
    //            PagoRealizado = 6,
    //            PagoRechazado = 7,
    //            RechazadoDeAprobacion = 8
    //        }

    //        static double recuFactorial(int n, double acum)
    //        {
    //            if (n >= 1)
    //            {
    //                acum = acum + (n * recuFactorial(n - 1, acum));
    //                return acum;
    //            }
    //            else
    //                return 1;
    //        }

    //        static void Main(string[] args)
    //        {
    //            // Suma de los naturales de 3 y 5 entre 1 y 999
    //            //int acum = 0;
    //            //for (int u = 1; u < 1000; u++)
    //            //{
    //            //    if (u % 3 == 0 || u % 5 == 0)
    //            //    {
    //            //        Console.WriteLine(u);
    //            //        acum += u;
    //            //    }
    //            //}

    //            //Console.WriteLine("SUMA = " + acum);
    //            //Console.ReadKey();

    //            // FIN problema CALCULO DE NUMEROS VISIBLES POR 3 Y 5 ================================

    //            // PROBLEMA 2 - Calculo serie de Fibonacci 

    //            //decimal temp = 0;
    //            ////Console.WriteLine("Ingrese el número de numeros de Fibonacci que desea mostrar");
    //            ////limite = int.Parse(Console.ReadLine());
    //            //decimal limite = 1000;
    //            //decimal suma = 0;
    //            //decimal sumaAnt1 = 0;
    //            //decimal sumaAnt2 = 0;
    //            //decimal contador = 0;
    //            //decimal sumaant = 0;
    //            //decimal sumPares = 0;
    //            //for (decimal k = 2; k <= 100; k++)
    //            //{
    //            //    if (k == 1)
    //            //    {
    //            //        suma = 0;
    //            //        sumaAnt1 = 0;
    //            //        sumaAnt2 = 0;
    //            //    }
    //            //    else if (k == 2)
    //            //    {
    //            //        suma = 1;
    //            //        sumaAnt1 = suma;
    //            //        sumaAnt2 = 0;
    //            //    }
    //            //    else
    //            //    {
    //            //        suma = sumaAnt1 + sumaAnt2;
    //            //        sumaAnt2 = sumaAnt1;
    //            //        sumaAnt1 = suma;
    //            //    }

    //            //    if (sumaant == suma)
    //            //        continue; // se salta el 1 identico
    //            //    else
    //            //    {
    //            //        sumaant = suma;

    //            //        if (suma > 4000000)
    //            //            break;

    //            //        contador++;
    //            //        if (contador > limite)
    //            //            break;
    //            //    }

    //            //    Console.WriteLine(suma);

    //            //    if (suma % 2 == 0)
    //            //        sumPares += suma;
    //            //}
    //            //Console.WriteLine("SUMA PARES = " + sumPares);
    //            //Console.ReadKey();

    //            // FIN PROBLEMA 2 - FIBONACCI ================================

    //            // PROBLEMA 3 - CALCULO FACTORIAL
    //            //int h = 0;
    //            //int aux = 1;
    //            //double sal = recuFactorial(100, 0);

    //            //NumberFormatInfo setPrecision = new NumberFormatInfo();

    //            //setPrecision.NumberDecimalDigits = 99;

    //            //Console.Write(sal.ToString("N", setPrecision)); //Should write 1.23


    //            //string ssalida = sal.ToString();
    //            //string[] arr = new string[ssalida.Length];

    //            //string[] arrString = ssalida.ToCharArray().Select(c => c.ToString()).ToArray();
    //            //decimal ggg = 0;
    //            //for (int u = 0; u < arrString.Length; u++)
    //            //{
    //            //    ggg += Convert.ToDecimal(arrString[u]);

    //            //}

    //            //Console.WriteLine(ggg);
    //            //Console.ReadKey();

    //            //// FIN PROBLEMA 3 - CALCULO FACTORIAL =======================================


    //            //System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

    //            //string valor = "12227446.1936";
    //            //decimal ccc = Convert.ToDecimal(valor.Replace(",", "."));



    //            // PRUEBA N° 4 - Calculo numeros primos   =======================================

    //            //int maxPrime = 0;
    //            //int cont = 0; //un contador, el cual si es mayor a dos indica que el numero no es primo
    //            //for (int i = 1; i <= 13195; i++)
    //            //{  //apertura del for1
    //            //    for (int j = 1; j <= i; j++)
    //            //    {   //apertura for2

    //            //        if (i % j == 0)
    //            //        {
    //            //            cont = cont + 1;

    //            //            if (cont > 2)
    //            //            { // si ya es mayor a 2, abandona el numero actual (no es primo) ya que ya van mas de dos divisiones por dos numeros distintos

    //            //                //cont = 0;
    //            //                break;
    //            //            }
    //            //        }
    //            //    }


    //            //    // si ya es mayor a 2, abandona el numero actual (no es primo) ya que ya van mas de dos divisiones por dos numeros distintos
    //            //    // en caso que sea menor o igual, es primo (divisor por 1 si es uno, u divisor por uno y por si mismo si es un numero > 1)
    //            //    if ((i == 1 && cont == 1) || (i > 1 && cont == 2))
    //            //    {
    //            //          Console.WriteLine(i);  // encontramos un primo!
    //            //        if (600851475143 % i == 0)
    //            //            maxPrime = i;


    //            //    }      //cierre for2
    //            //    cont = 0;               //igualamos a cero para hacer otra evaluacion con otro numero


    //            //}//cierre del for1

    //            //Console.WriteLine(maxPrime);

    //            //Console.ReadKey();

    //            // FIN PRUEBA N° 4 - Calculo numeros primos   =======================================


    //            //// PRUEBA N° 5 - Calculo de palindromos  =======================================

    //            //int tmpPal = 0;
    //            //int jtmp = 0;
    //            //int ktmp = 0;
    //            ////EsPalindrome(90109);

    //            //for (int j = 100; j < 1000; j++)
    //            //{
    //            //    for (int k = 100; k < 1000; k++)
    //            //    {
    //            //        if (EsPalindrome(j * k))
    //            //        {
    //            //            if (j * k > tmpPal)
    //            //            {
    //            //                tmpPal = j * k;  //deja al ultimo
    //            //                jtmp = j;
    //            //                ktmp = k;
    //            //                Console.WriteLine("P --> " + tmpPal);
    //            //            }
    //            //        }
    //            //    }
    //            //}

    //            //Console.WriteLine("Maxima palindrome --> " + tmpPal);
    //            //Console.ReadKey();
    //            // FIN PRUEBA N° 5 - Calculo de palindromos =======================================

    //            // PRUEBA N° 6 - Multiplo mas pequeño =======================================
    //            //for (long k = 1; k < 10000000000; k++)
    //            //{
    //            //    if (IsDivisible(k, 1, 20))
    //            //    {
    //            //        Console.WriteLine("Menor --> " + k);
    //            //        break;
    //            //    }
    //            //}

    //            //Console.ReadKey();

    //            // FIN PRUEBA N° 6 - Diferencia de la suma de los cuadrados =======================================

    //            // PRUEBA N° 7 - Diferencia de la suma de los cuadrados =======================================
    //            //long suma = 0;
    //            //decimal potencia = 0;
    //            //decimal sumaIndivisual = 0;

    //            //for (long k = 1; k < 101; k++)
    //            //{
    //            //    decimal actualElevado = (decimal)Math.Pow(k, 2);
    //            //    sumaIndivisual += actualElevado;
    //            //    suma += k;
    //            //}

    //            //potencia = (decimal)Math.Pow(suma, 2);

    //            //Console.WriteLine("DIFERENCIA = " + (potencia - sumaIndivisual));
    //            //Console.ReadKey();

    //            // FIN PRUEBA N° 7 - Diferencia de la suma de los cuadrados =======================================



    //            string valorCampo = "                                                                                ";

    //            string ValorTxt = valorCampo.PadLeft(Convert.ToInt32(80), ' ');

    //            if (!ValorTxt.Trim().Equals(""))
    //                throw new Exception("Ok");
    //            else
    //                throw new Exception("error");

    //            string sDteRutBolElc = "96705150";
    //            string sRutReceptor = sDteRutBolElc.Replace(".", "");
    //            sRutReceptor = sRutReceptor.Substring(0, sRutReceptor.Length - 2);
    //            string sDigitoVerificadorReceptor = sDteRutBolElc.Substring(sDteRutBolElc.Length - 1, 1);

    //            char sss = Digito_Verificador("11-6");

    //            string texto = "1/Autorefractometro Portátil/6427476";
    //            string[] linea = null;
    //            double cantidad = 0d;
    //            double precio = 0d;
    //            long totalLinea = 0;

    //            if (LineaTextoValida(texto))
    //            {

    //                linea = texto.Split('/');
    //                cantidad = double.Parse(linea[0]);
    //                precio = double.Parse(linea[1]);
    //                totalLinea = Convert.ToInt64(cantidad * precio);  //Correcciones SCM 20-07-2017 ticket 32211 ATM 

    //            }


    //            string tmp = "28-09-2019 23:13:30";

    //            DateTime? salida = null;
    //            DateTime dTemp;
    //            bool success = DateTime.TryParse(tmp, out dTemp);
    //            if (success) salida = dTemp;

    //            DateTime FechaAcuseRM = DateTime.ParseExact(tmp, "dd-MM-yyyy hh:mm:ss", CultureInfo.InvariantCulture);


    //            string llave = Guid.NewGuid().ToString();

    //            string nn = Enum.GetName(typeof(EnumEstadoDte), 3);

    //            // 2019-06-22 08:24:24.000
    //            DateTime frSII = new DateTime(2019, 6, 22, 8, 24, 24);

    //            // 2019-07-09 09:43:32.9588
    //            DateTime ahora = new DateTime(2019, 7, 9, 9, 43, 32);

    //            double diasDesdeRecepcionSii = Math.Round((ahora - frSII).TotalDays, 0);
    //            if (diasDesdeRecepcionSii >= 8)
    //            {
    //                // _gestorLog.RegistrarLog(Enumeradores.EnumTiposLog.Info, "ObtieneFechaAcuseReciboMercancia IdDte[" + dte.IdDte + "] tiene [" + diasDesdeRecepcionSii + "] después de la recepción en el SII. FechaRecepcionSII [" + dte.FechaRecepcionSII + "]");
    //                //Al octavo día se asume aceptada si no hay reclamo
    //                var fechaAceptacionAutomatica = frSII.AddDays(8);
    //                //Si el día de aceptación automática es específicamente el día 31 del mes, la contabilización es al mes siguiente,
    //                //por lo tanto se retorna un día adicional. Día 1 del mes siguiente
    //                if (fechaAceptacionAutomatica.Day == 31)
    //                {
    //                    DateTime fechaAceptacionAutomaticaNew = fechaAceptacionAutomatica.AddDays(1);
    //                    //_gestorLog.RegistrarLog(Enumeradores.EnumTiposLog.Info, "ObtieneFechaAcuseReciboMercancia IdDte[" + dte.IdDte + "] - Se asigna fechaAceptacionAutomatica a [" + fechaAceptacionAutomaticaNew + "] dado que fechaAceptacionAutomatica [" + fechaAceptacionAutomatica + "] cae 31 del mes");

    //                    //return fechaAceptacionAutomaticaNew;
    //                }

    //                //return fechaAceptacionAutomatica;
    //            }
    //        }

    //        public static bool IsDivisible(long Number, int min, int max)
    //        {
    //            for (int j = min; j < max + 1; j++)
    //            {
    //                if (Number % j != 0)
    //                    return false;
    //            }

    //            return true;
    //        }




    //        //WLS 07-04-2017: Se debe validar el formato de la linea de texto para el reemplazo del ITEM.
    //        /// <summary>
    //        /// Método para validación 
    //        /// </summary>
    //        /// <param name="lineaTexto"></param>
    //        /// <returns></returns>
    //        public static bool LineaTextoValida(string lineaTexto)
    //        {
    //            bool flag = false;
    //            string[] textoSeparado = null;
    //            try
    //            {
    //                //Primero se va a validar la cantidad de separadores de texto. el Formato es NN/PPPPPP/Descripcion
    //                textoSeparado = lineaTexto.Split('/');
    //                //Validación de separador
    //                if (textoSeparado.Length == 3)
    //                {
    //                    if (EsNumerico(textoSeparado[0]) && EsNumerico(textoSeparado[1]))
    //                    {
    //                        flag = true;
    //                    }
    //                }
    //            }
    //            catch
    //            {
    //                flag = false;
    //            }

    //            return flag;
    //        }

    //        /// <summary>
    //        /// char  digito = Utils.Digito_Verificador("10459280");
    //        /// </summary>
    //        /// <param name="number"></param>
    //        /// <returns></returns>
    //        static public char Digito_Verificador(string number)
    //        {
    //            bool bErr = false;

    //            if (number == "")
    //                return ' ';
    //            else
    //            {
    //                int largo, resto, suma = 0;
    //                char ch;

    //                largo = number.Length;
    //                for (int i = 1; i <= largo; i++)
    //                {
    //                    ch = number[largo - i];
    //                    bErr |= ((ch < '0') || (ch > '9'));
    //                    suma = suma + ((ch - '0') * ((i - 5 + (i < 7 ? 6 : 0)) % 8));
    //                }
    //                if (bErr)
    //                    return ' ';
    //                resto = suma - ((int)(suma / 11)) * 11;
    //                switch (resto)
    //                {
    //                    case 0: return '0';
    //                    case 1: return 'K';
    //                    default: return (char)('9' + 2 - resto);
    //                }
    //            }
    //        }

    //        /// <summary>
    //        /// Método que retorna TRUE si la expresion es NUMERICA. En caso contrario devuelve FALSE.
    //        /// </summary>
    //        /// <param name="Expression"></param>
    //        /// <returns></returns>
    //        public static System.Boolean EsNumerico(System.Object Expression)
    //        {
    //            if (Expression == null || Expression is DateTime || Expression is Boolean)
    //                return false;

    //            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double)
    //                return true;

    //            try
    //            {
    //                if (Expression is string)
    //                    Double.Parse(Expression as string);
    //                else
    //                    Double.Parse(Expression.ToString());
    //                return true;
    //            }
    //            catch { } // just dismiss errors but return false
    //            return false;
    //        }

    //    }
    //}




