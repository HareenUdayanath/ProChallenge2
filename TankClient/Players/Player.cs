using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankClient.Players
{
    public class Player
    {
        private int playerNo;
        private int positionX;
        private int positionY;
        private int direction;
        private int whetherShot;
        private int health;
        private int coins;
        private int points;

        public Player(int playerNo,int x,int y,int dir)
        {
            this.playerNo = playerNo;
            this.positionX = x;
            this.positionY = y;
            this.direction = dir;
            this.whetherShot = 0;
            this.health = 100;
            this.coins = 0;
            this.points = 0;
        }

        public int PlayerNo
        {
            get { return playerNo; }            
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
       

        public int WhetherShot
        {
            get { return whetherShot; }
            set { whetherShot = value; }
        }
       

        public int Health
        {
            get { return health; }
            set { health = value; }
        }
       

        public int Cons
        {
            get { return coins; }
            set { coins = value; }
        }
       

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public void setAll(int x,int y,int d,int ws,int h,int c,int p){
            this.positionX = x;
            this.positionY = y;
            this.direction = d;
            this.whetherShot = ws;
            this.health = h;
            this.coins = c;
            this.points = p;
        }
        
    }
}
