using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_4_2_OOP
{
    public partial class Form1 : Form
    {
        Model model;
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.observes += new System.EventHandler(this.UpdateFromModel);
            model.update();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
        {
     
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
               model.setValue_1(Int32.Parse(textBox1.Text));
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.setValue_1(decimal.ToInt32(numericUpDown1.Value));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            model.setValue_1(trackBar1.Value);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                model.setValue_2(Int32.Parse(textBox2.Text));
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.setValue_2(decimal.ToInt32(numericUpDown2.Value));
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            model.setValue_2(trackBar2.Value);
        }


        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                model.setValue_3(Int32.Parse(textBox3.Text));
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            model.setValue_3(decimal.ToInt32(numericUpDown3.Value));
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            model.setValue_3(trackBar3.Value);
        }



        private void UpdateFromModel(object sender, EventArgs e)
        {
            textBox1.Text = model.get_value_1().ToString();
            numericUpDown1.Value = model.get_value_1();
            trackBar1.Value = model.get_value_1();

            textBox2.Text = model.get_value_2().ToString();
            numericUpDown2.Value = model.get_value_2();
            trackBar2.Value = model.get_value_2();

            textBox3.Text = model.get_value_3().ToString();
            numericUpDown3.Value = model.get_value_3();
            trackBar3.Value = model.get_value_3();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            model.setValue_3(Int32.Parse(textBox3.Text));
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            model.setValue_2(Int32.Parse(textBox2.Text));
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            model.setValue_1(Int32.Parse(textBox1.Text));
        }
    }

    public class Model
    {
        private int value_1;
        private int value_2;    
        private int value_3;
        public System.EventHandler observes;


        public void update()
        {
            observes.Invoke(this, null);
        }

        public void setValue_1(int value_1)
        {
            if (value_1 <= this.value_2)
            {
                this.value_1 = value_1;
            }
            else
            {
                if (value_1 >= this.value_3)
                {
                    this.value_1 = value_1;
                    this.value_2 = value_1;
                    this.value_3 = value_1;
                }
                else
                {
                    if(value_1 >= this.value_2)
                    {
                        this.value_2 = value_1;
                        this.value_1 = value_1;
                    }
                }
            }
            observes.Invoke(this, null);
        }
        public int get_value_1()
        {
            return this.value_1;
        }

        public void setValue_2(int value_2)
        {
            if ((value_2 < this.value_1)&&(value_2 <= this.value_3))
            {
                this.value_2 = value_1;
            }
            else
            {
                if(value_2 >= this.value_3)
                {
                    this.value_2 = value_3;
                    
                }
                if((value_2 >= this.value_1)&&(value_2 <= this.value_3))
                {
                    this.value_2 = value_2;
                }
            }
            observes.Invoke(this, null);
        }

        public int get_value_2()
        {
            return this.value_2;
        }

        public void setValue_3(int value_3)
        {
            if (value_2 > value_3)
            {
                this.value_3 = value_3;
                this.value_2 = value_3;
            }
            else
            {
                this.value_3 = value_3;
            }
           
            if(value_2 <= value_1)
            {
                this.value_1 = this.value_2;
            }
            observes.Invoke(this, null);
        }
        public int get_value_3()
        {
            return this.value_3;
        }
    }
}
