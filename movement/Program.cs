using System;
using System.Threading.Tasks;
using System.Threading;

namespace movement
{
    public enum Movement
    {
        left,
        right,
        up,
        down
    }
    public struct Point
    {
        public int x;
        public int y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == "start")
            {
                Console.Clear();
                var origin = new Point() { x = 0, y = 0 };
                var player = new Player();
                var bot1 = new Bot();
                var map = new Map();

                var wall1 = Service.GenerateWall(map, "row");
                Service.AddWall(wall1, map);

                var wall2 = Service.GenerateWall(map, "row");
                Service.AddWall(wall2, map);

                var wall3 = Service.GenerateWall(map, "column");
                Service.AddWall(wall3, map);

                var wall4 = Service.GenerateWall(map, "column");
                Service.AddWall(wall4, map);

                var staticObjs = Service.GenerateStatics(20, new string[] {"*", "@"}, map);
                
                //var examplars = new List<string>();

                //for (int i = 0; i < staticObjs.Count; i++)
                //    examplars.Add(staticObjs[i].image);

                //map.SetElements(examplars);
                
                //player.SetImage("层");

                player.SetImage("x");
                player.SetOrigin(origin);

                bot1.SetImage("b");

                for (int i = 0; i < staticObjs.Count; i++)
                    map.AddStaticObject(staticObjs[i]);

                map.DrawObj();

                var playerControls = new Controls(player, map);
                var botControls = new Controls(bot1, map);

                var cancelTokenSource = new CancellationTokenSource();
                CancellationToken token = cancelTokenSource.Token;

                while (true)
                {
                    var task1 = Task.Factory.StartNew(() => playerControls.Start());
                    if (!Service.isPossible)
                    {
                        cancelTokenSource.Cancel();
                        break;
                    }
                }
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                if (Service.playerDied) Console.WriteLine("You died!");
                else Console.WriteLine("You won!");

                Console.WriteLine($"Score: {player.score + 1}");
                Console.ReadLine();
            }
        }
    }
}