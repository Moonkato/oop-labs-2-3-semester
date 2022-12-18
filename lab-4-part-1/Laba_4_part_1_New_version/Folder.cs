using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_4_part_1_New_version
{
    public class Folder
    {
        public Object[] objects;
        public int folder_size;
        public Object current;
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
            this.current = new CCircle(0,0,0);

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
        protected bool check_for_active()
        {
            for(int i = 0; i < folder_size; i++)
            {
                if(objects[i] != null)
                {
                    if (objects[i].isActive())
                        return true;
                }
            }
            return false;
        }
        public void probeg(int x_1, int x_2,DataGridView data)
        {
            bool reactive = false;

            for (int i = 0; i < folder_size; i++)
            {
                if (objects[i] != null)
                    if (objects[i].Selected(x_1, x_2))
                    {
                        if(check_for_active() == false) {
                            Object smth = get_object(i);
                            this.current = smth;
                            this.current.Con_Nodes = objects[i].Con_Nodes;
                        }
                        else
                        {
                            if(current != objects[i])
                            {
                                this.current.Con_Nodes.Add(objects[i]);
                                
                                RowS = (current.number, i);

                                if(data.Rows.Contains(RowS))
                                {

                                }
                                else
                                {
                                    data.Rows.Add(current.number, i);
                                    data.Rows.Add(i, current.number);
                                }
                            }
                        }
                        objects[i].change_active();
                        reactive = true;
                        break;
                    }
            }

            if (reactive == false)
            {
                CCircle circle = new CCircle(x_1, x_2,0);
                add_object(circle);
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
                    something.number = i;
                    objects[i] = something;

                }
            }
            if (mesto == false)
            {
                something.number = folder_size;
                set_object(folder_size, something);
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
}
