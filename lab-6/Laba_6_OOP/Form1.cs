using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Laba_6_OOP;
using System.Runtime.CompilerServices;

namespace Laba_4_1_OOP
{
    public partial class Form1 : Form
    {
        Folder folder_1 = new Folder(0);

        public Form1()
        {
            InitializeComponent();
        }

        bool ctrl = false;

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.ControlKey)
                ctrl = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.ControlKey)
                ctrl = true;


            if(e.KeyValue == (char)Keys.A)
            {
                folder_1.moveLeft(-15,0);
                folder_1.paint(pictureBox1);
            }

            if(e.KeyValue == (char)Keys.D)
            {
                folder_1.moveRight(15,0);
                folder_1.paint(pictureBox1);
            }

            if(e.KeyValue == (char)Keys.W)
            {
                folder_1.moveTop(0,-15);
                folder_1.paint(pictureBox1);
            }

            if(e.KeyValue == (char)Keys.S)
            {
                folder_1.moveBottom(0,15);
                folder_1.paint(pictureBox1);
            }


            if (e.KeyValue == (char)Keys.Delete)
            {
                folder_1.del_active();
                folder_1.paint(pictureBox1);
            }
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            this.ActiveControl = null;

            if (ctrl != true)
                folder_1.deact_all();

            folder_1.probeg(e.X, e.Y);
            folder_1.paint(pictureBox1);
        }
        private void change_color_button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;

                folder_1.changecolor(color);
                this.ActiveControl = null;
                folder_1.paint(pictureBox1);

            }
        }



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            folder_1.paint(pictureBox1);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.X.ToString();
            label2.Text = e.Y.ToString();
            folder_1.picturebox1 = pictureBox1;
        }

        private void Button_Circle_Click(object sender, EventArgs e)
        {
            folder_1.flag_circle = true;
            folder_1.flag_square = false;
            folder_1.flag_triangle = false;
        }
        private void Button_Square_Click(object sender, EventArgs e)
        {
            folder_1.flag_circle = false;
            folder_1.flag_square = true;
            folder_1.flag_triangle = false;
        }
        private void Button_Rectangular_Click_1(object sender, EventArgs e)
        {
            folder_1.flag_circle = false;
            folder_1.flag_square = false;
            folder_1.flag_triangle = true;
        }

        int size;

        private void resize_box_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (char)Keys.Enter)
            {
                size = Convert.ToInt32(resize_box.Text);

                folder_1.resize(size);
                this.ActiveControl = null;
                folder_1.paint(pictureBox1);
            }
        }
    }
}

public class Object
{
    protected int x;
    protected int y;
    protected Color color;
    public PictureBox picturebox1;

    public bool active;

    public Object(int x_1, int y_1, PictureBox pictureBox)
    {
        active = true;
        this.x = x_1;
        this.y = y_1;
        this.color = Color.Black;
        this.picturebox1 = pictureBox;
    }

    public void change_active()
    {
        this.active = !(this.active);
    }

    public void activate()
    {
        this.active = true;
    }

    public void deactivate()
    {
        this.active = false;
    }


    public bool isActive()
    {
        return this.active;
    }

    public void changecolor(Color color)
    {
        this.color = color;
    }

    public virtual void Paint(PictureBox picturebox1, Graphics g)
    {

    }

    public virtual bool Selected(int x, int y) { return false; }

    public virtual void resize(int new_size) { }

    public virtual void move(int x, int y) { }

    protected virtual void changes_accepted(int dx,int dy,int new_size) { }


    ~Object()
    {
        Console.Write("Диструктор класса object");
    }
}


class CCircle : Object
{
    protected int radius;

    public CCircle(int x_1, int y_1, PictureBox picturebox1) : base(x_1, y_1,picturebox1)
    {
        this.radius = 100;
    }

    public override bool Selected(int x_1, int y_1)
    {
        if ((Math.Pow((x_1 - this.x),2) + Math.Pow((y_1 - this.y),2)) < this.radius/2 * this.radius/2)
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
        Pen  blackPen = new Pen(this.color, active?3:1);

        Rectangle rect = new Rectangle(this.x - (this.radius / 2), this.y - (this.radius / 2), this.radius, this.radius);
        g.DrawEllipse(blackPen, rect);
    }

    protected override void changes_accepted(int dx,int dy,int new_size)
    {
        if(((this.y + new_size/2) < picturebox1.Width)&&((this.y - new_size/2)>0)&&((this.x - new_size/2) > 0)&&((this.x + new_size/2) < picturebox1.Height))
          this.radius = new_size;

        if (dy > 0)
        {
            if((this.y + radius/2 + dy) < picturebox1.Height - dy)
                 this.y = this.y + dy;
        }
        else
        {
            if((this.y - radius/2 + dy) > 0)
                 this.y = this.y + dy;
        }

        if (dx < 0)
        {
            if((this.x - radius/2  + dx) > 0)
                this.x = this.x + dx;
        }
        else
        {

            if((this.x + radius/2 + dx) < picturebox1.Width - dx)
            this.x = this.x + dx;
        }
    }

    public override void resize(int new_size)
    {
        changes_accepted(0,0,new_size);
    }

    public override void move(int dx, int dy)
    {
        changes_accepted(dx,dy,this.radius);
    }

}




public class Folder
{
    public Object[] objects;
    public int folder_size;

