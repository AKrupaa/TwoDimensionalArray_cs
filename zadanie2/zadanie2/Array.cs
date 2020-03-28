﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace zadanie2
{
    //Napisać klasę implementującą tablicę dwuwymiarową do przechowywania liczb typu int.
    class Array : ITwoDimensionalArray
    {
        //Tablica posiada właściwość tylko do odczytu zwracającą jej rozmiar.
        private int rowLenght;
        //Tablica posiada właściwość tylko do odczytu zwracającą jej rozmiar.
        private int columnLenght;
        private int[,] array;
        private const int defaultCapacity = 10;

        string typeCastingSizeOfArray = "";

        //Tablica posiada zdarzenie (event), które jest wywoływane w momencie jej rozszerzenia.
        //Argumentem jest aktualny rozmiar.
        public void HandleSomethingHappened()
        {
            typeCastingSizeOfArray = "[" + rowLenght + "," + columnLenght + "]";
            Console.WriteLine("Actual size:" + typeCastingSizeOfArray);
        }

        //W momencie utworzenia podawany jest rozmiar.
        //dodałem standardowy rozmiar, a co.
        public Array(int row = defaultCapacity, int column = defaultCapacity)
        {
            rowLenght = row;
            columnLenght = column;
            array = new int[rowLenght, columnLenght];
        }

        //Tablica posiada indeksator do zapisu i odczytu.
        public int this[int row, int column] 
        {
            //- Przekroczenie rozmiaru podczas odczytu powoduje rzucenie wyjątku.
            get
            {
                if (row >= rowLenght || column >= columnLenght)
                {
                    //rozmiar przekroczony -> rzuc wyjatek
                    throw new Exception("Out of array size");
                }
                
                // rozmiar nie jest przekroczony
                return array[row, column];
            }
            set 
            {
                // jezeli rozmiar przekroczony
                // rowLenght = 10; columnLenght = 10; 
                // to można jedynie odczytac array[9, 9]
                if(row >= rowLenght || column >= columnLenght)
                {

                    // zastap nieaktualne długości aktualnymi wartościami
                    // row i column posiada docelowe miejsce wpisania wartosci
                    int rowExtended = rowLenght;
                    int columnExtended = columnLenght;
                    if (row >= rowLenght)
                        rowExtended = row + 1;
                    if (column >= columnLenght)
                        columnExtended = column + 1;

                    // utworz tymczasowa najwieksza tablice;
                    int[,] newArray = new int[rowExtended, columnExtended];

                    // skopiuj wszystkie wartosci ze starej (oryginalnej, malej) do (wiekszej) wszystkie jej wartosci
                    for(int cRow = 0; cRow < rowLenght; cRow ++)
                    {
                        for(int cColumn = 0; cColumn < columnLenght; cColumn++)
                        {
                            // skopiuj wartosci z Array (oryginal) do newArray (kopia najwieksza tablica)
                            newArray[cRow, cColumn] = array[cRow, cColumn];
                        }
                    }

                    // przypisz do array (oryginal) rozszerzona tablice newArray (kopie)
                    array = newArray;
                    // zaaktualizuj rozmiary
                    rowLenght = rowExtended;
                    columnLenght = columnExtended;

                    // do odpowiedniej komorki array (rozszerzonej, oryginalnej) wpisz wartosc pobraną
                    // instrukcja dla -> nie jest przekroczony :)
                }

            // jezeli rozmiar nie jest przekroczony
            // to do konkretnej komorki wpisz pobrana wartosc
            array [row, column] = value;
            }
        }
    }
}