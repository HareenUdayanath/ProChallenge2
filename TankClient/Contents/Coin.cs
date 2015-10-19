using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankClient.Contents
{
    class Coin
    {
        private int positionX;
        private int positionY;
        private int value;

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public int PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }
       

        public int PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }
       
    }
}
