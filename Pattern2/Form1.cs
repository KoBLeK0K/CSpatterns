using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pattern2
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }
        public int getHeight()
        {
            return pictureBox1.Height;
        }
        public int getWidth()
        {
            return pictureBox1.Width;
        }
        
        //круг
        private void button1_Click(object sender, EventArgs e)
        {
            Ellipse circle = new Ellipse(getColor());
            pictureBox1.Image = circle.Draw(300, 300);
            label1.Text = circle.String("Круг");

        }

        //эллипс
        private void button2_Click(object sender, EventArgs e)
        {
            Ellipse ellipse = new Ellipse(getColor());
            pictureBox1.Image = ellipse.Draw(300, 150);
            label1.Text = ellipse.String("Эллипс");
        }

        //прямоугольник
        private void button3_Click(object sender, EventArgs e)
        {
            Rectangle rectangle = new Rectangle(getColor());
            pictureBox1.Image = rectangle.Draw(100, 300);
            label1.Text = rectangle.String("Прямоугольник");
        }

        //скругленный прямоугольник
        private void button4_Click(object sender, EventArgs e)
        {
            CirqRectangle cirqRectangle = new CirqRectangle(getColor());
            pictureBox1.Image = cirqRectangle.Draw(300, 100);
            label1.Text = cirqRectangle.String("Скругленный прямоугольник");
        }

        //квадрат
        private void button5_Click(object sender, EventArgs e)
        {
            Rectangle square = new Rectangle(getColor());
            pictureBox1.Image = square.Draw(200, 200);
            label1.Text = square.String("Квадрат");
        }
        public Color getColor()
        {
            Color color;
            {
                if (radioButton1.Checked) return color = Color.Yellow;
                else if (radioButton2.Checked) return color = Color.Red;
                else if (radioButton3.Checked) return color = Color.Green;
                else return color = Color.Purple;
            }
        }
    }
    abstract class Shape
    {
        public int length;
        public int width;
        public SolidBrush pen;
        public SolidBrush myPen;

        public Shape()
        {
            length = 40;
            width = 40;
            pen = new SolidBrush(Color.White);
        }
        public string String(string nameShape)
        {
            return nameShape;
        }
        abstract public Image Draw(int posX, int posY);
    }

    
    class Ellipse : Shape
    {
        public Ellipse(Color color)
        {
            myPen = new SolidBrush(color);
        }
        public override Image Draw(int posX, int posY)
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.FillEllipse(myPen, length, width, posX, posY);
            return pictureBox;
        }
    }


    class Rectangle : Shape
    {
        public Rectangle(Color color)
        {
            myPen = new SolidBrush(color);
        }
        public override Image Draw(int posX, int posY)
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.FillRectangle(myPen, length, width, posY, posX);
            return pictureBox;
        }
    }


    class CirqRectangle : Shape
    {
        public CirqRectangle(Color color)
        {
            myPen = new SolidBrush(color);
        }
        public override Image Draw(int posX, int posY)
        {
            Form1 form1 = new Form1();
            Pen pen2 = new Pen(Color.White, 20);
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.FillRectangle(myPen, length, width, posX, posY);
            graph.DrawEllipse(pen2, length - 20, width - 50, posX + 40, posY + 100);
            return pictureBox;
        }
    }
}
