using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_6_OOP
{
    public abstract class CShape
    {
        public bool active;
        public bool flag_circle;
        public bool flag_triangle;
        public bool flag_square;
        public int upper_border;
        public int lower_border;
        public int right_border;
        public int left_border;
        public PictureBox picturebox1;


        public abstract void save(FileInfo fileInf, StreamWriter sw);

        public abstract CShape load(FileInfo fileInf, int hod, StreamReader sr);

        public abstract void change_active();

        public abstract void activate();

        public abstract void deactivate();
        public abstract void set_borders();
        public abstract bool isActive();

        public abstract void changecolor(Color color);
        public abstract void Paint(PictureBox picturebox1, Graphics g);
        public abstract void resize(int new_size);
        public abstract void move(int x, int y);
        public abstract bool Selected(int x, int y);
    };


    public class Point : CShape
    {
        public int x;
        public int y;
        protected Color color;



        public override void change_active()
        {
            this.active = !(this.active);
        }

        public override void set_borders() { }

        public override CShape load(FileInfo fileInf, int hod, StreamReader sr)
        {
            return null;
        }

        public override void save(FileInfo fileInf, StreamWriter sw)
        {
        }


        public override void activate()
        {
            this.active = true;
        }

        public override void deactivate()
        {
            this.active = false;
        }

        public override bool isActive()
        {
            return this.active;
        }

        public Point(int x_1, int y_1, PictureBox pictureBox)
        {
            active = true;
            this.x = x_1;
            this.y = y_1;
            this.color = Color.Black;
            this.picturebox1 = pictureBox;

        }

        public override void changecolor(Color color)
        {
            this.color = color;
        }
        public override void Paint(PictureBox picturebox1, Graphics g) { }
        public override void resize(int new_size) { }
        public override void move(int x, int y) { }
        protected virtual void changes_accepted(int dx, int dy, int new_size) { }
        public override bool Selected(int x_1, int y_1) { return false; }

        ~Point()
        {
            Console.Write("Диструктор класса object");
        }
    }
}
