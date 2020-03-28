using System;
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
        private const int defaultCapacity = 2;

        // string showing actual size of array
        private string typeCastingSizeOfArray = "";


        // https://www.youtube.com/watch?v=TdiN18PR4zk
        // https://stackoverflow.com/questions/803242/understanding-events-and-event-handlers-in-c-sharp
        // This delegate can be used to point to methods
        // which return void and take no param.
        public delegate void Delegate();

        // This event can cause any method which conforms
        // to Delegate to be called.
        public event Delegate MyDelegate;

        //Tablica posiada zdarzenie (event), które jest wywoływane w momencie jej rozszerzenia.
        //Argumentem jest aktualny rozmiar.
        public void HandleSomethingHappened()
        {
            typeCastingSizeOfArray = "[" + rowLenght + "," + columnLenght + "]";
            Console.WriteLine("Actual size: " + typeCastingSizeOfArray);
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
                    throw new Exception("Index was outside the bounds of the array");
                }
                
                // rozmiar nie jest przekroczony
                return array[row, column];
            }
            set 
            {
                // Przekroczenie rozmiaru podczas zapisu powoduje rozszerzenie tablicy do żądanego rozmiaru.
                Update(row, column, value);
            }
        }

        // Przypisuje wartosc w zakresie tablicy lub rozszerza rozmiar tablicy i przypisuje wartosc
        private void Update(int row, int column, int value)
        {
            // jezeli rozmiar przekroczony
            // rowLenght = 10; columnLenght = 10; 
            // to można jedynie odczytac array[9, 9]
            if (row >= rowLenght || column >= columnLenght)
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
                for (int cRow = 0; cRow < rowLenght; cRow++)
                {
                    for (int cColumn = 0; cColumn < columnLenght; cColumn++)
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

                // In this case we INVOKE the Delegate
                // it mean that he RISE a signal to others, that something happened
                //if (MyDelegate != null)
                //    MyDelegate();

                //krotszy zapis \/
                MyDelegate?.Invoke();

                // do odpowiedniej komorki array (rozszerzonej, teraz: oryginalnej) wpisz wartosc pobraną
                // instrukcja dla -> nie jest przekroczony :)
            }

            // jezeli rozmiar nie jest przekroczony
            // to do konkretnej komorki wpisz pobrana wartosc
            array[row, column] = value;
        }
    }
}
