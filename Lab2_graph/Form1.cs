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
    public partial class Form1 : Form{
    
       
        public Form1(){
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e){ //Отрисовка рамки и осей
            /* int ex = 0, ey = 0, old_ex = 0, old_ey = 0;
             double x = 0, y = 0;
             */
            Form2 DrawYourColor = new Form2();
            DrawYourColor.ShowDialog();

            Pen Pen = new Pen(Color.Red, 1);

            Graphics graphick = pictureBox1.CreateGraphics();
            
            /*
                        graphick.DrawRectangle(Pen, 0, 0, pictureBox1.Size.Width-1, pictureBox1.Size.Height - 1);

                        graphick.DrawLine(Pen, 400, 0, pictureBox1.Size.Width / 2, pictureBox1.Size.Height-1);

                        graphick.DrawLine(Pen,0, 200, pictureBox1.Size.Width , pictureBox1.Size.Height / 2);*/

            // экранные координаты
            int ex = 0, ey = 0, old_ex = 0, old_ey = 0;

            // математические значения
            double x = 0, y = 0;

            // цвет осей и рамки
            Pen axesPen = new Pen(Color.Red, 1);

            // цвет графика
            Pen graphicsPen = Data.pen;

            // Устанавливаем фон pictureBox1 в именованный цвет

            pictureBox1.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
            pictureBox1.Refresh();

            pictureBox1.Refresh();

            // Стандарт страничного пространства в Pixel
            graphick.PageUnit = GraphicsUnit.Pixel;

            //Рисуем прямоугольник:
            graphick.DrawRectangle(axesPen, 0, 0,pictureBox1.Size.Width - 1, pictureBox1.Size.Height - 1);
            
            // Рисуем оси
            graphick.DrawLine(axesPen, 0, (pictureBox1.Size.Height - 1) / 2,
            pictureBox1.Size.Width - 1, (pictureBox1.Size.Height - 1) / 2);
            graphick.DrawLine(axesPen, (pictureBox1.Size.Width - 1) / 2, 0,
            (pictureBox1.Size.Width - 1) / 2, pictureBox1.Size.Height - 1);

            // Рисуем график функции y=Cos(x)
            x = -Math.PI * 2;
            for (ex = 0; ex <= 1000; ex++)
            {
                y = Math.Cos(x);
                ey = (pictureBox1.Size.Height - 1) - (Convert.ToInt16(y * 200) + 200);
                if (ex != 0) { graphick.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); }
                old_ex = ex; old_ey = ey;
                x = x + (Math.PI * 4) / (pictureBox1.Size.Width - 1);
            }
            graphick.Dispose();
        }

        //Очистка PictureBox
        private void button2_Click(object sender, EventArgs e){ 
       
            if (pictureBox1 != null){
            
                pictureBox1.Image = null;
            }
        }

        private void button3_Click(object sender, EventArgs e) {

            Form2 DrawYourColor = new Form2();
            DrawYourColor.ShowDialog();

            int ex = 0, ey = 0, old_ex = 0, old_ey = 0;

            double x = 0, y = 0;
            Graphics g = pictureBox1.CreateGraphics();
            g.PageUnit = GraphicsUnit.Millimeter;

            //Цвет графика
            Pen axesPen = new Pen(Color.Red, 0.1f);
            Pen graphicsPen = Data.Millimeter;

            // Устанавливаем фон pictureBox1 в именованный цвет
            pictureBox1.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
  
            pictureBox1.Refresh();
            //Получаем ширину и высоту прямоугольника в миллиметрах
            int WidthInMM = Convert.ToInt16((pictureBox1.Size.Width - 1) /
            g.DpiX * 25.4);
            int HeightInMM = Convert.ToInt16((pictureBox1.Size.Height - 1) /
            g.DpiY * 25.4);

            //Рисуем прямоугольник
            g.DrawRectangle(axesPen, 0, 0, WidthInMM, HeightInMM);
            // Рисуем оси
            g.DrawLine(axesPen, 0, HeightInMM / 2, WidthInMM, HeightInMM / 2);
            g.DrawLine(axesPen, WidthInMM / 2, 0, WidthInMM / 2, HeightInMM);
            // Рисуем график функции y=Sin(x)
            x = -Math.PI * 2;
            for (ex = 0; ex <= WidthInMM; ex++)
            {
                y = Math.Cos(x);
                ey = HeightInMM-(Convert.ToInt16(y * Convert.ToSingle(234 / g.DpiX * 22.4)) + Convert.ToInt16(232 / g.DpiX * 22.4));

                if (ex != 0) { g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); }
                old_ex = ex; old_ey = ey;
                x = x + (Math.PI * 4) / WidthInMM;
            }

        }

    }
    
}
