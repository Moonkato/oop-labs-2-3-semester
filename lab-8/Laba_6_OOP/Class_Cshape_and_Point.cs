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
    public abstract class CShape : observer , IMyObservable
    {
        public bool active;
        public bool flag_circle;
        public bool flag_triangle;
        public bool flag_square;
        public bool isMoveable;
        public int upper_border;
        public int lower_border;
        public int right_border;
        public int left_border;
        public PictureBox picturebox1;
        public List<CShape> observers;
        public List<IMyObserver> _obs;


        public CShape()
        {
            observers = new List<CShape>();
            _obs = new List<IMyObserver>();

            isMoveable = true;
        }

        public void AddObserver(IMyObserver o)
        {
            _obs.Add(o);
        }
        public void RemoveObserver(IMyObserver o)
        {
            _obs.Remove(o);
        }

        public void NotifyCreate()
        {
            for (int i = 0; i < _obs.Count; ++i)
                if(this is Point)
                    _obs[i].UpdateCreate_with_cnt(this);
                else
                {
                    _obs[i].UpdateCreate_with_cnt(this);
                    break;
                }
        }

        public void NotifySelect()
        {
            for (int i = 0; i < _obs.Count; ++i)
            if (this is Point)
                _obs[i].UpdateSelect(this);
            else
            {
                _obs[i].UpdateSelect(this);
                break;
            }
        }

        public void NotifyDelete_with_cnt()
        {
            for (int i = 0; i < _obs.Count; ++i)
                _obs[i].UpdateDelete_with_cnt(this);
        }

        public void NotifyDelete_without_cnt()
        {
            for (int i = 0; i < _obs.Count; ++i)
                _obs[i].UpdateDelete_without_cnt(this);
        }


        public abstract void save(FileInfo fileInf, StreamWriter sw);

        public abstract CShape load(FileInfo fileInf, int hod, StreamReader sr, Form form_1);

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

        void observer.move(int dx, int dy)
        {
            this.move(dx, dy);
        }

        void observer.resize(int new_size)
        {
            this.resize(new_size);
        }

        public void add_observer(CShape smth)
        {
            observers.Add(smth);
        }

        public void remove_observer(CShape smth)
        {
            observers.Remove(smth);
        }

        public void NotifyAdd()
        {
            add_observer(this);
        }

        public void NotifyActive()
        {
            this.activate();
        }

        public void NotifyRemove()
        {
            remove_observer(this);
        }

        public void NotifyMove(int dx,int dy)
        {
            foreach(CShape smth in observers)
            {
                smth.isMoveable = true;

                if (smth is Folder)
                {
                    CShape temp_group = new CMyFolder(0);
                    (temp_group as Folder).add_object_without_notifiy(smth);
                    temp_group.activate();
                    temp_group.move(dx, dy);
                    temp_group.deactivate();
                }
                else
                {
                    smth.move(dx, dy);
                }

                smth.isMoveable = false;
                smth.NotifyMove(dx,dy);
            }
        }

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

        public override CShape load(FileInfo fileInf, int hod, StreamReader sr, Form form_1)
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
