namespace Ayubo_Drive_Calculation_System
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.frm1_serviceCmbBox = new System.Windows.Forms.ComboBox();
            this.frm_BtnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(406, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(665, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Your Service..!";
            // 
            // frm1_serviceCmbBox
            // 
            this.frm1_serviceCmbBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frm1_serviceCmbBox.FormattingEnabled = true;
            this.frm1_serviceCmbBox.Items.AddRange(new object[] {
            "Add a New Vehicle",
            "Rent a Vehicle",
            "Hire a Vehicle"});
            this.frm1_serviceCmbBox.Location = new System.Drawing.Point(444, 421);
            this.frm1_serviceCmbBox.Name = "frm1_serviceCmbBox";
            this.frm1_serviceCmbBox.Size = new System.Drawing.Size(585, 46);
            this.frm1_serviceCmbBox.TabIndex = 1;
            this.frm1_serviceCmbBox.SelectedIndexChanged += new System.EventHandler(this.frm1_serviceCmbBox_SelectedIndexChanged);
            // 
            // frm_BtnExit
            // 
            this.frm_BtnExit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.frm_BtnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frm_BtnExit.ForeColor = System.Drawing.Color.Black;
            this.frm_BtnExit.Location = new System.Drawing.Point(617, 601);
            this.frm_BtnExit.Name = "frm_BtnExit";
            this.frm_BtnExit.Size = new System.Drawing.Size(224, 55);
            this.frm_BtnExit.TabIndex = 2;
            this.frm_BtnExit.Text = "Exit";
            this.frm_BtnExit.UseVisualStyleBackColor = false;
            this.frm_BtnExit.Click += new System.EventHandler(this.frm_BtnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1477, 736);
            this.Controls.Add(this.frm_BtnExit);
            this.Controls.Add(this.frm1_serviceCmbBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Start";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox frm1_serviceCmbBox;
        private System.Windows.Forms.Button frm_BtnExit;
    }
}

