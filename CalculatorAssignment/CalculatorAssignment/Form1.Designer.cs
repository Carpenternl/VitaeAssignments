namespace CalculatorAssignment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Item0");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Beta");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Charlie");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Foxtrot");
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonPercentage = new System.Windows.Forms.Button();
            this.ButtonEur = new System.Windows.Forms.Button();
            this.buttonMultiply = new System.Windows.Forms.Button();
            this.buttonDivide = new System.Windows.Forms.Button();
            this.ButtonSubtract = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonEnter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.numPad1 = new CalculatorAssignment.NumPad();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.05405F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.94595F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 321F));
            this.tableLayoutPanel1.Controls.Add(this.numPad1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView1, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1134, 564);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox1, 3);
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1128, 22);
            this.textBox1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.ButtonPercentage, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.ButtonEur, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonMultiply, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonDivide, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.ButtonSubtract, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ButtonAdd, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ButtonEnter, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.button1, 2, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(442, 31);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(367, 530);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // ButtonPercentage
            // 
            this.ButtonPercentage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.ButtonPercentage.Location = new System.Drawing.Point(94, 267);
            this.ButtonPercentage.Name = "ButtonPercentage";
            this.ButtonPercentage.Size = new System.Drawing.Size(85, 126);
            this.ButtonPercentage.TabIndex = 7;
            this.ButtonPercentage.Text = "%";
            this.ButtonPercentage.UseVisualStyleBackColor = true;
            // 
            // ButtonEur
            // 
            this.ButtonEur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonEur.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.ButtonEur.Location = new System.Drawing.Point(3, 267);
            this.ButtonEur.Name = "ButtonEur";
            this.ButtonEur.Size = new System.Drawing.Size(85, 126);
            this.ButtonEur.TabIndex = 6;
            this.ButtonEur.Text = "€";
            this.ButtonEur.UseVisualStyleBackColor = true;
            // 
            // buttonMultiply
            // 
            this.buttonMultiply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMultiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.buttonMultiply.Location = new System.Drawing.Point(276, 3);
            this.buttonMultiply.Name = "buttonMultiply";
            this.buttonMultiply.Size = new System.Drawing.Size(88, 126);
            this.buttonMultiply.TabIndex = 3;
            this.buttonMultiply.Text = "x";
            this.buttonMultiply.UseVisualStyleBackColor = true;
            // 
            // buttonDivide
            // 
            this.buttonDivide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDivide.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.buttonDivide.Location = new System.Drawing.Point(185, 3);
            this.buttonDivide.Name = "buttonDivide";
            this.buttonDivide.Size = new System.Drawing.Size(85, 126);
            this.buttonDivide.TabIndex = 2;
            this.buttonDivide.Text = "/";
            this.buttonDivide.UseVisualStyleBackColor = true;
            // 
            // ButtonSubtract
            // 
            this.ButtonSubtract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonSubtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.ButtonSubtract.Location = new System.Drawing.Point(94, 3);
            this.ButtonSubtract.Name = "ButtonSubtract";
            this.ButtonSubtract.Size = new System.Drawing.Size(85, 126);
            this.ButtonSubtract.TabIndex = 1;
            this.ButtonSubtract.Text = "-";
            this.ButtonSubtract.UseVisualStyleBackColor = true;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.ButtonAdd.Location = new System.Drawing.Point(3, 3);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(85, 126);
            this.ButtonAdd.TabIndex = 0;
            this.ButtonAdd.Text = "+";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            // 
            // ButtonEnter
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.ButtonEnter, 2);
            this.ButtonEnter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.ButtonEnter.Location = new System.Drawing.Point(3, 399);
            this.ButtonEnter.Name = "ButtonEnter";
            this.ButtonEnter.Size = new System.Drawing.Size(176, 128);
            this.ButtonEnter.TabIndex = 4;
            this.ButtonEnter.Text = "Enter";
            this.ButtonEnter.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.button1, 2);
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button1.Location = new System.Drawing.Point(185, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 128);
            this.button1.TabIndex = 5;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.listView1.Location = new System.Drawing.Point(815, 31);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(305, 521);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // numPad1
            // 
            this.numPad1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numPad1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.numPad1.Location = new System.Drawing.Point(7, 35);
            this.numPad1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.numPad1.Name = "numPad1";
            this.numPad1.Size = new System.Drawing.Size(425, 522);
            this.numPad1.TabIndex = 0;
            this.numPad1.ValueChanged += new CalculatorAssignment.NumPad.ValueChangedEventHandler(this.numPad1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 564);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private NumPad numPad1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonMultiply;
        private System.Windows.Forms.Button buttonDivide;
        private System.Windows.Forms.Button ButtonSubtract;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonEnter;
        private System.Windows.Forms.Button ButtonPercentage;
        private System.Windows.Forms.Button ButtonEur;
        private System.Windows.Forms.Button button1;
    }
}

