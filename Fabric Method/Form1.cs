using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fabric_Method
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int getHeight()
        {
            return pictureBox1.Height;
        }
        public int getWidth()
        {
            return pictureBox1.Width;
        }

        private void numberOfSights_TextChanged(object sender, EventArgs e)
        {
        
            if (numberOfSights.Text is null)
                numberOfSights.Text = "0";
            ShapeFactory factory = new ShapeFactory();
            Shape shapePolygon = ShapeFactory.GetShape(Convert.ToInt32(numberOfSights.Text));
            if(Convert.ToInt32(numberOfSights.Text) <= 5)
            pictureBox1.Image = shapePolygon.Draw();
            else
            {
                MessageBox.Show("Error. Enter num from 0 to 5");
                numberOfSights.Text = "0";
            }
            label2.Text = shapePolygon.Descriptor();
        }
    }
    public class ShapeFactory
    {
        public static Shape GetShape(int numbOfSides)
        {
            switch (numbOfSides)
            {
                case 0:
                    return new Ellipse();
                case 1:
                    return new Line();
                case 2:
                    return new Angle();
                case 3:
                    return new Triangle();
                case 4:
                    return new Rectangle();

                default: return new Pentagon();
            }

        }
    }
    abstract public class Shape
    {
        public int x1;
        public int y1;
        public SolidBrush pen;
        public Pen myPen;

        public Shape()
        {
            x1 = 40;
            y1 = 40;
            pen = new SolidBrush(Color.White);
            myPen = new Pen(Color.Blue);
        }
        abstract public Image Draw();
        abstract public string Descriptor();
    }

    class Ellipse : Shape
    {
       
        public override Image Draw()
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.DrawEllipse(myPen, x1, y1,100 ,100 );
            return pictureBox;
        }
        public override string Descriptor()
        {
            return "Circle";
        }
    }
    class Line : Shape
    {

        public override Image Draw()
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.DrawLine(myPen, x1, y1, 200, 200);
            return pictureBox;
        }
        public override string Descriptor()
        {
            return "Line";
        }
    }
    class Angle : Shape
    {
        public override Image Draw()
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.DrawLine(myPen, 100, 100, 200, 200);
            graph.DrawLine(myPen, 200, 200, 100, 200);
            return pictureBox;
        }
        public override string Descriptor()
        {
            return "Angle";
        }
    }
      
    class Triangle : Shape
    {
        
        public override Image Draw()
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);

            PointF p1 = new PointF(100, 100);
            PointF p2 = new PointF(200, 200);
            PointF p3 = new PointF(200, 100);
            PointF[] curvePoints =
            {
                p1,p2,p3
            };
            graph.DrawPolygon(myPen, curvePoints);
            return pictureBox;
        }
        public override string Descriptor()
        {
            return "Triangle";
        }
    }

    class Rectangle : Shape
    {

        public override Image Draw()
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.DrawRectangle(myPen, x1, y1, 200, 200);
            return pictureBox;
        }
        public override string Descriptor()
        {
            return "Rectangle";
        }
    }

    class Pentagon : Shape
    {
        public override Image Draw()
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            PointF p1 = new PointF(150,100);
            PointF p2 = new PointF(200,150);
            PointF p3 = new PointF(175,200);
            PointF p4 = new PointF(125,200);
            PointF p5 = new PointF(100,150);

            PointF[] curvePoints =
            {
                p1,p2,p3,p4,p5
            };
            graph.DrawPolygon(myPen, curvePoints);
            return pictureBox;
        }
        public override string Descriptor()
        {
            return "Pentagon";
        }
    }
}
