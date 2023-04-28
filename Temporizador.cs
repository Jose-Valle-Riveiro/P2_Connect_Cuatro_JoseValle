using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace P2_Connect_Cuatro_JoseValle
{
    internal class Temporizador
    {
        public static Stopwatch tiempo = new Stopwatch();
        public static void CronometroCero()
        {
            ///////////////////////////////
            // INICIA A CONTAR EL TIEMPO //
            ///////////////////////////////
            tiempo = new Stopwatch();
            tiempo.Start();
        }
        public static string CronometroF()
        {
            ///////////////////////////////////////////////////////
            // DEJA DE CONTAR EL TIEMPO Y LO DEVUELVE COMO TEXTO //
            ///////////////////////////////////////////////////////

            tiempo.Stop();

            TimeSpan Lapso = tiempo.Elapsed;

            string TiempoTranscurrido = Lapso.ToString("mm':'ss");

            return TiempoTranscurrido;
        }
    }
}