using Laba_4_part_1_New_version;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
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
            {
                ctrl = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.ControlKey)
            {
                ctrl = true;
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

            if(ctrl != true)
            {
                folder_1.deact_all();
                folder_1.probeg(e.X, e.Y,dataGridView1);
                folder_1.paint(pictureBox1);
            }
            else
            {
                folder_1.probeg(e.X, e.Y,dataGridView1);
                folder_1.paint(pictureBox1);
            }
        }

    }
}