using System;
using TaTeTi;


namespace TaTeTi
{
    class Robot{

        string[] tablero = new string[9];
        bool continuePlaying= true;

        public void maquina(string[] tablero, bool continuePlaying)
            {
                this.tablero = tablero;
                this.continuePlaying = continuePlaying;

                Console.WriteLine("Eliga la dificultad. ");
                Console.WriteLine("Opcion 1: Super facil. ");
                Console.WriteLine("Opcion 2: Ultra archi mega dificil. ");
            
                int opcion = Console.Read();
                if(opcion == 1 || opcion == 2){
                    if(opcion == 1){
                        //ponerFicha();
                        
                    }
                    else{
                        //Implementar
                    }
                }
            }


            private void ponerFicha(string [] tablero)
            {   
                Random random = new Random();
                int valor = random.Next(1,9);
                
                if(tablero[valor-1] == "X" || tablero[valor-1] == "O"){
                    //ponerFicha();
                }
                else{
                    tablero[valor-1] = "O";
                }
            }
    }
}