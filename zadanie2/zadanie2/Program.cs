using System;

namespace zadanie2
{
    class Program
    {
        // POPRAWKA WNIESIONA @ 10-04
        // zakomentowano starego delegata bez parametrów
        // utworzono nowego, globalnego delegata z parametrami
        // przypisanie do nowego delegata z parametrami metody statycznej w Program.cs
        // metoda przypisana jest do eventu w Array.cs

        public static void CallWhenChanged(int actualRowLenght, int actualColumnLenght)
        {
            Console.WriteLine("Size extended!");
            Console.WriteLine("Actual size of array: [" + actualRowLenght + ", " + actualColumnLenght + "]");
        }

        static void Main(string[] args)
        {
            // tu utworz obiekt klasy implementujacej tablicę dwuwymiarową do przechowywania liczb typu int
            // w argumencie konstruktora podaj rozmiar (czy moze byc to macierz ??)
            Array array = new Array(2, 2);

            // POPRAWKA WNIESIONA @ 10-04
            // subscribe
            // I am creating a delegate (pointer) to HandleSomethingHappened
            // and adding it to myDelegate's list of "Event Handlers".
            //array.MyDelegate += new Array.Delegate(array.HandleSomethingHappened);

            array.delegateWithParams += new DelegateWithParams(CallWhenChanged);

            // zapisz w zakresie
            array[1, 1] = 11;

            // odczytaj
            Console.WriteLine(array[1, 1]);

            // odczytaj spoza zakresu - zlap wyjatek
            try
            {
                Console.WriteLine(array[2, 2]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // zapisz poza zakresem
            array[7, 19] = 719;

            // wypisz dana liczbe (jeszcze kiedys poza zakresem)
            Console.WriteLine(array[7, 19]);
            //brawo.
        }
    }
}
