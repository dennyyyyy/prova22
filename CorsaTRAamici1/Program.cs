using System;
using System.Threading;
using static System.Console;
// Barbieri Mosè 4E inizio esperienza: 2022-09-22
// See https://aka.ms/new-console-template for more information

namespace CorsaTraAmici
{
   

    class Program
    {
        static Thread thAndrea = new Thread(Andrea);
        static Thread thBaldo = new Thread(Baldo);
        static Thread thCarlo = new Thread(Carlo);

        static int PosAndrea = 0; //posizione di partenza di Andrea
        static int PosBaldo = 0;  //posizione di partenza si Baldo 
        static int PosCarlo = 0;  //posizione di partenza di Carlo 
        static int classifica = 0;  //contatore per prendere la posizione        
        static Object _lock = new Object();

      
        static void Pronti() //metodo per metterli nella posizione di partenza
        {
            
            SetCursorPosition(PosAndrea, 2);  //aspetto e nome di andrea
            Write("Andrea");
            SetCursorPosition(PosAndrea, 3);
            Write("   ìì");
            SetCursorPosition(PosAndrea, 4);
            Write(@"  /[]\");
            SetCursorPosition(PosAndrea, 5);
            Write("   II");

            SetCursorPosition(PosBaldo, 6); //aspetto e nome di Baldo
            Write("Baldo");
            SetCursorPosition(PosBaldo, 7);
            Write(" ()");
            SetCursorPosition(PosBaldo, 8);
            Write(@" /0\");
            SetCursorPosition(PosBaldo, 9);
            Write("  l");

            SetCursorPosition(PosCarlo, 10);//aspetto e nome Carlo
            Write("Carlo");
            SetCursorPosition(PosCarlo, 11);
            Write("  @");
            SetCursorPosition(PosCarlo, 12);
            Write(@" /G\");
            SetCursorPosition(PosCarlo, 13);
            Write("  !");

        }

        
        static void Andrea() 
        {
           

            Random rnd = new Random();
            int velocità = rnd.Next(10, 50);
            do
            {
                PosAndrea++;
                Thread.Sleep(50);
                
                lock (_lock)
                {
                    SetCursorPosition(PosAndrea, 5);
                    Write("  II");
                }
                lock (_lock)
                {
                    SetCursorPosition(PosAndrea, 4);
                    Write(@" /[]\");
                }
                lock (_lock)
                {

                    SetCursorPosition(PosAndrea, 3);
                    Write("  ìì");
                }
            } while (PosAndrea < 115);

            lock (_lock)
            {
                classifica++;
                SetCursorPosition(115, 2);
                Write(classifica);
            }
        
        }

        static void Baldo() 
        {
            do
            {
                PosBaldo++;
                Thread.Sleep(60);

                lock (_lock)
                {
                    SetCursorPosition(PosBaldo, 9);
                    Write("  l");
                }
                lock (_lock) 
                { 
                    SetCursorPosition(PosBaldo, 8);
                    Write(@" /0\");
                }
                lock (_lock)
                {
                    SetCursorPosition(PosBaldo, 7);
                    Write("  ()");
                }
            } while (PosBaldo < 115);

            lock (_lock)
            {
                classifica++;
                SetCursorPosition(115, 6);
                Write(classifica);
            }
        }

        static void Carlo()
        {
            do
            {
                PosCarlo++;
                Thread.Sleep(30);
                lock (_lock)
                {
                    SetCursorPosition(PosCarlo, 13);
                    Write("  !");
                }
                lock (_lock)
                {
                    SetCursorPosition(PosCarlo, 12);
                    Write(@" /G\");
                }
                lock (_lock)
                {
                    SetCursorPosition(PosCarlo, 11);
                    Write("  @");
                }

            } while (PosCarlo < 115);

            lock (_lock)
            {
                classifica++;
                SetCursorPosition(115, 10);
                Write(classifica);
            }
        }

        static void Scrivi (int col, int rig, string st)
        {
            Thread.Sleep(50);
            lock (_lock)
            {
                SetCursorPosition(rig, col);
                Write(@st);
            }
        }

        static void Stato()
        {
            Scrivi(1, 2, "Andrea -> " + thAndrea.ThreadState + "                               ");
            Scrivi(50, 2, "Is alive = " + thAndrea.ThreadState + "              ");
            Scrivi(1, 6, "Andrea -> " + thBaldo.ThreadState + "                               ");
            Scrivi(50, 6, "Is alive = " + thBaldo.ThreadState + "              ");
            Scrivi(1, 10, "Andrea -> " + thCarlo.ThreadState + "                               ");
            Scrivi(50, 10, "Is alive = " + thCarlo.ThreadState + "              ");
        }

        static void Main(string[] args) 
        {
            Console.WriteLine("Autore : Barbieri Mosè");

            CursorVisible = false;

            Pronti(); //inizio della gara, posizione

            //Andrea();
            //Baldo();
            //Carlo();

            //Console.ReadLine();


            thAndrea.Start(); 
            thBaldo.Start();
            thCarlo.Start();

            do
            {
                Stato();
            } while (classifica < 3);

            thAndrea.Join();
            thBaldo.Join();
            thCarlo.Join();

            Console.ReadKey();



            

            
        }
    }


}