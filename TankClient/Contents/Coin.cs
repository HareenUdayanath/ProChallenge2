using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankClient.Support;

namespace TankClient.Contents
{
    class Coin :DynamicItem
    {
       
        private int value;

        public Coin(int x, int y,int val):base(x,y) 
        {
            this.value = val;
        }

        public int Value
        {
            get { return this.value; }
        }

    }
}
