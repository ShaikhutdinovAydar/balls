using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2kL_2023_02_09_AnimDblBfr
{
    public class Circle
    {
        private Random r = new();
        private int diam;
        private int x, y;
        private int indCircle;

        public int X => x;
        public int Y => y;
        public int Diam => diam;
        public int IndCircle => indCircle;
        public Color Color { get; set; }

        public Circle(int diam, int x, int y, int indCircle, Color color)
        {
            this.diam = diam;
            this.x = x;
            this.y = y;
            this.Color = color;
            this.indCircle = indCircle;
        }

        public Circle(int diam, int x, int y, int indCircle)
        {
            this.diam = diam;
            this.x = x;
            this.y = y;
            this.Color = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            this.indCircle = indCircle;
        }

        public void Move(int dx, int dy)
        {
            x += dx;
            y += dy;
        }

        public void Paint(Graphics g)
        {
            var brush = new SolidBrush(Color);
            g.FillEllipse(brush, X, Y, Diam, Diam);
        }
    }
}
