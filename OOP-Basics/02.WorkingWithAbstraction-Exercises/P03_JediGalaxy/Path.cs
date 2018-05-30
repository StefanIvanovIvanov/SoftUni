using System;
using System.Collections.Generic;
using System.Text;


    public class Path
    {
        private int x;
        private int y;

        public int X
        {
        get { return x; }
        set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Path(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

}

