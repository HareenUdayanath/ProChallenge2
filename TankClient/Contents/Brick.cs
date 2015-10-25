using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankClient.Support;

namespace TankClient.Contents
{
    public class Brick:StaticItem
    {
        
        private int damageLevel;

        public Brick(int x,int y):base(x,y)
        {            
            this.damageLevel = 0;
        }

       

        public int DamageLevel
        {
            get { return damageLevel; }
            set { damageLevel = value*25; }
        }
    }
}
