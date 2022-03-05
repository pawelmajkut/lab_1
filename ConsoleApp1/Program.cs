using System;

namespace ConsoleApp1
{
    class Ulamek
    {
        // test
        //ddd

        private int licznik { get; set; }
        private int mianownik { get; set; }


        public Ulamek()
        {
            
        }

        public Ulamek(Ulamek previousUlamek)
        {
            if (mianownik == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.", nameof(mianownik));
            }
            licznik = previousUlamek.licznik;
            mianownik = previousUlamek.mianownik;
        }

        public Ulamek(int licznik, int mianownik)
        {
            this.licznik = licznik;
            this.mianownik = mianownik;
        }


        public static Ulamek operator +(Ulamek a) => a;
        public static Ulamek operator -(Ulamek a) => new Ulamek(-a.licznik, a.mianownik);

        public static Ulamek operator +(Ulamek a, Ulamek b)
            => new Ulamek(a.licznik * b.mianownik + b.licznik * a.mianownik, a.mianownik * b.mianownik);

        public static Ulamek operator -(Ulamek a, Ulamek b)
            => a + (-b);

        public static Ulamek operator *(Ulamek a, Ulamek b)
            => new Ulamek(a.licznik * b.licznik, a.mianownik * b.mianownik);

        public static Ulamek operator /(Ulamek a, Ulamek b)
        {
            if (b.licznik == 0)
            {
                throw new DivideByZeroException();
            }
            return new Ulamek(a.licznik * b.mianownik, a.mianownik * b.licznik);
        }


        static void Main(string[] args)
        {
            var a = new Ulamek(5, 4);
            var b = new Ulamek(1, 2);
            Console.WriteLine(-a);   // output: -5 / 4
            Console.WriteLine(a + b);  // output: 14 / 8
            Console.WriteLine(a - b);  // output: 6 / 8
            Console.WriteLine(a * b);  // output: 5 / 8
            Console.WriteLine(a / b);  // output: 10 / 4
        }

        public override string ToString() => $"{licznik} / {mianownik}";
        



    }
}
