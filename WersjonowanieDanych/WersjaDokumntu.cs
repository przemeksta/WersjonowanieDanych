using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WersjonowanieDanych
{
    public class WersjaDokumntu
    {
        private Random zmienna;
        private int liczba;
        private int wersja;

        public WersjaDokumntu()
        {
            zmienna = new Random();
            liczba = 0;
            wersja = 0;
        }
        public int Losowanie(int minS, int maxS)
        {
            liczba = zmienna.Next(minS, maxS);
            if (liczba < 41) wersja = 1;
            else if (liczba < 61) wersja = 2;
            else if (liczba < 71) wersja = 3;
            else if (liczba < 79) wersja = 4;
            else if (liczba < 85) wersja = 5;
            else if (liczba < 90) wersja = 6;
            else if (liczba < 94) wersja = 7;
            else if (liczba < 97) wersja = 8;
            else if (liczba < 99) wersja = 9;
            else wersja = 10;
            return wersja;
        }
    }
}