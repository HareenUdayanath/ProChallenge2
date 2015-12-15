using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankClient.AI
{
    class MapItem : IComparable<MapItem>
    {
        public static String BLANK = DecodeOperations.blankSimbol;
        public static String STONE = DecodeOperations.stoneSimbol;
        public static String WATER = DecodeOperations.waterSimbol;
        public static String BRICK = DecodeOperations.brickSimbol;
        public static String COIN = DecodeOperations.coinSimbol;
        public static String LIFEPACK = DecodeOperations.lifePackSimbol;
        //public static String PLAYER = "P";


        private String name;
        private String contain;
        private MapItem pre;
        private int dis;
        private int colour;
        private int dir;

      
        

        public int CompareTo(MapItem other)
        {
            return dis.CompareTo(other.Dis);
        }

        public int Dir
        {
            get { return dir; }
            set { dir = value; }
        }

        public int Colour
        {
            get { return colour; }
            set { colour = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Contain
        {
            get { return contain; }
            set { contain = value; }
        }
        public MapItem Pre
        {
            get { return pre; }
            set { pre = value; }
        }
        public int Dis
        {
            get { return dis; }
            set { dis = value; }
        }
    }
}
