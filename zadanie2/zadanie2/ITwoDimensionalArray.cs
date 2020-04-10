using System;
using System.Collections.Generic;
using System.Text;

//Napisać klasę implementującą tablicę dwuwymiarową do przechowywania liczb typu int.

//W momencie utworzenia podawany jest rozmiar.
//Tablica posiada indeksator do zapisu i odczytu.

//- Przekroczenie rozmiaru podczas odczytu powoduje rzucenie wyjątku.

//- Przekroczenie rozmiaru podczas zapisu powoduje rozszerzenie tablicy do żądanego rozmiaru.

//Tablica posiada właściwość tylko do odczytu zwracającą jej rozmiar.
//Tablica posiada zdarzenie (event), które jest wywoływane w momencie jej rozszerzenia.
//Argumentem jest aktualny rozmiar.

namespace zadanie2
{
    interface ITwoDimensionalArray
    {
        //private int[,] twoDimensionalArray;
        // declaring Multidimensional Indexer 
        public int this[int row, int column]
        {
            // get accessor 
            // it returns the values which 
            // read the indexes 
            //return data[index1, index2];
            get;

            // set accessor 
            // write the values in 'data' 
            // using value keyword 
            //data[index1, index2] = value;
            set;
        }

        // POPRAWKA WNIESIONA @ 10-04
        //void HandleSomethingHappened();
    }
}
