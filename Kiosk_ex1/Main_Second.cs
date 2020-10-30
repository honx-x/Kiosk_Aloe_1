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
    public partial class Main_Second : Form
    {
        public Main_Second()
        {
            InitializeComponent();
            customizeDesign();

            Form1 form1 = new Form1();
            form1.TopLevel = false;
            form1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_content.Controls.Add(form1);
            form1.Show();


            //this.panel_content.Controls.Add(form1);
           
        }


        private void customizeDesign()
        {

            panel_menu1.Visible = false;
            panel_menu2.Visible = false;
            panel_menu3.Visible = false;
            panel_menu4.Visible = false;
            

        }

        private void hideSubMenu()
        {

            if (panel_menu1.Visible == true)
            {
                panel_menu1.Visible = false;
            } if (panel_menu2.Visible == true)
            {
                panel_menu2.Visible = false;
            }
            if (panel_menu3.Visible == true)
            {
                panel_menu3.Visible = false;
            }if (panel_menu4.Visible == true)
            {
                panel_menu4.Visible = false;
            }
        }


        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void panelSet(Form1 form)
        {
            form.TopLevel = false;
            panel_content.Controls.Add(form);

            form.Show();
        }

     

        private void btn_menu1_1_Click(object sender, EventArgs e)
        {
            
            
            //hideSubMenu();
        }
        private void btn_menu1_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_menu1);
        }
        private void btn_menu2_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_menu2);
        }

        private void btn_menu3_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_menu3);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_menu4);
        }
        private void panel_content_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_menu3_1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.TopLevel = false;
            form1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_content.Controls.Add(form1);
            form1.Show();
        }

       
    }
}
