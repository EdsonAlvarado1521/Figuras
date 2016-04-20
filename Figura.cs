using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    abstract class Figura
    {
        protected int X,Y;
        protected Pen pluma;
        protected SolidBrush brocha;
        protected Color color_contorno, color_relleno;
        protected int ancho, largo;

        public Figura(int x,int y)
        {
            X=x;
            Y=y;

            pluma = new Pen(Color.DarkRed,2);
            brocha = new SolidBrush(Color.Blue);
            Random rnd = new Random();
            ancho = rnd.Next(10, 60);
            largo =ancho;
        }

        public abstract void Dibuja(Form f);
        public int CompareTo(object obj)
        {

            return this.largo.CompareTo(((Figura)obj).largo);
        }

    }

    class Rectangulo : Figura
    {
        public Rectangulo(int x, int y) : base(x, y) 
        {
        }
        public override void Dibuja(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawRectangle(pluma, X, Y, ancho, largo);
            g.FillRectangle(brocha, this.X, this.Y, ancho, largo);
        }
    }

    class Circulo : Figura
    {
        public Circulo(int x, int y)
            : base(x, y)
        {
        }
        public override void Dibuja(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawEllipse(pluma, X, Y, ancho, largo);
            g.FillEllipse(brocha, this.X, this.Y, ancho, largo);
        }
    }
}
