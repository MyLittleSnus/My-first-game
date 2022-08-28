using System;
using static System.Console;
namespace movement
{
    public static class MovementProcessor
    {
        public static void Move(Movement direction, MovableEntity movable, Map map, string image, bool drawImage = true)
        {
            switch (direction)
            {
                case Movement.left:
                    if (movable.position.x > 0)
                    {
                        var leftNextLoc = new Point() { x = movable.position.x - 1, y = movable.position.y };
                        if (!(map.CheckForObject(leftNextLoc) is Brick))
                        {
                            SetCursorPosition(movable.position.x, movable.position.y);
                            Write(" ");
                            SetCursorPosition(movable.position.x - 1, movable.position.y);
                            Service.CountScore(movable, map);
                            if (drawImage)
                            {
                                if (movable is Player)
                                {
                                    ForegroundColor = ConsoleColor.Green;
                                    Write(image);
                                    ForegroundColor = ConsoleColor.Gray;
                                }
                                else Write(image);
                            }
                            else Write(" ");
                        }
                        else movable.position.x++;
                    }
                    else movable.position.x = 1;
                    break;
                case Movement.right:
                    var rightNextLoc = new Point() { x = movable.position.x + 1, y = movable.position.y };
                    if (!(map.CheckForObject(rightNextLoc) is Brick))
                    {
                        SetCursorPosition(movable.position.x, movable.position.y);
                        Write(" ");
                        SetCursorPosition(movable.position.x + 1, movable.position.y);
                        Service.CountScore(movable, map);
                        if (drawImage)
                        {
                            if (movable is Player)
                            {
                                ForegroundColor = ConsoleColor.Green;
                                Write(image);
                                ForegroundColor = ConsoleColor.Gray;
                            }
                            else Write(image);
                        }
                        else Write(" ");
                    }
                    else movable.position.x--;
                    break;
                case Movement.down:
                    var downNextLoc = new Point() { x = movable.position.x, y = movable.position.y + 1 };
                    if (!(map.CheckForObject(downNextLoc) is Brick))
                    {
                        SetCursorPosition(movable.position.x, movable.position.y);
                        Write(" ");
                        SetCursorPosition(movable.position.x, movable.position.y + 1);
                        Service.CountScore(movable, map);
                        if (drawImage)
                        {
                            if (movable is Player)
                            {
                                ForegroundColor = ConsoleColor.Green;
                                Write(image);
                                ForegroundColor = ConsoleColor.Gray;
                            }
                            else Write(image);
                        }
                        else Write(" ");
                    }
                    else movable.position.y--;
                    break;
                case Movement.up:
                    if (movable.position.y > 0)
                    {
                        var upNextLoc = new Point() { x = movable.position.x, y = movable.position.y - 1 };
                        if (!(map.CheckForObject(upNextLoc) is Brick))
                        {
                            SetCursorPosition(movable.position.x, movable.position.y);
                            Write(" ");
                            SetCursorPosition(movable.position.x, movable.position.y - 1);
                            Service.CountScore(movable, map);
                            if (drawImage)
                            {
                                if (movable is Player)
                                {
                                    ForegroundColor = ConsoleColor.Green;
                                    Write(image);
                                    ForegroundColor = ConsoleColor.Gray;
                                }
                                else Write(image);
                            }
                            else Write(" ");
                        }
                        else movable.position.y++;
                    }
                    else movable.position.y = 1;
                    break;
            }
        }
    }
}
