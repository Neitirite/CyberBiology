namespace CyberBiology
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            listView1 = new ListView();
            groupBox2 = new GroupBox();
            label3 = new Label();
            label5 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listView1);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(1471, 2);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(259, 914);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Геном";
            // 
            // listView1
            // 
            listView1.Location = new Point(6, 108);
            listView1.Name = "listView1";
            listView1.Size = new Size(240, 794);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(6, 20);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(240, 83);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Текущий";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 18);
            label3.Name = "label3";
            label3.Size = new Size(19, 15);
            label3.TabIndex = 0;
            label3.Text = "33";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(106, 18);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 0;
            label5.Text = "or";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 44);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 0;
            label8.Text = "Raw";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(155, 18);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 0;
            label7.Text = "n=xx";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(130, 18);
            label6.Name = "label6";
            label6.Size = new Size(19, 15);
            label6.TabIndex = 0;
            label6.Text = "55";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(81, 18);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 0;
            label4.Text = "44";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 18);
            label1.Name = "label1";
            label1.Size = new Size(19, 15);
            label1.TabIndex = 0;
            label1.Text = "11";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 18);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 0;
            label2.Text = "22";
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1735, 916);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label1;
        private GroupBox groupBox2;
        private Button button1;
        private Label label5;
        private Label label6;
        private Label label7;
        private ListView listView1;
        private Label label8;
    }
}
