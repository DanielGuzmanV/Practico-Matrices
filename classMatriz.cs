using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Matrices
{
    class classMatriz
    {
        // Atributos
        const int maxFil = 50;
        const int maxColmun = 50;
        public int[,] matriz;
        public int fila, colum;

        // Constructor
        public classMatriz()
        {
            matriz = new int[maxFil, maxColmun];
            fila = 0; colum = 0;
        }

        // Metodos
        public void setDateRandom(int numFil, int numCol, int min, int max)
        {
            Random rand = new Random();
            this.fila = numFil; this.colum = numCol;
            for(int fil = 1; fil <= this.fila; fil++)
            {
                for(int col =1; col <= this.colum; col++)
                {
                    matriz[fil, col] = rand.Next(min, max + 1);
                }
            }
        }

        public string getDate()
        {
            string space = "";
            for (int fil = 1; fil <= this.fila; fil++)
            {
                for (int col = 1; col <= this.colum; col++)
                {
                    space = space + matriz[fil, col] + "\t";
                }
                space = space + "\x000d" + "\x000a";
            }
            return space;
        }
        // Funciones auxiliares para las preguntas del practico
        // ----------------------------------------------------

        // Matriz secuencial por fila de un extremo inferior derecho hacia izquierdo
        // Para verificar la pregunta 1
        public void mtzExtremInferior(int numfil, int numcol, int min, int max)
        {
            Random rando = new Random();
            this.fila = numfil; this.colum = numcol;
            for(int fil = this.fila; fil >=1; fil--)
            {
                for(int col = this.colum; col >= 1; col--)
                {
                    matriz[fil, col] = rando.Next(min, max + 1);
                }
            }
        }

        // Serie de matriz (extremo inferior izquierdo por filas de izquierda a derecha)
        // Para verificar la pregunta 7
        public void serieMatriz1(int numfil, int numcol, int ini, int razon)
        {
            int idx = 0;
            this.fila = numfil; this.colum = numcol; 
            for(int fil = this.fila; fil >= 1; fil--)
            {
                for(int col = 1; col <= this.colum; col++)
                {
                    idx++;
                    matriz[fil, col] = ini + (idx - 1) * razon;
                }
            }
        }

        // Intercambio de elementos de una matriz
        public void interCambio(int fil1, int col1, int fil2, int col2)
        {
            int auxi = matriz[fil1, col1];
            matriz[fil1, col1] = matriz[fil2, col2];
            matriz[fil2, col2] = auxi;
        }
        // Ordenamiento de una matriz
        public void ordenMatriz()
        {
            int filPosi, colPosi, filDesp, colDesp, idx;
            for(filPosi = 1; filPosi <= this.fila; filPosi++)
            {
                for(colPosi = 1; colPosi <= this.colum; colPosi++)
                {
                    for(filDesp = filPosi; filDesp <= this.fila; filDesp++)
                    {
                        if(filDesp == filPosi)
                        {
                            idx = colPosi;
                        }
                        else
                        {
                            idx = 1;
                        }
                        for(colDesp = idx; colDesp <= this.colum; colDesp++)
                        {
                            if(matriz[filPosi, colPosi] > matriz[filDesp, colDesp])
                            {
                                this.interCambio(filPosi, colPosi, filDesp, colDesp);
                            }
                        }
                    }
                }
            }
        }   

        // Funcion auxiliar para buscar un elemento en una matriz
        public bool busquedaSecu(int number)
        {
            int fil = 1, col; bool answer = false;
            while((fil <= this.fila) && (answer == false))
            {
                col = 1; 
                while((col <= this.colum) && (answer == false))
                {
                    if(matriz[fil, col] == number)
                    {
                        answer = true;
                    }
                    col++;
                }
                fil++;
            }
            return answer;
        }

        // Funcion para encontrar la frecuencia de un elemento
        public int frecuMatriz(int number)
        {
            int frecu = 0;
            for(int col = this.colum; col > 1; col--)
            {
                for(int fil = 2; fil <= this.fila; fil++)
                {
                    if(matriz[fil, col] == number)
                    {
                        frecu++;
                    }
                }
            }
            return frecu;
        }

        // Funcion auxiliar para la pregunta 2: practico 2
        public void ordenExtremInferiorIzquierda()
        {
            int idx;
           for(int colpos = 1; colpos <= this.colum; colpos++)
            {
                for(int filpos = this.fila; filpos >= 1; filpos--)
                {
                    for(int coldesp = colpos; coldesp <= this.colum; coldesp++)
                    {
                        if (coldesp == colpos)
                            idx = filpos;
                        else
                            idx = this.fila;
                        for(int fildesp = idx; fildesp >= 1; fildesp--)
                        {
                            if(matriz[filpos, colpos] > matriz[fildesp, coldesp])
                            {
                                this.interCambio(fildesp, coldesp, filpos, colpos);
                            }
                        }
                    }
                }
            } 
        }

        // ---- Practico 1 de Matrices ----
        /* Pregunta 1: con los elementos primos de la matriz acumular 
           F= - √1 + √11 − √5 + √3 (Analizar la secuencia de los elementos de la matriz por filas del extremo inferior derecho
        */
        public double operaElemPrimos()
        {
            numerosEnteros number = new numerosEnteros();
            double raizSum = 0; double raizRes = 0; bool cambio = true;
            double result = 0;
            for(int fil = this.fila; fil >= 1; fil--)
            {
                for(int col = this.colum; col >= 1; col--)
                {
                    number.cargarDatos(matriz[fil, col]);
                    if(number.verifPrimo() == true)
                    {
                        if(cambio == true)
                        {
                            raizRes = raizRes - Math.Sqrt(matriz[fil, col]);
                        }
                        else
                        {
                            raizSum = raizSum + Math.Sqrt(matriz[fil, col]);
                        }
                        cambio = !cambio;
                        result = raizSum + raizRes;
                    }
                }
            }
            return result;
        }

        // Pregunta 2: Encontrar la frecuencia de un elemento en la matriz.
        // Ele=6 => frec=3
        public void frecuenMaxMatriz(ref int elem, ref int frecu)
        {
            int fil, col, numEle, numfrecu, max;
            max = 0; fil = 1; col = 1;
            this.ordenMatriz();

            for(fil = 1; fil <= this.fila; fil++)
            {
                for(col = 1; col <= this.colum; col++)
                {
                    numfrecu = 0;
                    numEle = matriz[fil, col];
                    for(int fil2 = 1; fil2 <= this.fila; fil2++)
                    {
                        for(int col2 = 1; col2 <= this.colum; col2++)
                        {
                            if(matriz[fil2, col2] == numEle)
                            {
                                numfrecu++;
                            }
                        }
                    }
                    if ((numfrecu > max) && (numfrecu != 1))
                    {
                        max = numfrecu;

                        elem = numEle;
                        frecu = max;
                    }
                }
            }
        }

        // Pregunta 3: contar los elementos que no se repiten (unicos) 
        public void elemNoRepet(ref int elemento)
        {
            int conta, numEle, fil, col, numFrecu;
            conta = 0;
            this.ordenMatriz();
            
            for(fil = 1; fil <= this.fila; fil++)
            {
                for(col = 1; col <= this.colum; col++)
                {
                    numFrecu = 0;
                    numEle = matriz[fil, col];

                    for(int fil2 = 1; fil2 <= this.fila; fil2++)
                    {
                        for(int col2 = 1;col2 <= this.colum; col2++)
                        {
                            if(matriz[fil2, col2] == numEle)
                            {
                                numFrecu++;
                            }
                        }
                    }
                    if(numFrecu == 1)
                    {
                        conta++;
                    }
                }
            }
            elemento = conta;
        }

        // Pregunta 4: cargar la matriz con la serie fibonacci segun el esquma
        // fibonacci: 0,1,1,2,3,5,8,13,21,34,55,89
        public void cargarFiboSnake(int numfil, int numcol)
        {
            this.fila = numfil; this.colum = numcol; bool change = true;
            int numfibo, numA = -1, numB = 1;
            for(int fil1 = 1; fil1 <= this.fila; fil1++)
            {
                if(change == true)
                {
                    for(int col1 = 1; col1 <= this.colum; col1++)
                    {
                        numfibo = numA + numB;
                        matriz[fil1, col1] = numfibo;
                        numA = numB; numB = numfibo;
                    }
                }
                else
                {
                    for(int col2 = this.colum; col2 >= 1; col2--)
                    {
                        numfibo = numA + numB;
                        matriz[fil1, col2] = numfibo;
                        numA = numB; numB = numfibo;
                    }
                }
                change = !change;
            }
        }

        // Pregunta 5: Verificar si todas las filas estan ordenadas en forma ascendente
        public bool verifOrdenFilas()
        {
            int col, fil, eleAnte; bool answer = true;
            fil = 1; 
            while((fil <= this.fila) && (answer == true))
            {
                col = 1;
                eleAnte = matriz[fil, col];
                while((col <= this.colum) && (answer == true))
                {
                    if(matriz[fil, col] >= eleAnte)
                    {
                        eleAnte = matriz[fil, col];
                    }
                    else
                    {
                        answer = false;
                    }
                    col++;
                }
                fil++;
            }
            return answer;
        }

        // Pregunta 6: Para todas las filas, encontrar el elemento de mayor frecuencia
        // y colocarlas en la ultima fila
        // Funcion auxiliar para la pregunta 6
        public int mayorElemFil(int numfil)
        {
            int numele, conta, mayor = 0, frecu = 0;
            // --------------------------------------
            for(int col1 = 1; col1 <= this.colum; col1++)
            {
                conta = 0; numele = matriz[numfil, col1];
                for(int col2 = 1; col2 <= this.colum; col2++)
                {
                    if(matriz[numfil, col2] == numele)
                    {
                        conta++;
                    }
                }
                if(conta > mayor)
                {
                    mayor = conta;
                    frecu = numele;
                }
            }
            if(mayor == 1)
            {
                frecu = 0;
            }
            return frecu;
        }

        // Realizamos la pregunta 6
        public void elemMayEnCol()
        {
            for(int fil = 1; fil <= this.colum; fil++)
            {
                matriz[fil, this.colum + 1] = this.mayorElemFil(fil);
            }
            this.colum++;
        }
        
        // Pregunta 7: Verificar si la matriz esta ordenada con rigor r =1
        // del esquema segun el ejemplo
        public bool verifOrdenRigor1()
        {
            int col, fil, numEle; bool answer = true;
            fil = this.fila; col = 2; numEle = matriz[this.fila, 1];
            while((fil >= 1) && (answer == true))
            {
                while((col <= this.colum) && (answer == true))
                {
                    if(matriz[fil, col] > numEle)
                    {
                        numEle = matriz[fil, col];
                    }
                    else
                    {
                        answer = false;
                    }
                    col++;
                }
                col = 1; fil--;
            }
            return answer;
        }

        // Pregunta 8: verificar si una matriz esta incluida en otro
        // (Si todos los elementos de la 1era matriz estan estan en la 2da matriz)
        public bool verifMatEnMat(classMatriz matriz2)
        {
            int col, fil = 1; bool answer = true;
            while ((fil <= this.fila) && (answer == true))
            {
                col = 1; 
                while((col <= this.colum) && (answer == true))
                {
                    if(!(matriz2.busquedaSecu(matriz[fil, col]) == true))
                    {
                        answer = false;
                    }
                    col++;
                }
                fil++;
            }
            return answer;
        }

        // Pregunta 9: segmentar las filas de la matriz en pares e impares ordenados
        public void segmentarParImpar()
        {
            numerosEnteros number1 = new numerosEnteros();
            numerosEnteros number2 = new numerosEnteros();

            for(int fil1 = 1; fil1 <= this.fila; fil1++)
            {
                for(int col1 = 1; col1 <= this.colum; col1++)
                {
                    for(int col2 = 1; col2 <= this.colum; col2++)
                    {
                        number1.cargarDatos(matriz[fil1, col1]);
                        number2.cargarDatos(matriz[fil1, col2]);

                        if((number1.verifcarPar()) && !(number2.verifcarPar()) || 
                            (number1.verifcarPar()) && (number2.verifcarPar()) && (matriz[fil1, col1] < matriz[fil1, col2]) ||
                            !(number1.verifcarPar()) && !(number2.verifcarPar()) && (matriz[fil1, col1] < matriz[fil1, col2]))
                        {
                            this.interCambio(fil1, col1, fil1, col2);
                        }
                    }
                }
            }
        }

        // Pregunta 10: ordenar las filas por el numero de elemntos primos. Previo, encontra
        // el numero de elementos primos e incluir en la matriz en la ultima columna, luego ordenar las filas por esta columna
        // Se realizara por partes:
        // primera parte: verificamos los numeros primos por fila:
        public int primosFil(int numfil)
        {
            numerosEnteros number = new numerosEnteros();
            int numPrim = 0;
            for(int col = 1; col <= this.colum; col++)
            {
                number.cargarDatos(matriz[numfil, col]);
                if(number.verifPrimo() == true)
                {
                    numPrim++;
                }
            }
            return numPrim;
        }

        // segunda parte: usamos la funciona anterior para verificar cuantos primos 
        // hay por fila y lo ponemos en un columna adicional
        // se usara esta funcion en el llamado
        public void verifPrimFil()
        {
            for(int fil = 1; fil <= this.fila; fil++)
            {
                matriz[fil, this.colum + 1] = this.primosFil(fil);
            }
            this.colum++;
        }
        // Tercera parte: realizamos el intercambio de filas por filas
        public void intercambioFilas(int fil1, int fil2)
        {
            for (int col = 1; col <= this.colum; col++)
            {
                this.interCambio(fil1, col, fil2, col);
            }
        }

        // Cuarta parte: ordenamos fila x fila la matriz
        // se usara esta funcion para el llamado
        public void ordenFilaxFila()
        {
            for(int filpos = 1; filpos < this.fila; filpos++)
            {
                for(int fildesp = filpos + 1; fildesp <= this.fila; fildesp++)
                {
                    if(matriz[fildesp, this.colum] < matriz[filpos, this.colum])
                    {
                        this.intercambioFilas(fildesp, filpos);
                    }
                }
            }
        }

        // ---- Practico 1 segunda parte de matrices ----
        
        /* pregunta 1: Ordenar los elementos de una matriz por su frecuencia
           en el rango fi, ff, ci, cf de mayor a menor frecuencia, segun el esquema
        */
        public void segmentFrecuxRang()
        {
            int fil1, col1, fil2, col2, idx;
            for(col1 = this.colum; col1 > 1; col1--)
            {
                for(fil1 = 2; fil1 <= this.fila; fil1++)
                {
                    for(col2 = col1; col2 > 1; col2--)
                    {
                        if (col2 == col1)
                            idx = fil1;
                        else
                            idx = 2;
                        for(fil2 = idx; fil2 <= this.fila; fil2++)
                        {
                            if((frecuMatriz(matriz[fil2, col2]) > 1) && (frecuMatriz(matriz[fil1, col1]) == 1) ||
                                (frecuMatriz(matriz[fil2, col2]) > 1) && (frecuMatriz(matriz[fil1, col1]) > 1) && (matriz[fil2, col2] < matriz[fil1, col1]) ||
                                (frecuMatriz(matriz[fil2, col2]) == 1) && (frecuMatriz(matriz[fil1, col1]) == 1) && (matriz[fil2, col2] < matriz[fil1, col1]))
                            {
                                this.interCambio(fil2, col2, fil1, col1);
                            }
                        }
                    }
                }
            }
        }

        // Pregunta 2: ordenar en forma senozoidal la matriz ver esquema.
        public void matrizSnakeJake()
        {
            this.ordenExtremInferiorIzquierda();
            bool change = true;
            for(int col = 1; col <= this.colum; col++)
            {
                if(change == true)
                {
                    for(int fil1 = 1; fil1 <= this.fila; fil1++)
                    {
                        for(int fil2 = fil1 + 1; fil2 <= this.fila; fil2++)
                        {
                            if(matriz[fil1, col] < matriz[fil2, col])
                            {
                                this.interCambio(fil1, col, fil2, col);
                            }
                        }
                    }
                }
                else
                {
                    for(int fil1 = 1; fil1 <= this.fila; fil1++)
                    {
                        for(int fil2 = fil1 + 1; fil2 <= this.fila; fil2++)
                        {
                            if(matriz[fil1, col] > matriz[fil2, col])
                            {
                                this.interCambio(fil1, col, fil2, col);
                            }
                        }
                    }
                }
                change = !change;
            }
        }

        // Pregunta 3: Intercalar elementos de la matriz en fibonacci y no fibonacci
        // ordenados segun el sentido del esquema
        // Funcion auxiliar para encontrar fibonacci
        public bool veriFibo(int number)
        {
            int varfibo, varA, varB; bool answer = false;
            varA = 0; varB = 1; varfibo = 0;
            while(varfibo <= number && answer == false)
            {
                varfibo = varA + varB;
                if(varfibo == number)
                {
                    answer = true;
                }
                varA = varB; varB = varfibo;
            }
            return answer;
        }

        // realizamos la pregunta 3:
        public void interElemFibo()
        {
            int fil1, col1, fil2, col2, idx; bool change = true;
            for(fil1 = this.fila; fil1 >= 1; fil1--)
            {
                for(col1 = 1; col1 <= this.colum; col1++)
                {
                    if(change == true)
                    {
                        for(fil2 = fil1; fil2 >= 1; fil2--)
                        {
                            if (fil2 == fil1)
                                idx = col1;
                            else
                                idx = 1;
                            for(col2 = idx; col2 <= this.colum; col2++)
                            {
                                if((veriFibo(matriz[fil2, col2])) && !(veriFibo(matriz[fil1, col1])) ||
                                    (veriFibo(matriz[fil2, col2])) && (veriFibo(matriz[fil1, col1])) && (matriz[fil2, col2] < matriz[fil1, col1]) ||
                                    !(veriFibo(matriz[fil2, col2])) && !(veriFibo(matriz[fil1, col1])) && (matriz[fil2, col2] < matriz[fil1, col1]))
                                {
                                    this.interCambio(fil2, col2, fil1, col1);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (fil2 = fil1; fil2 >= 1; fil2--)
                        {
                            if (fil2 == fil1)
                                idx = col1;
                            else
                                idx = 1;
                            for (col2 = idx; col2 <= this.colum; col2++)
                            {
                                if (!(veriFibo(matriz[fil2, col2])) && (veriFibo(matriz[fil1, col1])) ||
                                    !(veriFibo(matriz[fil2, col2])) && !(veriFibo(matriz[fil1, col1])) && (matriz[fil2, col2] < matriz[fil1, col1]) ||
                                    (veriFibo(matriz[fil2, col2])) && (veriFibo(matriz[fil1, col1])) && (matriz[fil2, col2] < matriz[fil1, col1]))
                                {
                                    this.interCambio(fil2, col2, fil1, col1);
                                }
                            }
                        }
                    }
                    change = !change;
                }
            }
        }


        // Pregunta 4: Ordenar la triangular como se muestra en el ejemplo 
        public void ordenTriangSuperior()
        {
            int fil1, col1, fil2, col2, idx;

            for(fil1 = 1; fil1 < this.fila; fil1++)
            {
                for(col1 = fil1 + 1; col1 <= this.colum; col1++)
                {
                    for(fil2 = fil1; fil2 < this.fila; fil2++)
                    {
                        if (fil2 == fil1)
                            idx = col1;
                        else
                            idx = fil2 + 1;
                        for(col2 = idx; col2 <= this.colum; col2++)
                        {
                            if (matriz[fil2, col2] < matriz[fil1, col1])
                            {
                                this.interCambio(fil2, col2, fil1, col1);
                            }
                        }                       
                    }
                }
            }
        }
        // Pregunta 5: Segmentar en pares e impares la triangular como muestra el ejemplo:
        public void segmentarMatrizParImpar()
        {
            numerosEnteros number1 = new numerosEnteros();
            numerosEnteros number2 = new numerosEnteros();

            int filpos, colpos, fildesp, coldesp;
            for(colpos = 2; colpos <= this.colum; colpos++)
            {
                for(filpos = this.fila; filpos >= (this.fila + 2) - colpos; filpos--)
                {
                    for(coldesp = colpos; coldesp <= this.colum; coldesp++)
                    {
                        for(fildesp = filpos; fildesp >= (this.fila + 2) - coldesp; fildesp--)
                        {
                            number1.cargarDatos(matriz[filpos, colpos]);
                            number2.cargarDatos(matriz[fildesp, coldesp]);

                            if(!(number1.verifcarPar()) && (number2.verifcarPar()) || 
                                !(number1.verifcarPar()) && !(number2.verifcarPar()) && (matriz[fildesp, coldesp] < matriz[filpos, colpos]) ||
                                (number1.verifcarPar()) && (number2.verifcarPar()) && (matriz[fildesp, coldesp] < matriz[filpos, colpos]))
                                {
                                    this.interCambio(fildesp, coldesp, filpos, colpos);
                                }
                        }
                    }
                }
            } 
        }

        // Pregunta 6: ordenar la diagonal segundaria como se muestra en el ejemplo
        public void ordenDiagonalSegun()
        {
            int fil1, col1, fil2, col2;
            fil1 = 1; col1 = this.colum;
            while((fil1 <= this.fila) && (col1 >= 1))
            {
                fil2 = fil1; col2 = col1;
                while((fil2 <= this.fila) && (col2 >= 1))
                {
                    if(matriz[fil2, col2] < matriz[fil1, col1])
                    {
                        this.interCambio(fil2, col2, fil1, col1);
                    }
                    fil2++; col2--;
                }
                fil1++; col1--;
            }
        }

        // pregunta 7: Encontrar el elemento mayor de cada fila de la triangular incluyendo la diagonal
        // donde el resultado está en la última columna..
        // Funcion auxiliar para el elemento mayor
        public int elemMayor(int numfil)
        {
            int idx = this.colum, mayor = 0;
            for(int fil1 = 1; fil1 <= numfil; fil1++)
            {
                for(int col1 = this.colum; col1 >= idx; col1--)
                {
                    if(matriz[numfil, col1] > mayor)
                    {
                        mayor = matriz[numfil, col1];
                    }
                }
                idx--;
            }
            return mayor;
        }

        // Agregamos el elemento mayor a la columan siguiente
        public void mayorEnColum()
        {
            for(int fil = 1; fil <= this.fila; fil++)
            {
                matriz[fil, this.colum + 1] = this.elemMayor(fil);
            }
            this.colum++;
        }
    }
}
