using System.Threading;
using System;
namespace movement
{
    public class MovableEntity
    {
        public Point position;
        public string image;

        public void SetOrigin(Point origin) { position = origin; }
        public void SetImage(string image) { this.image = image; }
        public void MoveLeft() { position.x -= 1; }
        public void MoveRight() { position.x += 1; }
        public void MoveUp() { position.y -= 1; }
        public void MoveDown() { position.y += 1; }
    }

    public class Player : MovableEntity
    {
        public string name = "Default";
        private int health = 100;
        public int score = 0;
        public int bulletRange = 3;

        public int GetHealth() { return health;  }
        public void ReceiveDamage(int damageTaken) { health -= damageTaken; }
        public void Settings(string name, string image) { this.name = name; this.image = image; }
        public string GetImage() { return image; }
    }

    public class Bullet : MovableEntity
    {
        public int damage = 10;
        public int range = 1;
        public Player owner;

        public Bullet(Point location)
        {
            position = location;
        }

        public void GiveDamage(Player enemy) { enemy.ReceiveDamage(damage); }
        public void Settings(Player player) { owner = player; range = owner.bulletRange; }
        public void Fly(Movement direction, Bullet bullet, Map map)
        {
            for (int i = 0; i < range - 1; i++)
            {
                if (direction == Movement.left)
                    position.x--;
                else if (direction == Movement.right)
                    position.x++;
                else if (direction == Movement.up)
                    position.y--;
                else position.y++;

                MovementProcessor.Move(direction, bullet, map, ".");
                Thread.Sleep(100);
            }
            MovementProcessor.Move(direction, bullet, map, image, false);
        }
    }

    public class Bot : MovableEntity
    {
        public Bot()
        {
            var random = new Random();
            int randX = random.Next(10, 20);
            int randY = random.Next(10, 20);

            position.x = randX;
            position.y = randY;
        }

        public ConsoleKey PressButton()
        {
            var random = new Random();
            ConsoleKey[] buttons = new ConsoleKey[] { ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow} ;
            int randIndex = random.Next(0, buttons.Length);
            ConsoleKey randButton = buttons[randIndex];
            return randButton;
        }

        private int ExamineForStuck(int[] prevs)
        {
            int index = -1;
            for (int i = 0; i < prevs.Length; i++)
            {
                if (prevs[i] > 3)
                {
                    index = prevs[i];
                }
            }

            return index;
        }

        private void SetToDefault(int[] prevs)
        {
            for (int i = 0; i < prevs.Length; i++)
                prevs[i] = 0;
        }
    }
}
