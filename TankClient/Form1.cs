using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankClient.AI;
using TankClient.Players;

namespace TankClient
{
    public partial class Form1 : Form
    {
        private Communicator com;
        private Boolean isJoined = false;
        private DecodeOperations dec = DecodeOperations.GetInstance();
        private Controller con = null;

        public Form1()
        {
            InitializeComponent();
            this.com = Communicator.GetInstance();
            this.con = Controller.GetInstance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.command_txt.Text = "UP";
            com.sendData(Constants.UP);
        }


        public Boolean IsJoined
        {
            get { return isJoined; }
            set { isJoined = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.command_txt.Text = "LEFT";
            com.sendData(Constants.LEFT);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.command_txt.Text = "DOWN";
            com.sendData(Constants.DOWN);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.command_txt.Text = "RIGHT";
            com.sendData(Constants.RIGHT);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!isJoined)
            {
                try
                {
                    com.sendData(Constants.JOIN);
                    this.command_txt.Text = "JOIN";
                    Thread thread = new Thread(() => com.readAndSetData(this));
                    Thread threadDo = new Thread(() => con.controll());
                    Thread threadShoot = new Thread(() => con.shoot());
                    thread.Start();
                    //threadDo.Start();
                    //threadShoot.Start();
                    this.isJoined = true;
                }
                catch (Exception ex) 
                {
                }
            }
            else
            {
                this.command_txt.Text = "Already Joined";
            }
           

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.command_txt.Text = "SHOOT";
            com.sendData(Constants.SHOOT);
            
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Up)
            {
                this.command_txt.Text = "UP";
                com.sendData(Constants.UP);
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.command_txt.Text = "DOWN";
                com.sendData(Constants.DOWN);
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.command_txt.Text = "LEFT";
                com.sendData(Constants.LEFT);
            }
            else if (e.KeyCode == Keys.Right)
            {
                this.command_txt.Text = "RIGHT";
                com.sendData(Constants.RIGHT);
            }
            else if (e.KeyCode == Keys.J)
            {

                if (!isJoined)
                {
                    try
                    {
                        com.sendData(Constants.JOIN);
                        this.command_txt.Text = "JOIN";
                        Thread thread = new Thread(() => com.readAndSetData(this));
                        thread.Start();
                        this.isJoined = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else {
                    this.command_txt.Text = "Already Joined";
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                this.command_txt.Text = "SHOOT";
                com.sendData(Constants.SHOOT);
            }
            else {
                this.command_txt.Text = "";
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            com.sendData(Constants.JOIN);
            /*String map = com.receiveData();
            this.textBox1.AppendText(map);            
            dec.setMap(map);                      
            this.displayMap(dec.getMap());

            map = com.receiveData();
            this.textBox1.AppendText(map);
            dec.setMap(map);
            this.displayMap(dec.getMap());

            map = com.receiveData();
            this.textBox1.AppendText(map); */
            int i=0;
            while(i++<10)
                this.command_txt.AppendText(com.receiveData()+"\n");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            DecodeOperations dc = DecodeOperations.GetInstance();
            
            Controller con = Controller.GetInstance();
            Player myPlayer = dc.getPlayer(dc.PlayerNo);
            Console.WriteLine("A");
            MapItem[,] itList = con.createMapItemList(dc.getMap());
            Console.WriteLine("B");
           /* int x = Int32.Parse(this.goTxt.Text.Split(',')[0]);
            int y = Int32.Parse(this.goTxt.Text.Split(',')[1]);
            Console.WriteLine("X: "+myPlayer.PositionX);
            Console.WriteLine("Y: "+myPlayer.PositionY);
            Console.WriteLine("NX: "+x);
            Console.WriteLine("NY: "+y);
            List<MapItem> path = con.getPath(itList, itList[myPlayer.PositionY,myPlayer.PositionX], itList[x,y]);*/
            String whatToFind = null;
            switch(this.goTxt.Text){
                case "Br":whatToFind="▥";break;
                case "S":whatToFind="▦";break;
                case "W":whatToFind="▩";break;
                case "B":whatToFind="▢";break;
                case "C":whatToFind="◉";break;
                case "L":whatToFind="☩";break;
            }
            //this.goTxt.Text = whatToFind;
            /*List<MapItem> path = con.getPathTo(itList, itList[myPlayer.PositionY, myPlayer.PositionX], whatToFind);
            String next = null;
            try
            {
                 next = con.next(path);
            }catch(Exception c){
                Console.WriteLine("next: "+c);
            }
            Console.WriteLine("SSSNNN: " + next);
            //if (con.shouldShoot(itList, itList[myPlayer.PositionX, myPlayer.PositionY]))
                //Console.WriteLine("Shoot.....................");
            //con.shoot();
            com.sendData(next); */     
            Thread threadDo = new Thread(() => con.controll());
            Thread threadShoot = new Thread(() => con.shoot());
            //threadDo.Priority = ThreadPriority.Highest;
            //threadShoot.Priority = ThreadPriority.BelowNormal;
            threadDo.Start();
            //threadShoot.Start();

            //con.findCoins();
        }

    }
}
