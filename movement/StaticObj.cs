using System.Collections.Generic;
namespace movement
{
    public class StaticObj
    {
        public Point position;
        public string image;
        public bool isDestroyable = true;

        public void SetOrigin(Point origin) { position = origin; }
        public void SetImage(string image) { this.image = image; }
    }

    public class Brick : StaticObj
    {
        public Brick() { isDestroyable = false; }
    }
}
