using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kiosk_ex1
{
    public partial class Main_First : Form
    {

        bool TagMove;
        int MValX, MValY;

        int btnOffset_W;
        int btnOffset_H;
        public Main_First()
        {
            InitializeComponent();

            //테두리창 삭제
            this.FormBorderStyle = FormBorderStyle.None;
            this.ActiveControl = button1;

     
            //btnOffset_W = this.Width - button1.Width;
            //btnOffset_W = this.Height - button1.Height;

        }


        private void Form1_Resize(object sender, EventArgs e)
        {

            //button1.Width = this.Width - btnOffset_W;
            //button1.Height = this.Height - btnOffset_H;

            this.Invalidate();
        }



        private void label1_Click_3(object sender, EventArgs e)
        {

        }


        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = true;
            MValX = e.X;
            MValY = e.Y;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            TagMove = false;
        }


        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (TagMove == true)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }


        
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "사원ID") {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.Color.Black;

                return;
            }
            else if(textBox1.Text  != null)
            {
                textBox1.SelectAll();
                return;
            }
            /*else if(textBox1.Text == null)
            {
                textBox1.Text = "사원ID";
                textBox1.ForeColor = System.Drawing.SystemColors.ScrollBar;

                return;

            }*/

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "패스워드")
            {
                textBox2.Text = "";
                this.textBox2.UseSystemPasswordChar = true;
                textBox2.ForeColor = System.Drawing.Color.Black;
            }
            else if (textBox2.Text != null)
            {
                textBox2.SelectAll();
            }
            
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Second showForm = new Main_Second();
            
            showForm.ShowDialog();
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

            Application.OpenForms["Main_First"].Close();
        }

    }
}
