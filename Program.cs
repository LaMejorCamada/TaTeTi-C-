using System;


namespace TaTeTi
{
    class Program
    {
        static void Main(string[] args)

        {   
            
            TaTeTi juego = new TaTeTi();
            Robot hole = new Robot();
            hole.saludar();

            juego.starGame();

        }
    }

    
    class TaTeTi
    {       
        string[] tablero = new string[9];
        bool continuePlaying= true;
        int turno = 0;


            public void starGame()
            {   
                Console.WriteLine("Bienvenido al TaTeTi. ");
                modoDeJuego();
            }  

            private void modoDeJuego(){
                Console.WriteLine("Elija su modo de juego por favor no me haga esperar: ");
                Console.WriteLine("Opcion 1: Dos jugadores ");
                Console.WriteLine("Opcion 2: Contra la maquina ");
                string opcion = Console.ReadLine();
                if(opcion == "1" || opcion == "2"){
                    if(opcion == "1"){
                        dosJugadores();
                    }
                    else{
                        Robot robot = new Robot();
                        robot.maquina(tablero, continuePlaying);
                    }
                }
            }

            private void dosJugadores(){
                inicializarTablero();
                imprimirTablero();
                while(continuePlaying)
                {
                    ingresarNumero();
                    if(turno == 9 && continuePlaying)
                    {
                        reiniciarJuego();
                    }
                }

            }
            private void ingresarNumero()
            {
                string quienEstaJugando;
                if(turno % 2 == 0)
                {
                    Console.WriteLine("Marca jugador 1.");
                    quienEstaJugando = "X";
                }
                else
                {
                    Console.WriteLine("Marca jugador 2.");
                    quienEstaJugando = "O";
                }
                turno+=1;

                pedirPosicion(quienEstaJugando);

                imprimirTablero();
            }



           private void pedirPosicion(string jugador)
           {
                Console.WriteLine("Ingrese en posicion: ");  
                string posicion = Console.ReadLine();
                int valor;
                bool parsed = int.TryParse(posicion, out (valor));
                if(validarRango(valor - 1) && validarPosicion(valor - 1) && (parsed)){
                    tablero[valor - 1] = jugador;
                    ganoAlguien();
                    if(!continuePlaying)
                    {   
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"ELL GANADOOR ESSS: (PUM PUM PUM PUM PUM) ");
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine($"                  {jugador}                       ");
                        Console.WriteLine("---------------------------------------------------");
                        Console.ResetColor();
                    }
                    
                }
                else
                {   
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("Valor ingresado no es valido, porfavor ingrese nuevamente. ");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.ResetColor();

                    pedirPosicion(jugador);
                }
                
           }

           private bool validarRango(int posicion){
               return posicion >=0  && posicion <= 8; 
           }

           private bool validarPosicion(int posicion){
               return !(tablero[posicion] == "X" || tablero[posicion] == "O");
           }
           private void imprimirTablero()
           {
               Console.WriteLine("Tablero Fruta: ");
               Console.WriteLine("");

               for(int i = 0; i < 8; i += 3)
                {
                Console.WriteLine(tablero[i] + "|" + tablero[i + 1] + "|" + tablero[i + 2]);
                }
           }

           private void inicializarTablero()
           {
                for(int i = 0; i < tablero.Length; i++)
                {
                    tablero[i] = (i + 1).ToString() ;
                }
           }

           private void ganoAlguien()
           {
        
            if (esLinea(1, 2, 3, "O")) // Horizontal ----------------------------------------
            {
                continuePlaying = false;
            }

            if (esLinea(4, 5, 6, "O"))
            {
                continuePlaying = false;
            }
            if (esLinea(7, 8, 9, "O"))
            {
                continuePlaying = false;
            }

            if(esLinea(1, 5, 9, "O")) // Diagonal -----------------------------------------
            {
                continuePlaying = false;
            }
            if(esLinea(7, 5, 3, "O"))
            {
                continuePlaying = false;
            }

            if(esLinea(1, 4, 7, "O"))// Coloumna  ------------------------------------------
            {
                continuePlaying = false;
            }
            if(esLinea(2, 5, 8, "O"))
            {
                continuePlaying = false;
            }
            if(esLinea(3, 6, 9, "O"))
            {
                continuePlaying = false;
            }

            if(esLinea(1, 2, 3, "X")) // Horizontal ----------------------------------------
            {
                continuePlaying = false;
            }
            if(esLinea(4, 5, 6, "X"))
            {
                continuePlaying = false;
            }   
            if(esLinea(7, 8, 9, "X"))
            {
                continuePlaying = false;
            }

            if(esLinea(1, 5, 9, "X")) // Diagonal -----------------------------------------
            {
                continuePlaying = false;
            }
            if(esLinea(7, 5, 3, "X"))
            {
                continuePlaying = false;
            }

            if(esLinea(1, 4, 7, "X")) // Coloumna ------------------------------------------
            {
                continuePlaying = false;
            }
            if(esLinea(2, 5, 8, "X"))
            {
                continuePlaying = false;
            }
            if(esLinea(3, 6, 9, "X"))
            {
                continuePlaying = false;
            }
            
        }
           

            private bool esLinea(int index0, int index1, int index2, string jugador)
            {
                return tablero[index0 - 1] == jugador && tablero[index1 - 1] == jugador && tablero[index2 - 1] == jugador;
            }


            private void reiniciarJuego()
            {
                inicializarTablero();
                turno = 0;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Han empatado, jueguen nuevamente para decidir quien es el vencedor.");
                Console.ResetColor();
                imprimirTablero();
            }
    }

    class robot{
        
    }
    
}