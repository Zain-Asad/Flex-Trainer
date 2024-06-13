namespace WindowsFormsApp1
{
    partial class viewDiet
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
            this.dietPlanListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dietPlanListBox
            // 
            this.dietPlanListBox.FormattingEnabled = true;
            this.dietPlanListBox.ItemHeight = 16;
            this.dietPlanListBox.Location = new System.Drawing.Point(213, 99);
            this.dietPlanListBox.Name = "dietPlanListBox";
            this.dietPlanListBox.Size = new System.Drawing.Size(360, 228);
            this.dietPlanListBox.TabIndex = 3;
            this.dietPlanListBox.SelectedIndexChanged += new System.EventHandler(this.dietPlanListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Diet Plans";
            // 
            // viewDiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dietPlanListBox);
            this.Controls.Add(this.label1);
            this.Name = "viewDiet";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.viewDiet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox dietPlanListBox;
        private System.Windows.Forms.Label label1;
    }
}