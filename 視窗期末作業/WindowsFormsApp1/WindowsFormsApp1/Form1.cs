using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        

        public Form1()
        {
            InitializeComponent();
        }
        bool serialFlag = false;
        string tmp;
        double tmp1;
        private void button1_Click(object sender, EventArgs e)
        {
            if (serialFlag == true)
            {
                button1.Text = "連接營區溫度感測器";
                label2.Text = "中止連線";
                label2.ForeColor = Color.Red;
                serialFlag = false;
                timer1.Enabled = false;
                serialPort1.Close();
                
            }
            else
            {
                button1.Text = "中止連線";
                label2.Text = "成功連線";
                label2.ForeColor = Color.Green;
                serialFlag = true;
                serialPort1.Open();
                serialPort1.DiscardInBuffer();
                timer1.Enabled = true;
            }
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string InString = "";           
            string tString = "";
            
            byte[] Dbyte;
            try {
                InString = serialPort1.ReadExisting();
                if (InString.Length == 0) {   
                    return;                 
                } else {
                    tmp = InString;
                    label4.Text = InString ;
                    tmp1 = Convert.ToDouble(label4.Text);
                    tmp1 = (tmp1 * 9 / 5) + 32;
                }
                

              
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString(), "錯誤通知");
            }
            double i = 0.0, a = 0;
            if(a != null)
            {
                i = Convert.ToDouble(label4.Text);
                if (i < 35)
                {
                    pictureBox1.Image = Properties.Resources.blue;
                    pictureBox2.Image = Properties.Resources.JPG1;
                    textBox2.Text = "藍旗" + "\r\n" + "照常操課"+ "\r\n"+"請多補充水分!";
                }
                if ((i > 35) && (i < 40))
                {
                    pictureBox1.Image = Properties.Resources.yellow;
                    pictureBox2.Image = Properties.Resources.JPG2;
                    textBox2.Text = "黃旗" + "\r\n" + "照常操課" + "\r\n" + "注意官兵身心!";
                }
                if (i > 40)
                {
                    pictureBox1.Image = Properties.Resources.red;
                    pictureBox2.Image = Properties.Resources.JPG3;
                    textBox2.Text = "紅旗" + "\r\n" + "停止操課" + "\r\n" + "強制補充水分!";
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString();
        }
    }
}
