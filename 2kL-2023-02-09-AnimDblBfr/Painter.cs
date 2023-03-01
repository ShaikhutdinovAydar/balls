using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2kL_2023_02_09_AnimDblBfr
{
    public class Painter
    {
        private Size containerSize;
        private Thread t;
        private Graphics mainGraphics;
        private bool isAlive = false;
        private BufferedGraphics bg;
        private List<Animator> animators = new();

        public List<Animator> Animators{
            get => animators;
            set
            {
                animators = value;
            }
        }

        public Graphics MainGraphics
        {
            get => mainGraphics;
            set
            {
                mainGraphics = value;
                ContainerSize = mainGraphics.VisibleClipBounds.Size.ToSize();
                bg = BufferedGraphicsManager.Current.Allocate(
                    mainGraphics, new Rectangle(new Point(0, 0), ContainerSize)
                );
            }
        }

        public Size ContainerSize
        {
            get => containerSize;
            set
            {
                containerSize = value;
                foreach (var animator in animators)
                {
                    animator.ContainerSize = containerSize;
                }
            }
        }

        public Painter(Graphics mainGraphics)
        {
            MainGraphics = mainGraphics;
        }

        public void AddNew()
        {
            var a = new Animator(ContainerSize);
            animators.Add(a);
            a.Start(animators);
        }

        public void Start()
        {
            isAlive = true;
            t = new Thread(() =>
            {
                try
                {
                    while (isAlive)
                    {
                        bg.Graphics.Clear(Color.White);
                        foreach (var animator in animators)
                        {
                            animator.PaintCircle(bg.Graphics);
                        }
                        bg.Render(MainGraphics);
                        Thread.Sleep(30);
                    }
                } catch { }
            });
            t.IsBackground = true;
            t.Start();
        }
        public void Stop()
        {
            isAlive = false;
        }
    }
}
