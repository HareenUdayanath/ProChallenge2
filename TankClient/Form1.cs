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
        Communicator com;
        Boolean isJoined = false;

        public Form1()
        {
            InitializeComponent();
            this.com = new Communicator();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "UP";
            com.sendData(Constants.UP);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "LEFT";
            com.sendData(Constants.LEFT);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "DOWN";
            com.sendData(Constants.DOWN);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "RIGHT";
            com.sendData(Constants.RIGHT);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!isJoined)
            {
                com.sendData(Constants.JOIN);
                this.textBox1.Text = "JOIN";
                Thread thread = new Thread(() => com.readData(this));
                thread.Start();
                this.isJoined = true;
            }
            else
            {
                this.textBox1.Text = "Already Joined";
            }
           

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "SHOOT";
            com.sendData(Constants.SHOOT);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Up)
            {
                this.textBox1.Text = "UP";
                com.sendData(Constants.UP);
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.textBox1.Text = "DOWN";
                com.sendData(Constants.DOWN);
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.textBox1.Text = "LEFT";
                com.sendData(Constants.LEFT);
            }
            else if (e.KeyCode == Keys.Right)
            {
                this.textBox1.Text = "RIGHT";
                com.sendData(Constants.RIGHT);
            }
            else if (e.KeyCode == Keys.J)
            {

                if (!isJoined)
                {
                    com.sendData(Constants.JOIN);
                    this.textBox1.Text = "JOIN";
                    Thread thread = new Thread(() => com.readData(this));
                    thread.Start();
                    this.isJoined = true;
                }
                else {
                    this.textBox1.Text = "Already Joined";
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                this.textBox1.Text = "SHOOT";
                com.sendData(Constants.SHOOT);
            }
            else {
                this.textBox1.Text = "";
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "♕";
        }
    }
}