    public PictureBox picturebox1;
    public bool flag_circle;
    public bool flag_triangle;
    public bool flag_square;

    private void increase_array(Object[] objectss, int array_size, int new_array_size)
    {

        Object[] new_objects = new Object[new_array_size];

        for (int i = 0; i < new_array_size; i++)
            if (i < array_size)
                new_objects[i] = objects[i];
            else
                new_objects[i] = null;

        this.folder_size = new_array_size;
        this.objects = new_objects;

    }
    public Folder(int folder_sizee)
    {
        Console.Write("Конструктор по умолчанию класса folder");
        this.folder_size = folder_sizee;
        this.objects = new Object[folder_sizee];
        this.picturebox1 = picturebox1;

        flag_circle = false;
        flag_square = false;
        flag_triangle = false;

        for (int i = 0; i < folder_size; i++)
        {
            objects[i] = null;
        }
    }

    public void deact_all()
    {
        for (int i = 0; i < folder_size; ++i)
            if (objects[i] != null)
                objects[i].deactivate();
    }

    public void del_active()
    {
        for (int i = 0; i < folder_size; ++i)
            if (objects[i] != null)
                if (objects[i].isActive())
                    objects[i] = null;
    }

    public void probeg(int x_1, int x_2)
    {
        bool reactive = false;

        for (int i = 0; i < folder_size; i++)
        {
            if (objects[i] != null)
                if (objects[i].Selected(x_1, x_2))
                {
                    objects[i].change_active();
                    reactive = true;
                    break;
                }
        }

        if (reactive == false)
        {
            if (flag_circle == true)
            {
                CCircle circle = new CCircle(x_1, x_2, picturebox1);
                add_object(circle);

                for (int i = 0; i < folder_size + 1; i++)
                {
                    if (objects[i] != null)
                        if (objects[i].Selected(x_1, x_2))
                        {
                            objects[i].activate();
                            break;
                        }
                }
            }
            else if (flag_square == true)
            {
                Square square = new Square(x_1, x_2, picturebox1);
                add_object(square);

                for (int i = 0; i < folder_size + 1; i++)
                {
                    if (objects[i] != null)
                        if (objects[i].Selected(x_1, x_2))
                        {
                            objects[i].activate();
                            break;
                        }
                }
            }
            else if (flag_triangle == true)
            {
                Triangle triangle = new Triangle(x_1, x_2 , picturebox1);
                add_object(triangle);

                for (int i = 0; i < folder_size + 1; i++)
                {
                    if (objects[i] != null)
                        if (objects[i].Selected(x_1, x_2))
                        {
                            objects[i].activate();
                            break;
                        }
                }
            }

        }

    }

    public void paint(PictureBox picturebox1)
    {
        Graphics g = picturebox1.CreateGraphics();
        g.Clear(Color.White);

        for (int i = 0; i < folder_size; i++)
        {
            if (objects[i] != null)
                objects[i].Paint(picturebox1, g);
        }
    }




    public bool check_by_index(int index)
    {
        if (index < folder_size)
        {
            if (objects[index] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    public void add_object(Object something)
    {
        CCircle circlecheck = something as CCircle;

        bool mesto = false;
        for (int i = 0; i < folder_size; i++)
        {
            if (objects[i] == null)
            {
                mesto = true;
                objects[i] = something;
            }
        }
        if (mesto == false)
        {
            set_object(folder_size, something);
        }

    }

    public void resize(int new_size)
    {
        for (int i = 0; i < folder_size; i++)
        {
            if (objects[i] != null)
            {
                if (objects[i].isActive())
                {
                    objects[i].resize(new_size);
                }
            }
        }
    }

    public void moveLeft(int dx,int dy)
    {
        for(int i=0; i< folder_size; i++)
        {
            if (objects[i] != null)
            {
                if (objects[i].isActive())
                {
                    objects[i].move(dx,dy);
                }
            }
        }
    }

    public void moveRight(int dx,int dy)
    {
        for (int i = 0; i < folder_size; i++)
        {
            if (objects[i] != null)
            {
                if (objects[i].isActive())
                {
                    objects[i].move(dx,dy);
                }
            }
        }
    }

    public void moveTop(int dx, int dy)
    {
        for (int i = 0; i < folder_size; i++)
        {
            if (objects[i] != null)
            {
                if (objects[i].isActive())
                {
                    objects[i].move(dx,dy);
                }
            }
        }
    }

    public void moveBottom(int dx, int dy)
    {
        for (int i = 0; i < folder_size; i++)
        {
            if (objects[i] != null)
            {
                if (objects[i].isActive())
                {
                    objects[i].move(dx,dy);
                }
            }
        }
    }

    public void changecolor(Color color)
    {
        for(int i = 0; i < folder_size; i++)
        {
            if (objects[i] != null)
            {
                if (objects[i].isActive())
                {
                    objects[i].changecolor(color);
                }
            }
        }
    }

    public void set_object(int index, Object something)
    {
        if (index >= this.folder_size)
        {
            increase_array(objects, folder_size, index + 1);
            objects[index] = something;
        }
    }



    public Object get_object(int index)
    {
        if (check_by_index(index) == true)
            return this.objects[index];
        else
            return null;
    }


    ~Folder()
    {
        Console.Write("Хранилище было удалено");
    }
}