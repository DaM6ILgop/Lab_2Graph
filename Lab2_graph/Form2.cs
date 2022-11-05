using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_graph
{
    public partial class Form2 : Form
    {
        public Form2(){
        
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form2_Load(object sender, EventArgs e){
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty & textBox2.Text != string.Empty & textBox3.Text != string.Empty)
            {
                Data.pen.Color = Color.FromArgb(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                Data.Millimeter.Color = Color.FromArgb(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));         
                this.Close();
            }
        }
    }
}
