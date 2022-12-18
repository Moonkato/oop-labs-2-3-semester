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
using System.IO;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Laba_4_1_OOP
{
    public partial class Form1 : Form, IMyObserver
    {
        CShape folder_1 = new CMyFolder(0);
        CShape group = new CMyFolder(0);
        public Form1()
        {
            InitializeComponent();
        }

        bool ctrl = false;
        bool compose = false;
        bool uncompose = false;
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

            if (e.KeyValue == (char)Keys.A)
            {
                Graphics g = pictureBox1.CreateGraphics();
                folder_1.move(-15, 0);
                g.Clear(Color.White);
                folder_1.Paint(pictureBox1, g);
            }

            if(e.KeyValue == (char)Keys.D)
            {
                Graphics g = pictureBox1.CreateGraphics();
                folder_1.move(15, 0);
                g.Clear(Color.White);
                folder_1.Paint(pictureBox1,g);
            }

            if(e.KeyValue == (char)Keys.W)
            {
                Graphics g = pictureBox1.CreateGraphics();
                folder_1.move(0, -15);
                g.Clear(Color.White);
                folder_1.Paint(pictureBox1,g);
            }

            if(e.KeyValue == (char)Keys.S)
            {
                Graphics g = pictureBox1.CreateGraphics();
                folder_1.move(0, 15);
                g.Clear(Color.White);
                folder_1.Paint(pictureBox1,g);
            }


            if (e.KeyValue == (char)Keys.Delete)
            {
                Graphics g = pictureBox1.CreateGraphics();
                (folder_1 as Folder).del_active();
                g.Clear(Color.White);
                folder_1.Paint(pictureBox1,g);
            }
        }

        

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            Graphics g = pictureBox1.CreateGraphics();

            if ((ctrl != true) && (compose != true) && (uncompose != true))
                (folder_1 as Folder).deact_all();

            (folder_1 as Folder).probeg(e.X, e.Y, this);
            g.Clear(Color.White);
            folder_1.Paint(pictureBox1, g);
        }

        public void UpdateCreate_with_cnt(CShape a)
        {
            TreeNode node = new TreeNode(a.GetType().Name + (folder_1 as CMyFolder).cnt);
            node.Name = a.GetType().Name + a.GetHashCode();
            if (a is CMyFolder)
                processNode(node, a);
            treeView1.Nodes.Add(node);
        }

        public void UpdateSelect(CShape a)
        {
            TreeNode[] t = treeView1.Nodes.Find(a.GetType().Name + a.GetHashCode(), true);
            if (a.isActive())
            {
                t[0].Checked = true;
                t[0].BackColor = Color.Blue;
            }
            else
            {
                t[0].Checked = false;
                t[0].BackColor = Color.White;
            }
        }



        public void UpdateDelete_with_cnt(CShape a)
        {
            TreeNode[] nodes = treeView1.Nodes.Find(a.GetType().Name + a.GetHashCode(), true);
            if (nodes.Length > 0)
                treeView1.Nodes.Remove(nodes[0]);
        }
        public void UpdateDelete_without_cnt(CShape a)
        {
            TreeNode[] nodes = treeView1.Nodes.Find(a.GetType().Name + a.GetHashCode(), true);
            if (nodes.Length > 0)
                treeView1.Nodes.Remove(nodes[0]);
        }

      

        private void button_group_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            group = new CMyFolder(0);

            group.picturebox1 = pictureBox1;
            group.flag_circle = folder_1.flag_circle;
            group.flag_square = folder_1.flag_square;
            group.flag_triangle = folder_1.flag_triangle;

            (this.folder_1 as CMyFolder).add_object_to_group_2(group,this);
            (this.group as CMyFolder).Paint(pictureBox1, g);


            (folder_1 as CMyFolder).add_object(this.group);
            g.Clear(Color.White);
            folder_1.Paint(pictureBox1, g);
        }

        private void button_ungroup_Click(object sender, EventArgs e)
        {
            (folder_1 as Folder).del_object_from_group_2(this);
            (folder_1 as Folder).deact_all();

            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            folder_1.Paint(pictureBox1, g);
        }

        private void change_color_button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Graphics g = pictureBox1.CreateGraphics();
                Color color = colorDialog1.Color;
                folder_1.changecolor(color);
                this.ActiveControl = null;
                g.Clear(Color.White);
                folder_1.Paint(pictureBox1,g);

            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            folder_1.Paint(pictureBox1,g);
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            label1.Text = e.X.ToString();
            label2.Text = e.Y.ToString();
            folder_1.picturebox1 = pictureBox1;
            group.picturebox1 = pictureBox1;
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
                Graphics g = pictureBox1.CreateGraphics();
                folder_1.resize(size);
                this.ActiveControl = null;
                g.Clear(Color.White);
                folder_1.Paint(pictureBox1,g);
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                FileInfo file = new FileInfo(path);

                StreamReader sr = file.OpenText();

                string brr = sr.ReadLine();
                folder_1.load(file, 0, sr,this);
                (folder_1 as Folder).deact_all();

                Graphics g = pictureBox1.CreateGraphics();
                g.Clear(Color.White);
                folder_1.Paint(pictureBox1, g);
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                FileInfo file = new FileInfo(path);

                StreamWriter sw = new StreamWriter(path, false);
                folder_1.save(file, sw);
                sw.Close();

                Graphics g = pictureBox1.CreateGraphics();
            }
        }


    }
}