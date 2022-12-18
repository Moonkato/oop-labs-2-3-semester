﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Laba_6_OOP
{
    public class Folder : CShape
    {
        public CShape[] objects;
        public int folder_size;

        public Folder(int folder_sizee)
        {
            Console.Write("Конструктор по умолчанию класса folder");
            this.folder_size = folder_sizee;
            this.objects = new CShape[folder_sizee];
            this.lower_border = 0;
            this.upper_border = 10000;
            this.right_border = 0;
            this.left_border = 10000;

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
                    objects[i].deactivate();
        }

        public void del_active()
        {
            for (int i = 0; i < folder_size; ++i)
                if (objects[i] != null)
                    if (objects[i].isActive())
                        objects[i] = null;
        }

        public void add_object_to_group(int x_1, int x_2, CShape group)
        {
            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] != null)
                    if (objects[i].Selected(x_1, x_2))
                    {
                        objects[i].change_active();
                        (group as Folder).add_object(objects[i]);
                        (group as Folder).set_borders();
                        objects[i] = null;
                        break;
                    }
            }
        }

       

        public void del_object_from_group(int x_1, int y_1)
        {
            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] != null)
                {
                    if (objects[i].Selected(x_1, y_1))
                    {
                        for (int j = 0; j < (objects[i] as Folder).folder_size; j++)
                        {
                            CShape element;
                            element = (objects[i] as Folder).get_object(j);
                            add_object(element);
                            (objects[i] as Folder).delete_object(j);
                        }
                        objects[i] = null;
                        break;
                    }

                }
            }
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
                    CShape circle = new CCircle(x_1, x_2, picturebox1);
                    add_object(circle);
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
                    add_object(square);
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
                    add_object(triangle);
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
                if (i == index)
                    if (objects[i] == null)
                    {
                        objects[i] = null;
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
                    break;
                }
            }
            if (mesto == false)
            {
                set_object(folder_size, something);
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
      
        public override void move(int dx, int dy)
        {
            int prev_x;
            int prev_y;

            prev_x = dx;
            prev_y = dy;

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

                        objects[i].move(dx, dy);

                        dx = prev_x;
                        dy = prev_y;
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
            }
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