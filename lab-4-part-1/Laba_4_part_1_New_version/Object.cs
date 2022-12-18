using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_4_part_1_New_version
{
    public class Object
    {
        public int x;
        public int y;
        public List<Object> Con_Nodes;
        public int number;

        public bool active;

        public Object(int x_1, int y_1,int number)
        {
            this.x = x_1;
            this.y = y_1;
            Con_Nodes = new List<Object>();
            this.number = number;   
        }

        public void change_active()
        {
            if (this.active == true)
                this.active = false;
            else
                this.active = true;

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

        public virtual void Paint(PictureBox picturebox1, Graphics g)
        {

        }

        public virtual bool Selected(int x, int y) { return false; }



        ~Object()
        {
            Console.Write("Диструктор класса object");
        }
    }
}
