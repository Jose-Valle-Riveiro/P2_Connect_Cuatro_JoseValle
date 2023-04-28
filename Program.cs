using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Connect_Cuatro_JoseValle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Juego j = new Juego();

            bool Regresar = true;
            string S = " ";


            while (Regresar == true)
            {
                Console.Clear();
                menu.ImprimirMenu();

                menu.Opciones();
                Console.WriteLine("DESEA REGRESAR AL MENU?" + "\t" + "ESCRIBA (S) o (N) ");
                S = Console.ReadLine();
                if (S.ToLower() == "s")
                {
                    Regresar = true;
                }
                else if (S.ToLower() == "n")
                {
                    Regresar = false;
                }
                else
                {
                    Console.WriteLine("ERROR: ESCRIBA (S) O (N)");
                    Regresar = false;
                }
            }
        }
    }
}
