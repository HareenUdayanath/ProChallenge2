using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TankClient.Contents;
using TankClient.Players;

namespace TankClient
{
    class DecodeOperations
    {
        private bool isInit = false;
        private String playerNo = null;
        private String brickSimbol = "▥";
        private String stoneSimbol = "▦";
        private String waterSimbol = "▩";
        private String blankSimbol = "▢";
        private String coinSimbol = "◉";
        private String lifePackSimbol = "☩";

        private String[] playerDir = { "▲", "►", "▼", "◄" };

        public static int GRID_SIZE = 10;
        private String[,] map;
        private List<Player> playerList;
        private List<Brick> brickList;        
        private List<Coin> coinList;
        private List<Stone> stoneList;
        private List<Water> waterList;
      
     
        private static DecodeOperations dec = new DecodeOperations();
        
        private DecodeOperations()
        {
            this.map = new String[GRID_SIZE, GRID_SIZE];
            this.playerList = new List<Player>();
            this.brickList = new List<Brick>();
            this.coinList = new List<Coin>();
            this.stoneList = new List<Stone>();
            this.waterList = new List<Water>();
        }

        public static DecodeOperations GetInstance()
        {
            return dec;
        }

        internal List<Player> PlayerList
        {
            get { return playerList; }            
        }

        internal List<Brick> BrickList
        {
            get { return brickList; }
            set { brickList = value; }
        }

        public void setMap(String msg) {
            
            if (!isInit)
            {
                initMap();
                isInit = true;
            }
            switch(msg[0]){
                case 'I':
                    {
                        setEnvironment(msg);break;   
                    }
                case 'S':
                    {
                        setPlayer(msg); break;
                    }
                case 'G':
                    {
                        setPlayerGroup(msg); break;
                    }
                case 'C':
                    {
                        setCoins(msg); break;
                    }
                case 'L':
                    {
                        setLifePack(msg); break;
                    }             
            }  
           
        }

        public String[,] getMap()
        {
            if(!isInit)
            {
                initMap();
                isInit = true;
            }
            return map;    
        }

        private void setEnvironment(String msg)
        {
            String[] things = msg.Split(':');
            playerNo = things[1][1].ToString();

            foreach (String bri in things[2].Split(';')) { 
                int x = Int32.Parse(bri[0].ToString());
                int y = Int32.Parse(bri[2].ToString());
                this.brickList.Add(new Brick(y,x));
                map[y, x] = brickSimbol;
            }
            foreach (String sto in things[3].Split(';'))
            {
                int x = Int32.Parse(sto[0].ToString());
                int y = Int32.Parse(sto[2].ToString());
                this.stoneList.Add(new Stone(y, x));
                map[y, x] = stoneSimbol;
            }
            things[4] = things[4].Remove(things[4].Length - 2);
            foreach (String wat in things[4].Split(';'))
            {
                int x = Int32.Parse(wat[0].ToString());
                int y = Int32.Parse(wat[2].ToString());
                this.waterList.Add(new Water(y, x));
                map[y, x] = waterSimbol;
            }
            
        }

        //S:P0;0,0;0#�
        private void setPlayer(String plDetails) {

            String[] players = plDetails.Split(':');

            int length = players.Length;

            for (int i = 1; i < length;i++)
            {
                String[] details = players[i].Split(';');
               
                int p = Int32.Parse(details[0][1].ToString());
                int x = Int32.Parse(details[1][0].ToString());
                int y = Int32.Parse(details[1][2].ToString());
                int d = Int32.Parse(details[2][0].ToString());

                Player player = new Player(p, y, x, d);
                this.playerList.Add(player);

                map[y, x] = playerDir[d];

            }

           

        }

        //G:P0;0,0;0;0;100;0;0:8,6,0;0,3,0;3,2,0;5,4,0;4,7,0;1,3,0;3,6,0#�

        //0,0 ; 0 ; 0; 100 ; 0 ; 0 
        //: 8,6,0 ; 0,3,0 ; 3,2,0 ; 5,4,0 ; 4,7,0 ; 1,3,0 ; 3,6,0#
        private void setPlayerGroup(String msg) 
        {
            String[] players = msg.Split(':');

            int length = players.Length;
            String last = players[length - 1];
            players[length - 1] = last.Remove(last.Length - 2);

            for (int i = 1; i < length-1;i++)
            {
                String[] playerDetails = players[i].Split(';');
                int x = Int32.Parse(playerDetails[1][0].ToString());
                int y = Int32.Parse(playerDetails[1][2].ToString());
                int d = Int32.Parse(playerDetails[2]);
                int ws = Int32.Parse(playerDetails[3]);
                int h = Int32.Parse(playerDetails[4]);
                int c = Int32.Parse(playerDetails[5]);
                int p = Int32.Parse(playerDetails[6]);

                map[playerList[i - 1].PositionX, playerList[i - 1].PositionY] = blankSimbol;

                playerList[i - 1].setAll(y, x, d, ws, h, c, p);                
                if(h!=0)
                    map[y, x] = playerDir[d];
            }
            
           
            String[] bricksDetails = players[length - 1].Split(';');
            foreach (String br in bricksDetails) { 

                String[] brd = br.Split(',');
                int x = Int32.Parse(brd[0]);
                int y = Int32.Parse(brd[1]);
                int d = Int32.Parse(brd[2]);
                if (d == 4)
                {
                    map[y, x] = blankSimbol;
                }


                setDamageLevel(y, x, d);
            }

         
                
        }
       
          
        private void setCoins(String coinDetails) 
        {
            String[] coin = coinDetails.Split(':');               
               
            int x = Int32.Parse(coin[1][0].ToString());
            int y = Int32.Parse(coin[1][2].ToString());
            int lt = Int32.Parse(coin[2]);
            int v = Int32.Parse(coin[3].Remove(coin[3].Length-2));
            Coin c = new Coin(y, x, v);
            c.LifeTime = lt;
            this.coinList.Add(c);
            map[y, x] = coinSimbol;
            Thread coinThread = new Thread(() =>setToBlank(y,x,lt));
            coinThread.Start();
        }

        private void setLifePack(String lifePackDetails)
        {
            String[] lifePack = lifePackDetails.Split(':');

            int x = Int32.Parse(lifePack[1][0].ToString());
            int y = Int32.Parse(lifePack[1][2].ToString());
            int lt = Int32.Parse(lifePack[2].Remove(lifePack[2].Length-2));

            map[y, x] = lifePackSimbol;
            Thread lifePackThread = new Thread(() => setToBlank(y, x, lt));
            lifePackThread.Start();
        }

        private void initMap()
        {

            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    map[i,j] = blankSimbol;
                }
            }
            
        }

        private void setDamageLevel(int x,int y,int dl)
        {
            foreach (Brick br in brickList) 
            {
                if (br.PositionX == x && br.PositionY == y)
                {
                    br.DamageLevel = dl;
                    break;
                }
                    
            }
        }

        private void setToBlank(int x,int y,int lt) 
        {
            Thread.Sleep(lt);
            map[y, x] = blankSimbol;    
        }

        private void vanishCoin() 
        {
        
        }
    }
}
