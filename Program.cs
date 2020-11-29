using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA201124
{
    struct Utasketegoria
    {
        public string Nev;
        public short Tulelok;
        public short Eltuntek;

        public Utasketegoria(string nev, short tulelok, short eltuntek)
        {
            this.Nev = nev;
            this.Tulelok = tulelok;
            this.Eltuntek = eltuntek;
        }
    }
    class Program
    {
        static List<Utasketegoria> kategoriak = new List<Utasketegoria>();
        static void Main()
        {
            F1();
            F2();
            F3();
            string kszo = F4();
            F5(kszo);
            F6();
            F7();
            Console.ReadKey();
        }

        private static void F7()
        {
            int maxi = 0;
            for (int i = 1; i < kategoriak.Count; i++)
            {
                if (kategoriak[i].Tulelok > kategoriak[maxi].Tulelok) maxi = i;
            }
            Console.WriteLine($"7. feladat: {kategoriak[maxi].Nev}");
        }

        private static void F6()
        {
            Console.WriteLine("6. feladat:");
            foreach (var k in kategoriak)
            {
                if (k.Eltuntek > k.Tulelok * 0.6) Console.WriteLine($"\t{k.Nev}");
            }
        }

        private static void F5(string kszo)
        {
            Dictionary<string, int> letszam = new Dictionary<string, int>();
            foreach (var k in kategoriak)
            {
                if (k.Nev.Contains(kszo))
                {
                    letszam.Add(k.Nev, k.Tulelok);
                }
            }
            if (letszam.Count > 0)
            {
                Console.WriteLine("5. feladat:");
                foreach (var l in letszam)
                {
                    Console.WriteLine($"\t{l.Key} {l.Value} fő");
                }
            }
        }

        private static string F4()
        {
            Console.Write("4. feladat: Kulcsszó: ");
            string kszo = Console.ReadLine();
            int i = 0;
            while (i < kategoriak.Count && !kategoriak[i].Nev.Contains(kszo))
            {
                i++;
            }
            if (i < kategoriak.Count) Console.WriteLine("\tVan találat!");
            else Console.WriteLine("\tNincs találat!");
            return kszo;
        }

        private static void F3()
        {
            int s = 0;
            foreach (var k in kategoriak)
            {
                s += k.Eltuntek + k.Tulelok;
            }
            Console.WriteLine($"3. feladat: {s} fő");
        }

        private static void F2()
        {
            Console.WriteLine($"2. feladat: {kategoriak.Count} db");
        }

        private static void F1()
        {
            var sr = new StreamReader(@"..\..\Res\titanic.txt");
            while (!sr.EndOfStream)
            {
                var tmp = sr.ReadLine().Split(';');
                kategoriak.Add(new Utasketegoria(tmp[0], short.Parse(tmp[1]), short.Parse(tmp[1])));
            }
            sr.Close();
        }
    }
}
