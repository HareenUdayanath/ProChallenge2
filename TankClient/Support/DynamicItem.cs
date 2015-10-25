using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankClient.Support
{
    class DynamicItem
    {
        private int positionX;
        private int positionY;
        private int lifeTime = -1;
        private int appearTime = -1;
        private int disappearTime = -1;

        public DynamicItem(int x,int y) 
        {
            positionX = x;
            positionY = y;
        }


        public int LifeTime
        {
            get { return lifeTime; }
            set { lifeTime = value; }
        }

        public int AppearTime
        {
            get { return appearTime; }
            set { appearTime = value; }
        }

        public int DisappearTime
        {
            get { return disappearTime; }
            set { disappearTime = value; }
        }

    }
}
