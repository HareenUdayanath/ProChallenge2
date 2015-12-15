using System;
using System.Collections.Generic;
using TankClient.Contents;
using TankClient.Players;
namespace TankClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        public void display(string msg)
        {
            this.msg_txt.Text = msg;

        }

        public void displayInMap(String msg) 
        {
            this.map_txt.Text = "  "+msg;
        }

        public void displayBrickStates(List<Brick> brickList) 
        {
            this.bricks_txt.Text = "Brick Position(x,y)\tDamage Level\n";
            foreach (Brick b in brickList)
            {
                this.bricks_txt.AppendText("   (" +b.PositionX + "," +b.PositionY + ")\t\t\t" + b.DamageLevel + "%\n");
            }
        }

        public void displayPlayers(List<Player> playerList) 
        {
            this.players_txt.Text = "PlaterID\tPoints\tCoins\tHealth\n";
            foreach(Player p in playerList)
            {
                this.players_txt.AppendText("P" + p.PlayerNo + "\t" + p.Points + "$\t" + p.Cons + "$\t" + p.Health+"%\n");
            }
        }
/*
        public void displayPlayers(String playerDetailList)
        {
            this.textBox3.Text = "PlaterID\tPoints\tCoins\tHealth\n";
            this.textBox3.AppendText(playerDetailList);
        }
*/
        public void displayMap(string [,] map) {

            String newMap = "";
           // this.map_txt.Text = "";

            for(int i=0;i<DecodeOperations.GRID_SIZE;i++)
            {
                for (int j = 0; j < DecodeOperations.GRID_SIZE; j++)
                {
                    newMap+=(map[i,j]+"  ");
                }
                newMap+="\r\n";
            }
            this.map_txt.Text = newMap;
            
        }
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.command_txt = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.map_txt = new System.Windows.Forms.TextBox();
            this.players_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bricks_txt = new System.Windows.Forms.TextBox();
            this.msg_txt = new System.Windows.Forms.TextBox();
            this.goTxt = new System.Windows.Forms.TextBox();
            this.goBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(408, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Up";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(408, 362);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "Left";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(467, 362);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 41);
            this.button3.TabIndex = 2;
            this.button3.Text = "Down";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(526, 362);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(53, 41);
            this.button4.TabIndex = 3;
            this.button4.Text = "Right";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(608, 367);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 79);
            this.button5.TabIndex = 4;
            this.button5.Text = "Join";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // command_txt
            // 
            this.command_txt.Location = new System.Drawing.Point(110, 428);
            this.command_txt.Name = "command_txt";
            this.command_txt.Size = new System.Drawing.Size(269, 20);
            this.command_txt.TabIndex = 5;
            this.command_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(408, 409);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(171, 41);
            this.button6.TabIndex = 6;
            this.button6.Text = "SHOOT";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // map_txt
            // 
            this.map_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.map_txt.Location = new System.Drawing.Point(12, 12);
            this.map_txt.Multiline = true;
            this.map_txt.Name = "map_txt";
            this.map_txt.Size = new System.Drawing.Size(367, 319);
            this.map_txt.TabIndex = 7;
            // 
            // players_txt
            // 
            this.players_txt.Location = new System.Drawing.Point(397, 12);
            this.players_txt.Multiline = true;
            this.players_txt.Name = "players_txt";
            this.players_txt.Size = new System.Drawing.Size(322, 115);
            this.players_txt.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "brick    =  \"▥\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "stone   =  \"▦\"";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "water   =  \"▩\"";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "blank   =  \"▢\"";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 419);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "coins     = \"◉\"";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 437);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "lifePack = \"☩\"";
            // 
            // bricks_txt
            // 
            this.bricks_txt.Location = new System.Drawing.Point(398, 133);
            this.bricks_txt.Multiline = true;
            this.bricks_txt.Name = "bricks_txt";
            this.bricks_txt.Size = new System.Drawing.Size(320, 176);
            this.bricks_txt.TabIndex = 16;
            // 
            // msg_txt
            // 
            this.msg_txt.Location = new System.Drawing.Point(110, 343);
            this.msg_txt.Multiline = true;
            this.msg_txt.Name = "msg_txt";
            this.msg_txt.Size = new System.Drawing.Size(269, 79);
            this.msg_txt.TabIndex = 17;
            // 
            // goTxt
            // 
            this.goTxt.Location = new System.Drawing.Point(467, 315);
            this.goTxt.Name = "goTxt";
            this.goTxt.Size = new System.Drawing.Size(100, 20);
            this.goTxt.TabIndex = 18;
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(608, 315);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(75, 23);
            this.goBtn.TabIndex = 19;
            this.goBtn.Text = "Go";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(731, 463);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.goTxt);
            this.Controls.Add(this.msg_txt);
            this.Controls.Add(this.bricks_txt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.players_txt);
            this.Controls.Add(this.map_txt);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.command_txt);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "TankGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox command_txt;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox map_txt;
        private System.Windows.Forms.TextBox players_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox bricks_txt;
        private System.Windows.Forms.TextBox msg_txt;
        private System.Windows.Forms.TextBox goTxt;
        private System.Windows.Forms.Button goBtn;
    }
}

