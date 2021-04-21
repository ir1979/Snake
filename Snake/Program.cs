using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        private const int SCREEN_WIDTH = 80;
        private const int SCREEN_HEIGHT = 25;

        static void Main(string[] args)
        {
            int[] sx = new int[SCREEN_HEIGHT*SCREEN_WIDTH-1];
            int[] sy = new int[SCREEN_HEIGHT * SCREEN_WIDTH - 1];

            int shx, shy;
            shx = shy = 0;

            int delay = 300;

            int snakeLength = 3;

            int score = 0;

            int meatx;
            int meaty;

            Random rnd = new Random();
            meatx = rnd.Next(0, SCREEN_WIDTH);
            meaty = rnd.Next(0, SCREEN_HEIGHT);

            ConsoleKeyInfo ch;


            bool continueFlag = true;



            //                    *** 

            ch = Console.ReadKey();

            while (continueFlag)
            {
                if (Console.KeyAvailable)
                {
                    ch = Console.ReadKey();
                }

                Console.SetCursorPosition(sx[snakeLength - 1], sy[snakeLength - 1]);
                Console.Write(' ');

                switch (ch.Key)
                {
                    case ConsoleKey.UpArrow:
                        shy--;
                        break;
                    case ConsoleKey.DownArrow:
                        shy++;
                        break;
                    case ConsoleKey.LeftArrow:
                        shx--;
                        break;
                    case ConsoleKey.RightArrow:
                        shx++;
                        break;
                    case ConsoleKey.Escape:
                        continueFlag = false;
                        break;
                    default:
                        break;
                }

                shx += SCREEN_WIDTH;
                shy += SCREEN_HEIGHT;

                shx %= SCREEN_WIDTH;
                shy %= SCREEN_HEIGHT;

                for (int i = snakeLength - 2; i >= 0; i--)
                {
                    sx[i + 1] = sx[i];
                    sy[i + 1] = sy[i];
                }
                sx[0] = shx;
                sy[0] = shy;

                if (sx[0]==meatx && sy[0]==meaty)
                {
                    score += 10;

                    // can be improved
                    meatx = rnd.Next(0, SCREEN_WIDTH);
                    meaty = rnd.Next(0, SCREEN_HEIGHT);
                    snakeLength++;
                    
                    delay = Math.Max(30, (int)(delay * 0.9));

                }


                for (int i = 0; i < snakeLength; i++)
                {
                    Console.SetCursorPosition(sx[i], sy[i]);
                    Console.Write('*');
                }

                Console.SetCursorPosition(meatx, meaty);
                Console.Write("O");


                for (int i=1;i<snakeLength;i++)
                {
                    if (sx[0] == sx[i] && sy[0] == sy[i])
                    {
                        continueFlag = false;
                    }
                }


                Console.SetCursorPosition(0, 0);
                Console.Write($"Score: {score}");

                System.Threading.Thread.Sleep(delay);
            }

            Console.WriteLine("Finished!");
            Console.ReadKey();

        }
    }
}
