using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_4_part_1_New_version
{
    class CCircle : Object
    {
        protected int radius;

        public CCircle(int x_1, int y_1, int number) : base(x_1, y_1,number)
        {
            this.radius = 30;
        }

        public override bool Selected(int x_1, int y_1)
        {

            if ((Math.Pow((x_1 - this.x), 2) + Math.Pow((y_1 - this.y), 2)) < this.radius / 2 * this.radius / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Paint(PictureBox picturebox1, Graphics g)
        {

            if (active)
            {
                Pen blackPen = new Pen(Color.Black, 3);
                Rectangle rect = new Rectangle(this.x - (this.radius / 2), this.y - (this.radius / 2), this.radius, this.radius);
                g.DrawEllipse(blackPen, rect);
            }
            else
            {
                Pen blackPen = new Pen(Color.Black, 1);
                Rectangle rect = new Rectangle(this.x - (this.radius / 2), this.y - (this.radius / 2), this.radius, this.radius);
                g.DrawEllipse(blackPen, rect);
            }

            if (Con_Nodes != null)
            {
                for (int i = 0; i < Con_Nodes.Count; i++)
                {
                    Object smth = Con_Nodes[i];
                    if (smth != null)
                    {
                        int prev_x1 = smth.x;
                        int prev_y1 = smth.y;
                        Point p1 = new Point(this.x, this.y);
                        Point p2 = new Point(prev_x1, prev_y1);
                        Pen blackPen = new Pen(Color.Black, 1);
                        g.DrawLine(blackPen, p1, p2);
                    }


                }
            }
        }

    }

}
