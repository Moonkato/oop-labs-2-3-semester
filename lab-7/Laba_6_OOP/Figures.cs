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
    class CCircle : Point
    {
        protected int radius;

        public CCircle(int x_1, int y_1, PictureBox picturebox1) : base(x_1, y_1, picturebox1)
        {
            this.radius = 100;
        }
        public override void set_borders()
        {
            this.upper_border = this.y - radius / 2;
            this.lower_border = this.y + radius / 2;
            this.right_border = this.x + radius / 2;
            this.left_border = this.x - radius / 2;
        }



        public override CShape load(FileInfo fileInf, int hod, StreamReader sr)
        {
            if (!fileInf.Exists)
            {
                fileInf.Create();
            }


            string data_to_load = sr.ReadLine();

            string[] data;

            data = data_to_load.Split();

            int x_1 = Convert.ToInt32(data[0]);
            int x_2 = Convert.ToInt32(data[1]);
            int radius = Convert.ToInt32(data[2]);

            CShape circle = new CCircle(x_1, x_2, picturebox1);
            circle.resize(radius);

            return circle;
        }

        public override void save(FileInfo fileInf, StreamWriter sw)
        {

            string code = "C";

            sw.WriteLine(code);

            string data = this.x.ToString() + " " + this.y.ToString() + " " + this.radius.ToString();

            sw.WriteLine(data);
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
            Pen blackPen = new Pen(this.color, active ? 3 : 1);

            Rectangle rect = new Rectangle(this.x - (this.radius / 2), this.y - (this.radius / 2), this.radius, this.radius);
            g.DrawEllipse(blackPen, rect);
        }

        protected override void changes_accepted(int dx, int dy, int new_size)
        {
            if (((this.y + new_size / 2) < picturebox1.Height) && ((this.y - new_size / 2) > 0) && ((this.x - new_size / 2) > 0) && ((this.x + new_size / 2) < picturebox1.Width))
                this.radius = new_size;

            if (dy > 0)
            {
                if ((this.y + radius / 2 + dy) < picturebox1.Height)
                    this.y = this.y + dy;
            }
            else
            {
                if ((this.y - radius / 2 + dy) > 0)
                    this.y = this.y + dy;
            }

            if (dx < 0)
            {
                if ((this.x - radius / 2 + dx) > 0)
                    this.x = this.x + dx;
            }
            else
            {

                if ((this.x + radius / 2 + dx) < picturebox1.Width)
                    this.x = this.x + dx;
            }
        }


        public override void resize(int new_size)
        {
            changes_accepted(0, 0, new_size);
        }

        public override void move(int dx, int dy)
        {
            changes_accepted(dx, dy, this.radius);
        }

    }

    class Square : Point
    {
        protected int width;

        public Square(int x_1, int y_1, PictureBox picturebox1) : base(x_1, y_1, picturebox1)
        {
            this.width = 100;
        }

        public override void set_borders()
        {
            this.upper_border = this.y - width / 2;
            this.lower_border = this.y + width / 2;
            this.right_border = this.x + width / 2;
            this.left_border = this.x - width / 2;
        }


        public override CShape load(FileInfo fileInf, int hod, StreamReader sr)
        {

            string data_to_load = sr.ReadLine();

            string[] data;

            data = data_to_load.Split();

            int x_1 = Convert.ToInt32(data[0]);
            int x_2 = Convert.ToInt32(data[1]);
            int width = Convert.ToInt32(data[2]);

            CShape square = new Square(x_1, x_2, picturebox1);
            square.resize(width);

            return square;
        }

        public override void save(FileInfo fileInf, StreamWriter sw)
        {

            string code = "S";

            sw.WriteLine(code);

            string data = this.x.ToString() + " " + this.y.ToString() + " " + this.width.ToString();

            sw.WriteLine(data);
        }

        public override bool Selected(int x_1, int y_1)
        {
            if ((Math.Abs(x_1 - this.x) + Math.Abs(y_1 - this.y)) < this.width)
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
            Pen blackPen = new Pen(this.color, active ? 3 : 1);

            Rectangle rect = new Rectangle(this.x - (this.width / 2), this.y - (this.width / 2), this.width, this.width);
            g.DrawRectangle(blackPen, rect);
        }

        protected override void changes_accepted(int dx, int dy, int new_size)
        {
            if (((this.y + new_size / 2) < picturebox1.Height) && ((this.y - new_size / 2) > 0) && ((this.x - new_size / 2) > 0) && ((this.x + new_size / 2) < picturebox1.Width))
                this.width = new_size;

            if (dy > 0)
            {
                if ((this.y + width / 2 + dy) < picturebox1.Height)
                    this.y = this.y + dy;
            }
            else
            {
                if ((this.y - width / 2 + dy) > 0)
                    this.y = this.y + dy;
            }

            if (dx > 0)
            {
                if ((this.x + width / 2 + dx) < picturebox1.Width)
                    this.x = this.x + dx;
            }
            else
            {
                if ((this.x - width / 2 + dx) > 0)
                    this.x = this.x + dx;
            }
        }
        public override void resize(int new_size)
        {
            changes_accepted(0, 0, new_size);
        }

        public override void move(int dx, int dy)
        {
            changes_accepted(dx, dy, this.width);
        }

    }

    class My_Rectangle : Point
    {
        public int width;
        public int length;

        public My_Rectangle(int x_1, int y_1, PictureBox picturebox1) : base(x_1, y_1, picturebox1)
        {
            this.width = 100;
            this.length = 300;
        }

        public override void set_borders()
        {
            //this.upper_border = this.y - width / 2;
            //this.lower_border = this.y + width / 2;
            //this.right_border = this.x + width / 2;
            //this.left_border = this.x - width / 2;
        }


        protected override void changes_accepted(int dx, int dy, int new_size)
        {
            //if (((this.y + new_size / 2) < picturebox1.Height) && ((this.y - new_size / 2) > 0) && ((this.x - new_size / 2) > 0) && ((this.x + new_size / 2) < picturebox1.Width))
            //    this.width = new_size;

            if (dy > 0)
            {
                if ((this.y + width / 2 + dy) < picturebox1.Height)
                    this.y = this.y + dy;
            }
            else
            {
                if ((this.y - width / 2 + dy) > 0)
                    this.y = this.y + dy;
            }

            if (dx > 0)
            {
                if ((this.x + length / 2 + dx) < picturebox1.Width)
                    this.x = this.x + dx;
            }
            else
            {
                if ((this.x - length / 2 + dx) > 0)
                    this.x = this.x + dx;
            }
        }
        public override void resize(int new_size)
        {
            //changes_accepted(0, 0, new_size);
        }
        public override void move(int dx, int dy)
        {
            changes_accepted(dx, dy, this.width);
        }
        public override CShape load(FileInfo fileInf, int hod, StreamReader sr)
        {

            //string data_to_load = sr.ReadLine();

            //string[] data;

            //data = data_to_load.Split();

            //int x_1 = Convert.ToInt32(data[0]);
            //int x_2 = Convert.ToInt32(data[1]);
            //int width = Convert.ToInt32(data[2]);

            //CShape square = new Square(x_1, x_2, picturebox1);
            //square.resize(width);

            //return square;
            return null;
        }

        public override void save(FileInfo fileInf, StreamWriter sw)
        {

            //string code = "S";

            //sw.WriteLine(code);

            //string data = this.x.ToString() + " " + this.y.ToString() + " " + this.width.ToString();

            //sw.WriteLine(data);
        }

        public override bool Selected(int x_1, int y_1)
        {
            //if ((Math.Abs(x_1 - this.x) + Math.Abs(y_1 - this.y)) < this.width)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }
        public override void Paint(PictureBox picturebox1, Graphics g)
        {
            Pen blackPen = new Pen(this.color, active ? 3 : 1);

            Rectangle rect = new Rectangle(this.x - (this.length / 2), this.y - (this.width / 2), this.length, this.width);
            g.DrawRectangle(blackPen, rect);
        }

    }


    class Triangle : Point
    {
        protected int dist_to_pea;

        public Triangle(int x_1, int y_1, PictureBox picturebox1) : base(x_1, y_1, picturebox1)
        {
            this.dist_to_pea = 50;
        }

        public override void set_borders()
        {
            this.upper_border = this.y - dist_to_pea;
            this.lower_border = this.y + dist_to_pea;
            this.right_border = this.x + dist_to_pea;
            this.left_border = this.x - dist_to_pea;
        }

        public override CShape load(FileInfo fileInf, int hod, StreamReader sr)
        {
            string data_to_load = sr.ReadLine();

            string[] data;

            data = data_to_load.Split();

            int x_1 = Convert.ToInt32(data[0]);
            int x_2 = Convert.ToInt32(data[1]);
            int dist_to_pea = Convert.ToInt32(data[2]);

            CShape triangle = new Triangle(x_1, x_2, picturebox1);
            triangle.resize(dist_to_pea);

            return triangle;

        }

        public override void save(FileInfo fileInf, StreamWriter sw)
        {

            string code = "T";

            sw.WriteLine(code);

            string data = this.x.ToString() + " " + this.y.ToString() + " " + dist_to_pea.ToString();

            sw.WriteLine(data);
        }

        public override bool Selected(int x_1, int y_1)
        {
            if ((Math.Pow((x_1 - this.x), 2) + Math.Pow((y_1 - this.y), 2)) < this.dist_to_pea / 2 * this.dist_to_pea)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected override void changes_accepted(int dx, int dy, int new_size)
        {
            if (((this.y + new_size) < picturebox1.Height - 30) && ((this.y - new_size) > 30) && ((this.x - new_size) > 30) && ((this.x + new_size) < picturebox1.Width - 30))
                this.dist_to_pea = new_size;

            if (dy > 0)
            {
                if ((this.y + dist_to_pea + dy) < picturebox1.Height)
                    this.y = this.y + dy;
            }
            else
            {
                if ((this.y - dist_to_pea + dy) > 0)
                    this.y = this.y + dy;
            }

            if (dx > 0)
            {
                if ((this.x + dist_to_pea + dx) < picturebox1.Width)
                    this.x = this.x + dx;
            }
            else
            {
                if ((this.x - dist_to_pea + dx) > 0)
                    this.x = this.x + dx;
            }

        }
        public override void Paint(PictureBox picturebox1, Graphics g)
        {
            Pen blackPen = new Pen(this.color, active ? 3 : 1);

            PointF point1 = new PointF(this.x, this.y - this.dist_to_pea);
            PointF point2 = new PointF(this.x + dist_to_pea, this.y + this.dist_to_pea);
            PointF point3 = new PointF(this.x - dist_to_pea, this.y + this.dist_to_pea);

            PointF[] curvePoints =
            {
            point1,
            point2,
            point3,
        };

            g.DrawPolygon(blackPen, curvePoints);

        }

        public override void resize(int new_size)
        {
            changes_accepted(0, 0, new_size);
        }

        public override void move(int dx, int dy)
        {
            changes_accepted(dx, dy, this.dist_to_pea);
        }



    }
}
