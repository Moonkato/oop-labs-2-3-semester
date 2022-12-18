using Laba_4_1_OOP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Laba_6_OOP
{
    public class Folder : CShape, IMyObservable
    {
        public CShape[] objects;
        public int folder_size;
        public int cnt;
        public int ent;

        public Folder(int folder_sizee)
        {
            Console.Write("Конструктор по умолчанию класса folder");
            this.folder_size = folder_sizee;
            this.objects = new CShape[folder_sizee];
            this.lower_border = 0;
            this.upper_border = 10000;
            this.right_border = 0;
            this.left_border = 10000;
            this.cnt = 0;

            for (int i = 0; i < folder_size; i++)
            {
                objects[i] = null;
            }
        }



        private void increase_array(CShape[] objectss, int array_size, int new_array_size)
        {

            CShape[] new_objects = new CShape[new_array_size];

            for (int i = 0; i < new_array_size; i++)
                if (i < array_size)
                    new_objects[i] = objects[i];
                else
                    new_objects[i] = null;

            this.folder_size = new_array_size;
            this.objects = new_objects;

        }

        public override void change_active()
        {
            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] != null)
                {
                    objects[i].change_active();
                }
            }
        }

        public override void activate()
        {
            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] != null)
                {
                    objects[i].activate();
                }
            }
        }

        public override void deactivate()
        {
            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] != null)
                {
                    objects[i].deactivate();
                }
                
            }
        }



        public override bool isActive()
        {
            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] != null)
                {
                    if (objects[i].isActive())
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public override bool Selected(int x, int y)
        {
            for (int i = 0; i < folder_size; i++)
            {
                if ((objects[i] != null) && (objects[i].Selected(x, y) == true))
                    return true;
            }

            return false;
        }

        public void deact_all()
        {
            for (int i = 0; i < folder_size; ++i)
                if (objects[i] != null)
                {
                    objects[i].deactivate();
                    objects[i].NotifySelect();
                }
        }


        public void del_active()
        {
            for (int i = 0; i < folder_size; ++i)
                if (objects[i] != null)
                    if (objects[i].isActive())
                    {
                        if (objects[i] is CMyFolder)
                            objects[i].NotifyDelete_with_cnt();
                        else
                            objects[i].NotifyDelete_with_cnt();

                        objects[i] = null;
                    }
                        
        }
        public void get_bottoms(List<String> bottoms)
        {
            for (int z = 0; z < folder_size; z++)
            {
                CShape smth_2 = objects[z];

                if (smth_2 is CMyFolder)
                    (smth_2 as CMyFolder).get_bottoms(bottoms);

                bottoms.Add(smth_2.GetType().Name + smth_2.GetHashCode());
            }
        }

        public void add_object_to_group_2(CShape group, Form form_1)
        {

            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] != null)
                    if (objects[i].isActive())
                    {
                        CShape smth_13;
                        smth_13 = objects[i];

                        (group as CMyFolder).add_object(smth_13);
                        (group as CMyFolder).set_borders();
                        objects[i].NotifyDelete_with_cnt();
                        objects[i].NotifyDelete_with_cnt();
                        objects[i] = null;
                    }
            }

            group.AddObserver(form_1 as IMyObserver);
        }

        public void del_object_from_group_2(Form form_1)
        {
            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] != null)
                {
                    if (objects[i].isActive())
                    {
                        for (int j = 0; j < (objects[i] as CMyFolder).folder_size; j++)
                        {
                            CShape element;
                            element = (objects[i] as CMyFolder).get_object(j);
                            add_object(element);
                            objects[i].NotifyDelete_without_cnt();
                            (objects[i] as CMyFolder).delete_object(j);
                        }
                        objects[i] = null;
                        break;
                    }

                }
            }
        }

        public void probeg(int x_1, int x_2, Form form_1)
        {
            bool reactive = false;

            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] != null)
                {
                    CShape smth = objects[i];

                    if (objects[i].Selected(x_1, x_2))
                    {
                        objects[i].change_active();
                        smth.NotifySelect();

                        for (int j = 0; j < folder_size; j++)
                        {
                            CShape smth_2 = objects[j];

                            if ((smth_2 != null) && (i != j) && (smth_2.observers.Contains(smth)))
                            {
                                smth.changecolor(Color.Green);
                            }
                        }

                        reactive = true;
                    }
                    else
                    {
                        smth.NotifySelect();
                    }
                }

            }

            if (reactive == false)
            {
                if (flag_circle == true)
                {
                    CShape circle = new CCircle(x_1, x_2, picturebox1);
                    circle.AddObserver(form_1 as IMyObserver);
                    add_object(circle);
                    circle.NotifySelect();
                    circle.set_borders();

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
                    CShape square = new Square(x_1, x_2, picturebox1);

                    square.AddObserver(form_1 as IMyObserver);
                    add_object(square);
                    square.NotifySelect();

                    square.set_borders();

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
                    CShape triangle = new Triangle(x_1, x_2, picturebox1);
                    triangle.AddObserver(form_1 as IMyObserver);
                    add_object(triangle);
                    triangle.NotifySelect();

                    triangle.set_borders();

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

        public override void Paint(PictureBox picturebox1, Graphics g)
        {
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
        public void delete_object(int index)
        {
            for (int i = 0; i < folder_size; i++)
            {
                if(i == index)
                    if (objects[i] == null)
                    {
                        if (objects[i] is Folder)
                            objects[i].NotifyDelete_with_cnt();
                        else
                            objects[i].NotifyDelete_without_cnt();

                        break;
                    }
            }

        }

        public void add_object(CShape something)
        {
            bool mesto = false;
            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] == null)
                {
                    mesto = true;
                    objects[i] = something;
                    cnt = i;
                    objects[i].NotifyCreate();

                    break;
                }
            }
            if (mesto == false)
            {
                set_object(folder_size, something);
            }

        }

        public void add_object_without_notifiy(CShape something)
        {
            bool mesto = false;
            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] == null)
                {
                    mesto = true;
                    objects[i] = something;
                    break;
                }
            }
            if (mesto == false)
            {
                set_object_without_notify(folder_size, something);
            }

        }

        public override void set_borders()
        {
            this.lower_border = 0;
            this.upper_border = 10000;
            this.right_border = 0;
            this.left_border = 10000;

            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] != null)
                {
                    if (objects[i].isActive())
                    {
                        objects[i].set_borders();

                        if (objects[i].right_border > this.right_border)
                            right_border = objects[i].right_border;
                        if (objects[i].left_border < this.left_border)
                            left_border = objects[i].left_border;
                        if (objects[i].upper_border < this.upper_border)
                            upper_border = objects[i].upper_border;
                        if (objects[i].lower_border > this.lower_border)
                            lower_border = objects[i].lower_border;
                    }
                }
            }
        }


        public override void resize(int new_size)
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
        void general_rec(ref int dx,ref int dy)
        {
            set_borders();

            int x_1 = ((this.right_border - this.left_border) / 2) + this.left_border;
            int y_1 = ((this.lower_border - this.upper_border) / 2) + this.upper_border;
            CShape Rectangle_to_move = new My_Rectangle(x_1, y_1, picturebox1);
            (Rectangle_to_move as My_Rectangle).length = this.right_border - this.left_border;
            (Rectangle_to_move as My_Rectangle).width = this.lower_border - this.upper_border;
            Graphics g = picturebox1.CreateGraphics();
            Rectangle_to_move.Paint(picturebox1, g);
            Rectangle_to_move.move(dx, dy);
            System.Threading.Thread.Sleep(100);

            if ((Rectangle_to_move as My_Rectangle).x == x_1)
                dx = 0;

            if ((Rectangle_to_move as My_Rectangle).y == y_1)
                dy = 0;
        }
        public void stick(CShape smth)
        {
            if (smth is Point)
            {
                int x_1 = (smth as Point).x;
                int y_1 = (smth as Point).y;

                for (int i = 0; i < folder_size; i++)
                {
                    CShape smth_2 = objects[i];

                    if ((smth_2 != null) && (smth_2 != smth))
                        if (smth_2.Selected(x_1, y_1))
                        {
                            if ((smth.observers.Contains(smth_2)) == false)
                            {
                                smth.add_observer(smth_2);

                                for(int j = 0; j < folder_size; j++)
                                {
                                    CShape smth_3 = objects[j];
                                     
                                    if(smth_3 != null)
                                        if((smth != smth_2)&&(smth != smth_3)&&(smth_2 != smth_3) && (smth_3.observers.Contains(smth_2)))
                                        {
                                            smth_3.observers.Remove(smth_2);
                                        }

                                }
                                
                                smth_2.isMoveable = false;
                            }
                        }
                }
            }
            else
            {
                for (int i = 0; i < folder_size; i++)
                {
                    CShape smth_2 = objects[i];

                    if ((smth_2 != null) && (smth_2 != smth))
                    {
                        int x_1 = (smth_2 as Point).x;
                        int y_1 = (smth_2 as Point).y;

                        if (smth.Selected(x_1, y_1))
                        {
                            if ((smth.observers.Contains(smth_2)) == false)
                            {
                                smth.add_observer(smth_2);

                                for (int j = 0; j < folder_size; j++)
                                {
                                    CShape smth_3 = objects[j];

                                    if (smth_3 != null)
                                        if ((smth != smth_2) && (smth != smth_3) && (smth_2 != smth_3) && (smth_3.observers.Contains(smth_2)))
                                        {
                                            smth_3.observers.Remove(smth_2);
                                        }

                                }

                                smth_2.isMoveable = false;
                            }
                        }
                    }
                }
            }
        }
      
        public override void move(int dx, int dy)
        {
            int prev_x;
            int prev_y;

            prev_x = dx;
            prev_y = dy;

            if(isMoveable == true)
            {
                for (int i = 0; i < folder_size; i++)
                {
                    if (objects[i] != null)
                    {
                        if (objects[i].isActive())
                        {
                            CShape smth = objects[i];

                            if (smth is Folder)
                            {
                                (smth as Folder).general_rec(ref dx, ref dy);
                            }

                            if (objects[i].isMoveable)
                                stick(objects[i]);

                            if (objects[i].isMoveable)
                                objects[i].NotifyMove(dx, dy);

                            objects[i].move(dx, dy);

                            dx = prev_x;
                            dy = prev_y;
                        }
                    }
                }
            }
        }

        public override void changecolor(Color color)
        {
            for (int i = 0; i < folder_size; i++)
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

        public void set_object(int index, CShape something)
        {
            if (index >= this.folder_size)
            {
                increase_array(objects, folder_size, index + 1);
                objects[index] = something;
                cnt = index;
                objects[index].NotifyCreate();
            }
        }
        public void set_object_without_notify(int index, CShape something)
        {
            if (index >= this.folder_size)
            {
                increase_array(objects, folder_size, index + 1);
                objects[index] = something;
            }
        }

        public override CShape load(FileInfo fileInf, int hod, StreamReader sr,Form form_1)
        {
            loadShapes(fileInf, hod, sr, form_1);
            return null;
        }

        public virtual CShape createShape(string code)
        {
            return null;
        }

        public override void save(FileInfo fileInf, StreamWriter sw)
        {
            string name = "F";
            sw.WriteLine(name);
            string code = folder_size.ToString();
            sw.WriteLine(code);

            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] != null)
                {
                    objects[i].save(fileInf, sw);
                }
            }
        }

        public void loadShapes(FileInfo fileInf, int hod, StreamReader sr,Form form_1)
        {
            int count = 0;

            string number = sr.ReadLine();

            count = Convert.ToInt32(number);

            CShape[] objects = new CShape[count];

            for (int i = 0; i < count; i++)
            {
                string code = sr.ReadLine();

                if (code != "F")
                {
                    CShape shape = createShape(code);

                    objects[i] = shape;

                    if (objects[i] != null)
                    {
                        CShape smth = shape.load(fileInf, hod, sr, form_1);
                        smth.picturebox1 = this.picturebox1;

                        objects[i] = smth;

                        smth.AddObserver(form_1 as IMyObserver);
                        set_object(i, smth);

                        hod = hod + 2;
                    }
                }
                else
                {
                    CShape shape = createShape(code);
                    shape.picturebox1 = this.picturebox1;
                    shape.load(fileInf, hod, sr,form_1);
                    hod = hod + 1 + (shape as CMyFolder).folder_size;

                    shape.AddObserver(form_1 as IMyObserver);

                    CMyFolder group = new CMyFolder((shape as CMyFolder).folder_size);
                    group.picturebox1 = shape.picturebox1;

                    (shape as CMyFolder).activate();
                    (shape as CMyFolder).add_object_to_group_2(group, form_1);

                    objects[i] = group;
                    set_object(i, group);
                }
            }

            this.folder_size = count;
            this.objects = objects;
        }

        public CShape get_object(int index)
        {
            if (check_by_index(index) == true)
                return this.objects[index];
            else
                return null;
        }

    }

}

