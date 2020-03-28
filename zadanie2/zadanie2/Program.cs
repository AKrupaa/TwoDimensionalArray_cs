using System;
using System.Security.Cryptography.X509Certificates;

namespace zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            // tu utworz obiekt klasy implementujacej tablicę dwuwymiarową do przechowywania liczb typu int
            // w argumencie konstruktora podaj rozmiar (czy moze byc to macierz ??)
            Array array = new Array(2, 2);

            // subscribe
            // I am creating a delegate (pointer) to HandleSomethingHappened
            // and adding it to myDelegate's list of "Event Handlers".
            array.myDelegate += new Array.Delegate(array.HandleSomethingHappened);

            // zapisz w zakresie
            array[1, 1] = 11;

            // odczytaj
            Console.WriteLine(array[1, 1]);

            // odczytaj spoza zakresu - zlap wyjatek
            try
            {
                Console.WriteLine(array[2,2]);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // zapisz poza zakresem
            array[2, 2] = 22;

            // wypisz dana liczbe (jeszcze kiedys poza zakresem)
            Console.WriteLine(array[2, 2]);
            //brawo.
        }
    }
}
