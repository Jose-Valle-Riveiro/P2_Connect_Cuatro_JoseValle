using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Connect_Cuatro_JoseValle
{
    internal class Menu
    {
        string nombre1, nombre2, nombreGanador;
        string[] nombres = new string[10];
        int[] turnosRecord = new int[10];
        string[] tiempos = new string[10];

        public void ImprimirMenu()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("\t" + "CONNECT FOUR" + "\t");
            Console.WriteLine("\t" + "Jose Valle" + "\t");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("INGRESE UNA OPCION: ");
            Console.WriteLine("1." + "\t" + "1 Jugador");
            Console.WriteLine("2." + "\t" + "2 Jugadores");
            Console.WriteLine("3. " + "\t" + "Ver records");
            Console.WriteLine("4. " + "\t" + "Salir");
            Console.WriteLine("---------------------------------");
        }



        public void Opciones()
        {
            Juego j = new Juego();

            bool NumCorrecto = false;
            int opcion = 0;


            do
            {
                try
                {



                    opcion = Convert.ToInt32(Console.ReadLine());


                    if (opcion >= 1 && opcion < 5)
                    {
                        switch (opcion)
                        {

                            case 1:
                                Menu2();
                                ///////////////////////
                                /// INICIA EL JUEGO ///
                                ///////////////////////
                                Console.Clear();
                                bool seguir = true;
                                bool opcionCorrecta = false;
                                string opcionS = "";
                                int Ganador = 0;
                                int turnos = 0;
                                string tiempo = "";
                                do
                                {

                                    Ganador = j.TableroMaquina(ref turnos, ref tiempo);

                                    /// VALIDAR LA OPCION ///

                                    while (opcionCorrecta == false)
                                    {

                                        opcionS = "";
                                        Console.WriteLine("¿DESEA CONTINUAR?" + "\t" + "ESCRIBA (S) o (N) ");
                                        opcionS = Console.ReadLine();


                                        if (opcionS.ToLower() == "s")
                                        {
                                            opcionCorrecta = true;
                                            seguir = true;
                                        }
                                        else if (opcionS.ToLower() == "n")
                                        {
                                            opcionCorrecta = true;
                                            seguir = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("ERROR: ESCRIBA (S) O (N)");
                                            opcionCorrecta = false;
                                        }
                                    }
                                    Console.Clear();

                                } while (seguir == true);

                                if (Ganador == 1)
                                {
                                    Console.WriteLine("GANO: " + nombre1);


                                    nombreGanador = nombre1;

                                    RankingTurnos(turnos);
                                    RankingTiempos(tiempo);
                                    Ranking();
                                }

                                break;

                            case 2:
                                Menu1();
                                ///////////////////////
                                /// INICIA EL JUEGO ///
                                ///////////////////////
                                Console.Clear();
                                seguir = true;
                                opcionCorrecta = false;
                                turnos = 0;
                                Ganador = 0;
                                tiempo = "";
                                do
                                {

                                    Ganador = j.Tablero(ref turnos, ref tiempo);

                                    /// VALIDAR LA OPCION ///

                                    opcionCorrecta = false;
                                    while (opcionCorrecta == false)
                                    {
                                        opcionS = "";
                                        Console.WriteLine("¿DESEA CONTINUAR?" + "\t" + "ESCRIBA (S) o (N) ");
                                        opcionS = Console.ReadLine();


                                        if (opcionS.ToLower() == "s")
                                        {
                                            opcionCorrecta = true;
                                            seguir = true;
                                        }
                                        else if (opcionS.ToLower() == "n")
                                        {
                                            opcionCorrecta = true;
                                            seguir = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("ERROR: ESCRIBA (S) O (N)");
                                            opcionCorrecta = false;
                                        }
                                    }
                                    Console.Clear();

                                } while (seguir == true);

                                if (Ganador == 1)
                                {
                                    Console.WriteLine("GANO: " + nombre1);

                                    //ALMACENAR TODOS LOS DATOS DE LA PARTIDA
                                    nombreGanador = nombre1;
                                    Ranking();
                                    RankingTurnos(turnos);
                                    RankingTiempos(tiempo);
                                }
                                if (Ganador == 2)
                                {
                                    Console.WriteLine("GANO: " + nombre2);
                                    nombreGanador = nombre2;
                                    Ranking();
                                    RankingTurnos(turnos);
                                    RankingTiempos(tiempo);
                                }
                                if (Ganador == 0)
                                {
                                    Console.WriteLine("EMPATE");
                                }

                                break;

                            case 3:
                                Console.Clear();
                                EscribirRanking();
                                break;

                            case 4:

                                break;

                        }
                        NumCorrecto = true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: INGRESE UN NUMERO VALIDO (DEL 1 AL 4)");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: INGRESE UN NUMERO VALIDO (DEL 1 AL 4)");

                }

            } while (NumCorrecto == false);
        }

        public void Menu1()
        {
            Juego j = new Juego();
            Console.Clear();
            bool stringvalido = false;

            //////////////////////////////////////
            /// PEDIR NOMBRES DE LOS JUGADORES ///
            //////////////////////////////////////

            /// NO SE PUEDE LLAMAR COMPUTADORA ///

            string Nombre1;
            do
            {
                Console.WriteLine("INGRESE EL NOMBRE DEL JUGADOR 1");
                Nombre1 = Console.ReadLine();


                if (Nombre1.ToLower() == "computadora")
                {
                    Console.WriteLine("AVISO: NO PUEDE LLAMARSE (COMPUTADORA)");
                    Console.ReadKey();
                    Console.Clear();

                }
                else
                {
                    stringvalido = true;
                }
            } while (stringvalido == false);

            nombre1 = Nombre1; //IGUALAR EL PARAMETRO PARA FUTUROS PROCESOS
            stringvalido = false;

            string Nombre2;
            do
            {
                Console.WriteLine("INGRESE EL NOMBRE DEL JUGADOR 2");
                Nombre2 = Console.ReadLine();


                if (Nombre2.ToLower() == "computadora")
                {
                    Console.WriteLine("AVISO: NO PUEDE LLAMARSE (COMPUTADORA)");
                    Console.ReadKey();
                    Console.Clear();

                }
                else
                {
                    stringvalido = true;
                }
            } while (stringvalido == false);
            nombre2 = Nombre2;


        }

        public void Menu2()
        {
            Juego j = new Juego();
            Console.Clear();
            bool stringvalido = false;

            //////////////////////////////////////
            /// PEDIR NOMBRES DE LOS JUGADORES ///
            //////////////////////////////////////

            /// NO SE PUEDE LLAMAR COMPUTADORA ///

            string Nombre1;
            do
            {
                Console.WriteLine("INGRESE EL NOMBRE DEL JUGADOR 1");
                Nombre1 = Console.ReadLine();


                if (Nombre1.ToLower() == "computadora")
                {
                    Console.WriteLine("AVISO: NO PUEDE LLAMARSE (COMPUTADORA)");
                    Console.ReadKey();
                    Console.Clear();

                }
                else
                {
                    stringvalido = true;
                }
            } while (stringvalido == false);

            nombre1 = Nombre1; //IGUALAR EL PARAMETRO PARA FUTUROS PROCESOS
            stringvalido = false;


        }
        public void Ranking()
        {

            //APLAZAR LOS NOMBRES ANTERIORES//
            nombres[9] = nombres[8];
            nombres[8] = nombres[7];
            nombres[7] = nombres[6];
            nombres[6] = nombres[5];
            nombres[5] = nombres[4];
            nombres[4] = nombres[3];
            nombres[3] = nombres[2];
            nombres[2] = nombres[1];
            nombres[1] = nombres[0];


            //INGRESAR EL NOMBRE MAS NUEVO//
            nombres[0] = nombreGanador;


        }

        public void RankingTurnos(int turnoGanador)
        {
            ////////////////////////////////////
            /// RANKING PERO PARA LOS TURNOS ///
            ////////////////////////////////////


            //APLAZAR LOS NOMBRES ANTERIORES//
            turnosRecord[9] = turnosRecord[8];
            turnosRecord[8] = turnosRecord[7];
            turnosRecord[7] = turnosRecord[6];
            turnosRecord[6] = turnosRecord[5];
            turnosRecord[5] = turnosRecord[4];
            turnosRecord[4] = turnosRecord[3];
            turnosRecord[3] = turnosRecord[2];
            turnosRecord[2] = turnosRecord[1];
            turnosRecord[1] = turnosRecord[0];


            //INGRESAR EL NOMBRE MAS NUEVO//
            turnosRecord[0] = turnoGanador;


        }

        public void RankingTiempos(string TiempoGanador)
        {
            ////////////////////////////////////
            /// RANKING PERO PARA LOS TURNOS ///
            ////////////////////////////////////


            //APLAZAR LOS NOMBRES ANTERIORES//
            tiempos[9] = tiempos[8];
            tiempos[8] = tiempos[7];
            tiempos[7] = tiempos[6];
            tiempos[6] = tiempos[5];
            tiempos[5] = tiempos[4];
            tiempos[4] = tiempos[3];
            tiempos[3] = tiempos[2];
            tiempos[2] = tiempos[1];
            tiempos[1] = tiempos[0];


            //INGRESAR EL NOMBRE MAS NUEVO//
            tiempos[0] = TiempoGanador;


        }


        public void EscribirRanking()
        {
            Console.WriteLine("--------- JUGADORES RECIENTES --------- ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("TOP " + (i + 1) + "\t" + nombres[i] + "\t" + "TURNOS: " + turnosRecord[i] + "\t" + "TIEMPO: " + tiempos[i]);
            }
            Console.WriteLine("--------------------------------------- ");
        }
    }
}
