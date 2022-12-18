namespace Laba_4_1_OOP
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Button_Circle = new System.Windows.Forms.Button();
            this.Button_Square = new System.Windows.Forms.Button();
            this.Button_Rectangular = new System.Windows.Forms.Button();
            this.change_color_button = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.resize_box = new System.Windows.Forms.TextBox();
            this.button_group = new System.Windows.Forms.Button();
            this.button_ungroup = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(373, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(985, 647);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(663, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(719, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // Button_Circle
            // 
            this.Button_Circle.Location = new System.Drawing.Point(29, 26);
            this.Button_Circle.Name = "Button_Circle";
            this.Button_Circle.Size = new System.Drawing.Size(85, 23);
            this.Button_Circle.TabIndex = 5;
            this.Button_Circle.Text = "Круг";
            this.Button_Circle.UseVisualStyleBackColor = true;
            this.Button_Circle.Click += new System.EventHandler(this.Button_Circle_Click);
            // 
            // Button_Square
            // 
            this.Button_Square.Location = new System.Drawing.Point(120, 26);
            this.Button_Square.Name = "Button_Square";
            this.Button_Square.Size = new System.Drawing.Size(89, 23);
            this.Button_Square.TabIndex = 6;
            this.Button_Square.Text = "Квадрат";
            this.Button_Square.UseVisualStyleBackColor = true;
            this.Button_Square.Click += new System.EventHandler(this.Button_Square_Click);
            // 
            // Button_Rectangular
            // 
            this.Button_Rectangular.Location = new System.Drawing.Point(215, 26);
            this.Button_Rectangular.Name = "Button_Rectangular";
            this.Button_Rectangular.Size = new System.Drawing.Size(89, 23);
            this.Button_Rectangular.TabIndex = 7;
            this.Button_Rectangular.Text = "Треугольник";
            this.Button_Rectangular.UseVisualStyleBackColor = true;
            this.Button_Rectangular.Click += new System.EventHandler(this.Button_Rectangular_Click_1);
            // 
            // change_color_button
            // 
            this.change_color_button.Location = new System.Drawing.Point(373, 12);
            this.change_color_button.Name = "change_color_button";
            this.change_color_button.Size = new System.Drawing.Size(95, 54);
            this.change_color_button.TabIndex = 8;
            this.change_color_button.Text = "Изменить цвет объекта";
            this.change_color_button.UseVisualStyleBackColor = true;
            this.change_color_button.Click += new System.EventHandler(this.change_color_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(485, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Изменить размер объекта";
            // 
            // resize_box
            // 
            this.resize_box.Location = new System.Drawing.Point(503, 46);
            this.resize_box.Name = "resize_box";
            this.resize_box.Size = new System.Drawing.Size(100, 20);
            this.resize_box.TabIndex = 10;
            this.resize_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.resize_box_KeyDown);
            // 
            // button_group
            // 
            this.button_group.Location = new System.Drawing.Point(816, 26);
            this.button_group.Name = "button_group";
            this.button_group.Size = new System.Drawing.Size(106, 23);
            this.button_group.TabIndex = 13;
            this.button_group.Text = "Группировать";
            this.button_group.UseVisualStyleBackColor = true;
            this.button_group.Click += new System.EventHandler(this.button_group_Click);
            // 
            // button_ungroup
            // 
            this.button_ungroup.Location = new System.Drawing.Point(928, 26);
            this.button_ungroup.Name = "button_ungroup";
            this.button_ungroup.Size = new System.Drawing.Size(106, 23);
            this.button_ungroup.TabIndex = 14;
            this.button_ungroup.Text = "Разгруппировать";
            this.button_ungroup.UseVisualStyleBackColor = true;
            this.button_ungroup.Click += new System.EventHandler(this.button_ungroup_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.openFileToolStripMenuItem.Text = "Open file";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.saveFileToolStripMenuItem.Text = "Save file";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 87);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(345, 394);
            this.treeView1.TabIndex = 16;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button_ungroup);
            this.Controls.Add(this.button_group);
            this.Controls.Add(this.resize_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.change_color_button);
            this.Controls.Add(this.Button_Rectangular);
            this.Controls.Add(this.Button_Square);
            this.Controls.Add(this.Button_Circle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_Circle;
        private System.Windows.Forms.Button Button_Square;
        private System.Windows.Forms.Button Button_Rectangular;
        private System.Windows.Forms.Button change_color_button;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox resize_box;
        private System.Windows.Forms.Button button_group;
        private System.Windows.Forms.Button button_ungroup;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
    }
}

