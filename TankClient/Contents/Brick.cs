using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankClient.Contents
{
    class Brick
    {
        private int positionX;
        private int positionY;
        private int damageLevel;

        public Brick(int x,int y)
        {
            this.positionX = x;
            this.positionY = y;
            this.damageLevel = 0;
        }

        public int PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }
        

        public int PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }
       

        public int DamageLevel
        {
            get { return damageLevel; }
            set { damageLevel = value*25; }
        }
    }
}
