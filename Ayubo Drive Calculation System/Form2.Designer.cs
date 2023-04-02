namespace Ayubo_Drive_Calculation_System
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.frm2_cmbBox = new System.Windows.Forms.ComboBox();
            this.frm2_btnDelete = new System.Windows.Forms.Button();
            this.frm2_updateBtn = new System.Windows.Forms.Button();
            this.frm2_dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.frm2_addBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.frm2_txtBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.frm2_txtBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.frm2_txtBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.frm2_txtBox1 = new System.Windows.Forms.TextBox();
            this.frm2_exitBtn = new System.Windows.Forms.Button();
            this.frm2_BtnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(665, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(782, 497);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.frm2_cmbBox);
            this.groupBox1.Controls.Add(this.frm2_btnDelete);
            this.groupBox1.Controls.Add(this.frm2_updateBtn);
            this.groupBox1.Controls.Add(this.frm2_dateTimePicker1);
            this.groupBox1.Controls.Add(this.frm2_addBtn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.frm2_txtBox5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.frm2_txtBox4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.frm2_txtBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.frm2_txtBox1);
            this.groupBox1.Location = new System.Drawing.Point(32, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 660);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Vehicle";
            // 
            // frm2_cmbBox
            // 
            this.frm2_cmbBox.FormattingEnabled = true;
            this.frm2_cmbBox.Location = new System.Drawing.Point(218, 145);
            this.frm2_cmbBox.Name = "frm2_cmbBox";
            this.frm2_cmbBox.Size = new System.Drawing.Size(315, 37);
            this.frm2_cmbBox.TabIndex = 22;
            this.frm2_cmbBox.SelectedIndexChanged += new System.EventHandler(this.frm2_cmbBox_SelectedIndexChanged);
            // 
            // frm2_btnDelete
            // 
            this.frm2_btnDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.frm2_btnDelete.Location = new System.Drawing.Point(370, 532);
            this.frm2_btnDelete.Name = "frm2_btnDelete";
            this.frm2_btnDelete.Size = new System.Drawing.Size(102, 38);
            this.frm2_btnDelete.TabIndex = 20;
            this.frm2_btnDelete.Text = "Delete";
            this.frm2_btnDelete.UseVisualStyleBackColor = false;
            this.frm2_btnDelete.Click += new System.EventHandler(this.frm2_btnDelete_Click);
            // 
            // frm2_updateBtn
            // 
            this.frm2_updateBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.frm2_updateBtn.Location = new System.Drawing.Point(207, 532);
            this.frm2_updateBtn.Name = "frm2_updateBtn";
            this.frm2_updateBtn.Size = new System.Drawing.Size(102, 38);
            this.frm2_updateBtn.TabIndex = 19;
            this.frm2_updateBtn.Text = "Update";
            this.frm2_updateBtn.UseVisualStyleBackColor = false;
            this.frm2_updateBtn.Click += new System.EventHandler(this.frm2_updateBtn_Click);
            // 
            // frm2_dateTimePicker1
            // 
            this.frm2_dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frm2_dateTimePicker1.CustomFormat = "\"YYYY-MM-DD\"";
            this.frm2_dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frm2_dateTimePicker1.Location = new System.Drawing.Point(265, 409);
            this.frm2_dateTimePicker1.Name = "frm2_dateTimePicker1";
            this.frm2_dateTimePicker1.Size = new System.Drawing.Size(268, 24);
            this.frm2_dateTimePicker1.TabIndex = 17;
            // 
            // frm2_addBtn
            // 
            this.frm2_addBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.frm2_addBtn.Location = new System.Drawing.Point(66, 532);
            this.frm2_addBtn.Name = "frm2_addBtn";
            this.frm2_addBtn.Size = new System.Drawing.Size(85, 38);
            this.frm2_addBtn.TabIndex = 3;
            this.frm2_addBtn.Text = "Add";
            this.frm2_addBtn.UseVisualStyleBackColor = false;
            this.frm2_addBtn.Click += new System.EventHandler(this.frm2_addBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(29, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 29);
            this.label6.TabIndex = 14;
            this.label6.Text = "Date of Registration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(29, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "Brand";
            // 
            // frm2_txtBox5
            // 
            this.frm2_txtBox5.Location = new System.Drawing.Point(218, 339);
            this.frm2_txtBox5.Name = "frm2_txtBox5";
            this.frm2_txtBox5.Size = new System.Drawing.Size(315, 34);
            this.frm2_txtBox5.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Registration Number";
            // 
            // frm2_txtBox4
            // 
            this.frm2_txtBox4.Location = new System.Drawing.Point(220, 271);
            this.frm2_txtBox4.Name = "frm2_txtBox4";
            this.frm2_txtBox4.Size = new System.Drawing.Size(313, 34);
            this.frm2_txtBox4.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(29, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Vehicle Type";
            // 
            // frm2_txtBox3
            // 
            this.frm2_txtBox3.Location = new System.Drawing.Point(220, 206);
            this.frm2_txtBox3.Name = "frm2_txtBox3";
            this.frm2_txtBox3.Size = new System.Drawing.Size(313, 34);
            this.frm2_txtBox3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(29, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Vehicle Type ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(29, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vehicle ID";
            // 
            // frm2_txtBox1
            // 
            this.frm2_txtBox1.Location = new System.Drawing.Point(220, 76);
            this.frm2_txtBox1.Name = "frm2_txtBox1";
            this.frm2_txtBox1.Size = new System.Drawing.Size(313, 34);
            this.frm2_txtBox1.TabIndex = 2;
            // 
            // frm2_exitBtn
            // 
            this.frm2_exitBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.frm2_exitBtn.Location = new System.Drawing.Point(966, 618);
            this.frm2_exitBtn.Name = "frm2_exitBtn";
            this.frm2_exitBtn.Size = new System.Drawing.Size(205, 38);
            this.frm2_exitBtn.TabIndex = 21;
            this.frm2_exitBtn.Text = "Exit";
            this.frm2_exitBtn.UseVisualStyleBackColor = false;
            this.frm2_exitBtn.Click += new System.EventHandler(this.frm2_exitBtn_Click);
            // 
            // frm2_BtnRefresh
            // 
            this.frm2_BtnRefresh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.frm2_BtnRefresh.Location = new System.Drawing.Point(1241, 507);
            this.frm2_BtnRefresh.Name = "frm2_BtnRefresh";
            this.frm2_BtnRefresh.Size = new System.Drawing.Size(205, 38);
            this.frm2_BtnRefresh.TabIndex = 22;
            this.frm2_BtnRefresh.Text = "Refresh";
            this.frm2_BtnRefresh.UseVisualStyleBackColor = false;
            this.frm2_BtnRefresh.Click += new System.EventHandler(this.frm2_BtnRefresh_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1477, 736);
            this.Controls.Add(this.frm2_BtnRefresh);
            this.Controls.Add(this.frm2_exitBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Vehicle";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker frm2_dateTimePicker1;
        private System.Windows.Forms.Button frm2_addBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox frm2_txtBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox frm2_txtBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox frm2_txtBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox frm2_txtBox1;
        private System.Windows.Forms.Button frm2_updateBtn;
        private System.Windows.Forms.Button frm2_btnDelete;
        private System.Windows.Forms.Button frm2_exitBtn;
        private System.Windows.Forms.ComboBox frm2_cmbBox;
        private System.Windows.Forms.Button frm2_BtnRefresh;
    }
}