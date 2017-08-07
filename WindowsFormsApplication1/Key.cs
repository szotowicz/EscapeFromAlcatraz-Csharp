using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsFormsApplication1
{
    public class Key
    {
        public int ID;
        public int X;
        public int Y;

        public Key(int ID, int X, int Y)
        {
            this.ID = ID;
            this.X = X;
            this.Y = Y;
        }

        public static int GetIdKey(Key[] keys, int y, int x)
        {
            return keys.Where(s => s.X == x && s.Y == y).Select(e => e.ID).First();
        }
    }
}
