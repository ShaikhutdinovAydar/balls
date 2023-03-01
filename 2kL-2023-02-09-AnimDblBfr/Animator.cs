using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2kL_2023_02_09_AnimDblBfr
{
    public class Animator
    {
        private Circle c;
        private Thread t;
        private bool isAlive;
        private int indCircle = 0;
        public List<Animator> Animators { get; set; }
        private Random r = new();
        public Size ContainerSize { get; set; }

        public Animator(Size containerSize)
        {
            ContainerSize = containerSize;
            c = new Circle(50, r.Next(ContainerSize.Width - 50), r.Next(ContainerSize.Height - 50), indCircle);
            indCircle += 1;
        }
        private int RandomInter()
        {
            int newRandom = 0;
            while (newRandom == 0)
            {
                newRandom = r.Next(-5, 5);
            }
            return newRandom;
        }
        public void Start(List<Animator> animators)
        {
            int dx = RandomInter();
            int dy = RandomInter();
            isAlive = true;

            t = new Thread(() =>
            {
                while (isAlive)
                {
                    if (c.X + c.Diam >= ContainerSize.Width || c.X <= 0)
                    {
                        dx = -dx;
                    }
                    if (c.Y + c.Diam >= ContainerSize.Height || c.Y <= 0)
                    {
                        dy = -dy;
                    }
                    foreach (Animator animator in animators)
                    {
                        if (c.IndCircle != animator.c.IndCircle)
                        {

                            double Dx = c.X - animator.c.X;
                            double Dy = c.Y - animator.c.Y;
                            double d = Math.Sqrt((Dx * Dx + Dy * Dy));
                            if (d == 0) d = 0.01;
                            double s = Dx / d;
                            double e = Dx / d;
                            if (d < c.Diam + animator.c.Diam)
                            {
                                dx = -dx;
                            }
                        }
                    }
                    Thread.Sleep(30);
                    c.Move(dx, dy);
                }
            });
            t.IsBackground = true;
            t.Start();
        }

        public void PaintCircle(Graphics g)
        {
            c.Paint(g);
        }
    }
}
