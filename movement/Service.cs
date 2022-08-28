using System;
using System.Collections.Generic;

namespace movement
{
    public static class Service
    {
        public static bool isPossible = true;
        public static bool playerDied = false;

        public static Point GeneratePoint()
        {
            Random rand = new();
            int randX = rand.Next(5, 50);
            int randY = rand.Next(5, 15);

            return new Point() { x = randX, y = randY };
        }

        public static List<Brick> GenerateWall(Map map, string modeSelected = "none")
        {
            string[] modes = new string[] { "row", "column" };
            var random = new Random();
            if (modeSelected != "none" && modeSelected != "row" && modeSelected != "column")
                return null;
            string mode = "";
            if (modeSelected == "none") { mode = modes[random.Next(0, 2)]; }
            else mode = modeSelected;

            int randLength = random.Next(5, 15);
            int startVertex;
            List<Brick> bricks = new();
            switch (mode)
            {
                case "row":
                    int X = random.Next(4, 40);
                    startVertex = random.Next(3, 10);
                    for (int y = startVertex; y < randLength + startVertex; y++)
                    {
                        var point = new Point() { x = X, y = y };
                        if (!(map.CheckForObject(point) is StaticObj))
                        {
                            var brick = new Brick();
                            brick.position.x = X;
                            brick.position.y = y;
                            brick.SetImage("#");
                            bricks.Add(brick);
                        }
                        else break;
                    }
                    break;
                case "column":
                    int Y = random.Next(3, 10);
                    startVertex = random.Next(4, 40);
                    for (int x = startVertex; x < randLength + startVertex; x++)
                    {
                        var point = new Point() { x = x, y = Y };
                        if (!(map.CheckForObject(point) is StaticObj))
                        {
                            var brick = new Brick();
                            brick.position.x = x;
                            brick.position.y = Y;
                            brick.SetImage("#");
                            bricks.Add(brick);
                        }
                        else break;
                    }
                    break;
            }

            return bricks;
        }

        public static void AddWall(List<Brick> wall, Map map)
        {
            for (int i = 0; i < wall.Count; i++)
                map.AddStaticObject(wall[i]);
        }

        public static List<StaticObj> GenerateStatics(int amount, string[] imagePack, Map map, bool generateWalls = false)
        {
            List<StaticObj> staticObjs = new();

            for(int i = 0; i < amount; i++)
            {
                StaticObj staticObj = new();
                var point = GeneratePoint();
                if (!(map.CheckForObject(point) is StaticObj))
                {
                    staticObj.SetOrigin(GeneratePoint());
                    staticObj.SetImage(imagePack[new Random().Next(0, imagePack.Length)]);
                    staticObjs.Add(staticObj);
                }
                else i--;
            }

            return staticObjs;
        }

        public static int CountScore(MovableEntity movable, Map map)
        {
            List<StaticObj> staticObjs = map.GetStatics();
            int score = 0;
            if (staticObjs.Count == 1)
            {
                isPossible = false;
                return score;
            }
                
            for (int i = 0; i < staticObjs.Count; i++)
            {
                if (movable.position.Equals(staticObjs[i].position))
                {
                    if (movable is Bullet)
                    {
                        ((Bullet)movable).owner.score++;
                        score = ((Bullet)movable).owner.score;
                        staticObjs.Remove(staticObjs[i]);
                    }
                    else if (movable is Player)
                    {
                        if (staticObjs[i].image == "*") { playerDied = true; isPossible = false; }
                            //throw new Exception("You died, score: " + ((Player)movable).score);
                        else if (staticObjs[i].image == "@")
                            ((Player)(movable)).bulletRange += 1;
                        else
                        {
                            staticObjs.Remove(staticObjs[i]);
                            ((Player)movable).score++;
                            score = ((Player)movable).score;
                        }
                    }
                }
            }

            return score;
        }
    }
}
