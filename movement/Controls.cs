using System;
using System.Threading;
namespace movement
{
    public class Controls
    {
        MovableEntity movable;
        Map map;

        public Controls(MovableEntity movable, Map map) { this.movable = movable; this.map = map; }

        public void Start()
        {
            var pressedButton = new ConsoleKey();
            switch (movable)
            {
                case Player:
                    pressedButton = Console.ReadKey().Key;
                    break;
                case Bot:
                    Thread.Sleep(500);
                    pressedButton = ((Bot)movable).PressButton();
                    break;
            }

            Thread.Sleep(500);

            switch (pressedButton)
            {
                case ConsoleKey.RightArrow:
                    MovementProcessor.Move(Movement.right, movable, map, movable.image);
                    movable.MoveRight();
                    break;
                case ConsoleKey.LeftArrow:
                    MovementProcessor.Move(Movement.left, movable, map, movable.image);
                    movable.MoveLeft();
                    break;
                case ConsoleKey.UpArrow:
                    MovementProcessor.Move(Movement.up, movable, map, movable.image);
                    movable.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    MovementProcessor.Move(Movement.down, movable, map, movable.image);
                    movable.MoveDown();
                    break;
                case ConsoleKey.W:
                    Console.SetCursorPosition(movable.position.x + 1, movable.position.y);
                    Console.Write(" ");
                    var bullet1 = new Bullet(movable.position);
                    bullet1.Settings((Player)movable);
                    bullet1.Fly(Movement.up, bullet1, map);
                    Console.SetCursorPosition(movable.position.x + 1, movable.position.y);
                    break;
                case ConsoleKey.S:
                    Console.SetCursorPosition(movable.position.x + 1, movable.position.y);
                    Console.Write(" ");
                    var bullet2 = new Bullet(movable.position);
                    bullet2.Settings((Player)movable);
                    bullet2.Fly(Movement.down, bullet2, map);
                    Console.SetCursorPosition(movable.position.x + 1, movable.position.y);
                    break;
                case ConsoleKey.A:
                    Console.SetCursorPosition(movable.position.x + 1, movable.position.y);
                    Console.Write(" ");
                    var bullet3 = new Bullet(movable.position);
                    bullet3.Settings((Player)movable);
                    bullet3.Fly(Movement.left, bullet3, map);
                    Console.SetCursorPosition(movable.position.x + 1, movable.position.y);
                    break;
                case ConsoleKey.D:
                    Console.SetCursorPosition(movable.position.x + 1, movable.position.y);
                    Console.Write(" ");
                    var bullet4 = new Bullet(movable.position);
                    bullet4.Settings((Player)movable);
                    bullet4.Fly(Movement.right, bullet4, map);
                    Console.SetCursorPosition(movable.position.x + 1, movable.position.y);
                    break;
                case ConsoleKey.NoName:
                    break;
            }
        }
    }
}
