using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();   
            board.initialize(25, player);
            player.Initialize(1, 1, board);

            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 30;

            int lastTIck = 0;

            while(true)
            {
                int currentTick = System.Environment.TickCount;
                if (currentTick - lastTIck < WAIT_TICK)
                    continue;
                int deltaTick = currentTick - lastTIck;
                lastTIck = currentTick;
                //입력

                //로직
                player.Update(deltaTick);
                //렌더링
                Console.SetCursorPosition(0, 0);
                board.Render();
            }
        }
    }
}