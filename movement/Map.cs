using System;
using System.Collections.Generic;
namespace movement
{
    public class Map
    {
        List<StaticObj> statics = new();
        List<MovableEntity> movables = new();
        List<string> magazine = new();

        public void AddStaticObject(StaticObj obj) { statics.Add(obj); }
        public void AddMovable(MovableEntity movable) { movables.Add(movable); }
        public List<StaticObj> GetStatics() { return statics; }
        public void DrawObj()
        {
            for(int i = 0; i < statics.Count; i++)
            {
                var staticObj = statics[i];
                if (statics[i] is Brick) Console.ForegroundColor = ConsoleColor.Blue;

                Console.SetCursorPosition(staticObj.position.x, staticObj.position.y);
                Console.Write(staticObj.image);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public object CheckForObject(Point point)
        {
            for (int i = 0; i < statics.Count; i++)
            {
                if (statics[i].position.x == point.x
                    && statics[i].position.y ==  point.y)
                    return statics[i];
            }
            return null;
        }

        public void SetElements(List<string> images) { for (int i = 0; i < statics.Count; i++) { magazine = images; } }
        public bool IsExamplarExist(string image) { if (magazine.Contains(image)) return true; else return false; }
    }
}
