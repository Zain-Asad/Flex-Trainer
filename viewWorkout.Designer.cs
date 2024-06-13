namespace WindowsFormsApp1
{
    partial class viewWorkout
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
            this.workoutplanTableAdapter1 = new WindowsFormsApp1.Flex_TrainerDataTableAdapters.WORKOUTPLANTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.workoutPlanListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // workoutplanTableAdapter1
            // 
            this.workoutplanTableAdapter1.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Workout Plans";
            // 
            // workoutPlanListBox
            // 
            this.workoutPlanListBox.FormattingEnabled = true;
            this.workoutPlanListBox.ItemHeight = 16;
            this.workoutPlanListBox.Location = new System.Drawing.Point(214, 90);
            this.workoutPlanListBox.Name = "workoutPlanListBox";
            this.workoutPlanListBox.Size = new System.Drawing.Size(360, 228);
            this.workoutPlanListBox.TabIndex = 1;
            this.workoutPlanListBox.SelectedIndexChanged += new System.EventHandler(this.workoutPlanListBox_SelectedIndexChanged_1);
            // 
            // viewWorkout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.workoutPlanListBox);
            this.Controls.Add(this.label1);
            this.Name = "viewWorkout";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.viewWorkout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Flex_TrainerDataTableAdapters.WORKOUTPLANTableAdapter workoutplanTableAdapter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox workoutPlanListBox;
    }
}