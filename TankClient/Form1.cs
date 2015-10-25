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

namespace TankClient
{
    public partial class Form1 : Form
    {
        private Communicator com;
        private Boolean isJoined = false;
        private DecodeOperations dec = DecodeOperations.GetInstance();

        public Form1()
        {
            InitializeComponent();
            this.com = Communicator.GetInstance();
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
                    thread.Start();
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

        private void button7_Click_1(object sender, EventArgs e)
        {
            /*Image image = Image.FromFile(@"Tank2.png");
            // Set the PictureBox image property to this image.
            // ... Then, adjust its height and width properties.
            pictureBox1.Image = image;
            pictureBox1.Height = image.Height;
            pictureBox1.Width = image.Width;*/
            //pictureBox1.Image = new Bitmap(@"C:\Users\Asus\documents\visual studio 2013\Projects\TankClient\TankClient\Tank2.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            this.displayInMap("Hello World");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
