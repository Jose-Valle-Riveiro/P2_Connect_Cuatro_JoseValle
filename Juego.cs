using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Connect_Cuatro_JoseValle
{
    internal class Juego
    {
        int[,] tablero = new int[6, 7];
        int[,] tableroRegistro = new int[6, 7];

        public void EscribirTablero()
        {
            /*
             * /////////////////////////////////////////////////////////////////////////////////////
             * /////////EXISTEN TRES POSIBLES ESTADOS QUE LA MATRIZ PARAMETRO PUEDE ADOPTAR/////////
             * /////////////////////////////////////////////////////////////////////////////////////
             * /// 0 = NO HAY NINGUNA FICHA (SE GRAFICA COMO [.])  /////////////////////////////////
             * /// 1 = FICHA DEL JUGADOR UNO (SE GRAFICA COMO [x]) /////////////////////////////////
             * /// 2 = FICHA DEL JUGADOR DOS (SE GRAFICA COMO [O]) /////////////////////////////////
             * /////////////////////////////////////////////////////////////////////////////////////
             */
            int valor;
            char signo = 'O';
            //ESCRIBIR TABLERO
            Console.WriteLine("-1-" + "\t" + "-2-" + "\t" + "-3-" + "\t" + "-4-" + "\t" + "-5-" + "\t" + "-6-" + "\t" + "-7-");
            for (int f = 0; f < 6; f++)
            {
                for (int c = 0; c < 7; c++)
                {
                    valor = tablero[f, c];
                    if (valor == 0)
                    {
                        signo = '.';
                    }
                    if (valor == 1)
                    {
                        signo = 'X';
                    }
                    if (valor == 2)
                    {
                        signo = 'O';
                    }

                    Console.Write("[" + signo + "]" + "\t");
                }
                Console.WriteLine();
            }

        }



        public void turno1()
        {
            Menu m = new Menu();
            //Turno 1




            bool NumCorrecto = false;
            int turno1 = 0;
            ////////////////////////////
            /////DETERMINAR COLUMNA/////
            ///////////////////////////

            //VERIFICACION DE ERRORES//
            do
            {
                try
                {
                    //////// INGRESAR VALOR ////////

                    Console.WriteLine("JUGADOR 1:");
                    Console.WriteLine("INGRESE EL NUMERO DE COLUMNA PARA INGRESAR LA FICHA");
                    turno1 = Convert.ToInt32(Console.ReadLine());


                    if (turno1 >= 1 && turno1 < 8)
                    {
                        NumCorrecto = true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: INGRESE UN NUMERO VALIDO (DEL 1 AL 7)");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: INGRESE UN NUMERO VALIDO (DEL 1 AL 7)");

                }

                //////// DETERMINAR SI LA COLUMNA ESTA LLENA ////////
                if (tablero[0, turno1 - 1] != 0)
                {
                    Console.WriteLine("LA COLUMNA ESTA LLENA: INGRESE SU FICHA EN OTRO LADO");
                    NumCorrecto = false;
                }

            } while (NumCorrecto == false);




            /////////////////////////
            /////DETERMINAR FILA/////
            ////////////////////////
            int numFila = 0;
            for (int i = 0; i < 6; i++)
            {
                //Si detecta una ficha ocupada se ocupa el valor de arriba
                if (tablero[i, (turno1 - 1)] != 0)
                {
                    numFila = i - 1;
                    break;

                }
                else if (i == 5)
                {
                    //Si llega hasta el fondo simplemente ocupara ese espacio
                    numFila = 5;
                    break;

                }

            }

            tablero[numFila, (turno1 - 1)] = 1;
        }

        public void turno2()
        {
            Menu m = new Menu();
            //Turno 2
            //DETERMINAR COLUMNA


            bool NumCorrecto = false;
            int turno2 = 0;


            do
            {
                try
                {


                    Console.WriteLine("JUGADOR 2:");
                    Console.WriteLine("INGRESE EL NUMERO DE COLUMNA PARA INGRESAR LA FICHA");
                    turno2 = Convert.ToInt32(Console.ReadLine());


                    if (turno2 >= 1 && turno2 < 8)
                    {
                        NumCorrecto = true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: INGRESE UN NUMERO VALIDO (DEL 1 AL 7)");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: INGRESE UN NUMERO VALIDO (DEL 1 AL 7)");

                }
                //DETERMINAR SI LA COLUMNA ESTA LLENA
                if (tablero[0, turno2 - 1] != 0)
                {
                    Console.WriteLine("LA COLUMNA ESTA LLENA: INGRESE SU FICHA EN OTRO LADO");
                    NumCorrecto = false;
                }

            } while (NumCorrecto == false);


            //DETERMINAR HASTA QUE FILA CAERA
            int numFila = 0;
            for (int i = 0; i < 6; i++)
            {
                if (tablero[i, (turno2 - 1)] != 0)
                {
                    numFila = i - 1;
                    break;

                }
                else if (i == 5)
                {
                    numFila = 5;
                    break;

                }

            }

            tablero[numFila, (turno2 - 1)] = 2;
        }

        public void turnoMaquina()
        {
            /////////////////////////////////////////////////////////////////////////////////////
            ///             MISMO CODIGO QUE EN TURNO 1 Y 2, PERO SIN INTERACCION             ///
            /////////////////////////////////////////////////////////////////////////////////////
            Random rnd = new Random();
            //Turno 2
            //DETERMINAR COLUMNA


            bool NumCorrecto = false;
            int turno2 = 0;


            do
            {

                turno2 = rnd.Next(1, 8);
                NumCorrecto = true;

                //DETERMINAR SI LA COLUMNA ESTA LLENA
                if (tablero[0, turno2 - 1] != 0)
                {
                    NumCorrecto = false;
                }

            } while (NumCorrecto == false);

            //DETERMINAR HASTA QUE FILA CAERA
            int numFila = 0;
            for (int i = 0; i < 6; i++)
            {
                if (tablero[i, (turno2 - 1)] != 0)
                {
                    numFila = i - 1;
                    break;

                }
                else if (i == 5)
                {
                    numFila = 5;
                    break;

                }

            }

            tablero[numFila, (turno2 - 1)] = 2;
        }

        public bool Victoria1()
        /////////////////////////////////////////////////
        /// DETERMINAR LA VICTORIA PARA EL JUGADOR 1 ///
        ///////////////////////////////////////////////
        {
            bool victoria = false;
            int conteo = 0; /// SI EL CONTEO LLEGA A 4 SE OBTENDRA LA VICTORIA ///

            ////////////////
            ///HORIZONTAL///
            ///////////////
            for (int f = 0; f < 6; f++)
            {
                for (int c = 0; c < 7; c++)   //EXAMINARA TODA LA MATRIZ
                {
                    try
                    {
                        if (tablero[f, c] == 1) //DETECTA UNA FICHA DEL JUGADOR 1 
                        {
                            conteo = 1;
                            for (int i = 1; i < 4; i++) //INTENTA ANALIZAR LAS 4 POSICIONES CONTIGUAS, SI UNA DE ELLAS NO EQUIVALE A 1 SE ROMPE
                            {

                                if (tablero[f, c + i] == 1)
                                {

                                    conteo++;

                                }
                                else if (tablero[f, c + i] != 1)
                                {
                                    victoria = false;
                                    break;
                                }



                            }
                            if (conteo == 4)
                            {
                                victoria = true;
                                return victoria; //SI YA SE LOGRO LA VICTORIA EL CODIGO TERMINA AQUI
                            }
                            break;
                        }


                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }





                }
            }



            conteo = 0; //SE RESETEA EL CONTEO//
            ////////////////
            /// VERTICAL ///
            ///////////////
            for (int c = 0; c < 6; c++) //PRIMERO SE EVALUA LA COLUMNA
            {
                for (int f = 0; f < 7; f++) //SEGUNDO SE EVALUA LA FILA
                {
                    //EXAMINA TODA LA MATRIZ
                    try
                    {
                        if (tablero[f, c] == 1)
                        {

                            conteo = 1;

                            for (int i = 1; i < 4; ++i) //INTENTA ANALIZAR LAS 4 POSICIONES CONTIGUAS, SI UNA DE ELLAS NO EQUIVALE A UNO SE ROMPE
                            {
                                if (tablero[f + i, c] == 1)
                                {
                                    conteo++;


                                }
                                else if (tablero[f + i, c] != 1)
                                {
                                    victoria = false;
                                    break;
                                }



                            }
                            if (conteo == 4)
                            {
                                victoria = true;
                                return victoria;  //SI YA SE LOGRO LA VICTORIA EL CODIGO TERMINA AQUI
                            }
                            break;
                        }


                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }





                }
            }

            ///////////////////////////////////////////////////////
            ///DIAGONAL DE ARRIBA PARA ABAJO (IZQUIERDA DERECHA)///
            ///////////////////////////////////////////////////////

            for (int f = 0; f < 6; f++) //PRIMERO SE EVALUA LA COLUMNA
            {
                for (int c = 0; c < 7; c++) //SEGUNDO SE EVALUA LA FILA
                {

                    try
                    {
                        if (tablero[f, c] == 1)
                        {

                            conteo = 1;

                            for (int i = 1; i < 4; ++i) //INTENTA ANALIZAR LAS 4 POSICIONES CONTIGUAS, SI UNA DE ELLAS NO EQUIVALE A UNO SE ROMPE
                            {
                                if (tablero[f + i, c + i] == 1)
                                {
                                    conteo++;


                                }
                                else if (tablero[f + i, c + i] != 1)
                                {
                                    victoria = false;
                                    break;
                                }



                            }
                            if (conteo == 4)
                            {
                                victoria = true;
                                return victoria;  //SI YA SE LOGRO LA VICTORIA EL CODIGO TERMINA AQUI
                            }
                            break;
                        }


                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }





                }
            }

            ///////////////////////////////////////////////////////
            ///DIAGONAL DE ABAJO PARA ARRIBA (IZQUIERDA DERECHA)///
            ///////////////////////////////////////////////////////

            for (int f = 0; f < 6; f++) //PRIMERO SE EVALUA LA COLUMNA
            {
                for (int c = 0; c < 7; c++) //SEGUNDO SE EVALUA LA FILA
                {

                    try
                    {
                        if (tablero[f, c] == 1)
                        {

                            conteo = 1;

                            for (int i = 1; i < 4; ++i) //INTENTA ANALIZAR LAS 4 POSICIONES CONTIGUAS, SI UNA DE ELLAS NO EQUIVALE A UNO SE ROMPE
                            {
                                if (tablero[f + i, c - i] == 1)
                                {
                                    conteo++;


                                }
                                else if (tablero[f + i, c - i] != 1)
                                {
                                    victoria = false;
                                    break;
                                }



                            }
                            if (conteo == 4)
                            {
                                victoria = true;
                                return victoria;  //SI YA SE LOGRO LA VICTORIA EL CODIGO TERMINA AQUI
                            }
                            break;
                        }


                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }





                }
            }


            return victoria;
        }


        public bool Victoria2()
        //DETERMINAR LA VICTORIA PARA EL JUGADOR 2
        {
            bool victoria = false;
            int conteo = 0;
            //HORIZONTAL
            for (int f = 0; f < 6; f++)
            {
                for (int c = 0; c < 7; c++)
                {
                    try
                    {
                        if (tablero[f, c] == 2) //DETECTA UNA FICHA DEL JUGADOR 2 
                        {

                            conteo = 1;
                            for (int i = 1; i < 4; i++) //INTENTA ANALIZAR LAS 4 POSICIONES CONTIGUAS, SI UNA DE ELLAS NO EQUIVALE A 2 SE ROMPE
                            {

                                if (tablero[f, c + i] == 2)
                                {

                                    conteo++;

                                }
                                else if (tablero[f, c + i] != 2)
                                {
                                    victoria = false;
                                    break;
                                }



                            }
                            if (conteo == 4)
                            {
                                victoria = true;
                                return victoria; //SI YA SE LOGRO LA VICTORIA EL CODIGO TERMINA AQUI
                            }
                            break;
                        }


                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }





                }
            }

            if (victoria == true)
            {
                return victoria; //SI YA SE LOGRO LA VICTORIA EL CODIGO TERMINA AQUI
            }

            //VERTICAL
            for (int c = 0; c < 7; c++) //PRIMERO SE EVALUA LA COLUMNA
            {
                for (int f = 0; f < 6; f++) //SEGUNDO SE EVALUA LA FILA
                {

                    try
                    {
                        if (tablero[f, c] == 2)
                        {


                            conteo = 1;

                            for (int i = 1; i < 4; ++i) //INTENTA ANALIZAR LAS 4 POSICIONES CONTIGUAS, SI UNA DE ELLAS NO EQUIVALE A DOS SE ROMPE
                            {
                                if (tablero[f + i, c] == 2)
                                {
                                    conteo++;


                                }
                                else if (tablero[f + i, c] != 2)
                                {
                                    victoria = false;
                                    break;
                                }



                            }
                            if (conteo == 4)
                            {
                                victoria = true;
                                return victoria;  //SI YA SE LOGRO LA VICTORIA EL CODIGO TERMINA AQUI
                            }
                            break;
                        }


                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }





                }
            }

            //DIAGONAL DE ARRIBA PARA ABAJO IZQUIERDA DERECHA//

            for (int f = 0; f < 6; f++) //PRIMERO SE EVALUA LA COLUMNA
            {
                for (int c = 0; c < 7; c++) //SEGUNDO SE EVALUA LA FILA
                {

                    try
                    {
                        if (tablero[f, c] == 2)
                        {

                            conteo = 1;

                            for (int i = 1; i < 4; ++i) //INTENTA ANALIZAR LAS 4 POSICIONES CONTIGUAS, SI UNA DE ELLAS NO EQUIVALE A DOS SE ROMPE
                            {
                                if (tablero[f + i, c + i] == 2)
                                {
                                    conteo++;


                                }
                                else if (tablero[f + i, c + i] != 2)
                                {
                                    victoria = false;
                                    break;
                                }



                            }
                            if (conteo == 4)
                            {
                                victoria = true;
                                return victoria;  //SI YA SE LOGRO LA VICTORIA EL CODIGO TERMINA AQUI
                            }
                            break;
                        }


                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }





                }
            }

            //DIAGONAL DE ABAJO PARA ARRIBA DERECHA IZQUIERDA//

            for (int f = 0; f < 6; f++) //PRIMERO SE EVALUA LA COLUMNA
            {
                for (int c = 0; c < 7; c++) //SEGUNDO SE EVALUA LA FILA
                {

                    try
                    {
                        if (tablero[f, c] == 2)
                        {

                            conteo = 1;

                            for (int i = 1; i < 4; ++i) //INTENTA ANALIZAR LAS 4 POSICIONES CONTIGUAS, SI UNA DE ELLAS NO EQUIVALE A DOS SE ROMPE
                            {
                                if (tablero[f + i, c - i] == 2)
                                {
                                    conteo++;


                                }
                                else if (tablero[f + i, c - i] != 2)
                                {
                                    victoria = false;
                                    break;
                                }



                            }
                            if (conteo == 4)
                            {
                                victoria = true;
                                return victoria;  //SI YA SE LOGRO LA VICTORIA EL CODIGO TERMINA AQUI
                            }
                            break;
                        }


                    }
                    catch
                    {
                        victoria = false;
                        break;
                    }





                }
            }

            return victoria;
        }

        public bool EstaLleno()
        {
            //////////////////////////////////////////////////////////
            // * * * * * DETERMINAR SI LA MATRIZ SE LLENO * * * * * //
            //////////////////////////////////////////////////////////

            bool SeLleno = false;
            int conteo = 0; //HAY 42 FICHAS TOTALES//


            /// ANALIZAR TODA LA MATRIZ ///
            for (int f = 0; f < 6; f++)
            {
                for (int c = 0; c < 7; c++)
                {
                    if (tablero[f, c] != 0)
                    {
                        conteo++;
                    }


                }
            }
            if (conteo == 42)
            {
                SeLleno = true;
                return SeLleno;
            }
            return SeLleno;





        }
        public int Tablero(ref int turnos, ref string tiempo)
        {
            Menu m = new Menu();
            Temporizador temp = new Temporizador();

            //Inicializar el tablero en 0
            for (int f = 0; f < 6; f++)
            {
                for (int c = 0; c < 7; c++)
                {
                    tablero[f, c] = 0;
                }
            }

            EscribirTablero();

            bool victoria = false;
            bool Selleno = false;
            Temporizador.CronometroCero();

            // INICA EL JUEGO //
            while (victoria == false)
            {

                // VARAIBLES QUE AYUDARAN EN LOS RECORDS //
                turnos++; //<--------
                


                turno1();
                victoria = Victoria1();
                Selleno = EstaLleno();
                Console.Clear();
                EscribirTablero();
                if (victoria == true)
                {
                    Console.WriteLine("JUGADOR 1: GANA!!!");
                    tiempo = Temporizador.CronometroF();
                    return 1; //<------- SIRVE PARA DETERMINAR EN EL MENU QUIEN GANO
                }
                if (Selleno == true)
                {
                    Console.WriteLine("EL TABLERO ESTA LLENO: FIN DEL JUEGO!!!");
                    break;
                }


                turno2();
                victoria = Victoria2();
                Selleno = EstaLleno();
                Console.Clear();
                EscribirTablero();
                if (victoria == true)
                {
                    Console.WriteLine("JUGADOR 2: GANA!!!");
                    tiempo = Temporizador.CronometroF();
                    return 2;
                }
                if (Selleno == true)
                {
                    Console.WriteLine("EL TABLERO ESTA LLENO: FIN DEL JUEGO");
                    break;
                }

            }


            return 0;

        }

        public int TableroMaquina(ref int turnos, ref string tiempo)
        {
            Menu m = new Menu();
            


            //Inicializar el tablero en 0
            for (int f = 0; f < 6; f++)
            {
                for (int c = 0; c < 7; c++)
                {
                    tablero[f, c] = 0;
                }
            }

            EscribirTablero();

            bool victoria = false;
            Temporizador.CronometroCero();

            //INICIA EL JUEGO
            while (victoria == false)
            {
                turnos++;
                

                turno1();

                victoria = Victoria1();
                Console.Clear();
                EscribirTablero();
                if (victoria == true)
                {
                    Console.WriteLine("JUGADOR 1: GANA!!!");
                    tiempo = Temporizador.CronometroF();
                    return 1;
                }

                turnoMaquina();
                victoria = Victoria2();
                Console.Clear();
                EscribirTablero();
                if (victoria == true)
                {
                    Console.WriteLine("LA MAQUINA GANA!!!");
                    break;
                }

            }

            return 0;


        }
    }
}
