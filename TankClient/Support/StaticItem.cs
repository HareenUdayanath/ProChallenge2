using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankClient.Support
{
    public class StaticItem
    {
        private int positionX;
        private int positionY;
       

        public StaticItem(int x, int y) 
        {
            positionX = x;
            positionY = y;
        }
        public int X
        {
            get { return positionX; }
            
        }
        public int Y
        {
            get { return positionY; }

        }
    }
}
