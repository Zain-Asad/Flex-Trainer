namespace WindowsFormsApp1
{
    partial class CreateWorkoutPlanForm
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
            this.lblPlanName = new System.Windows.Forms.Label();
            this.txtPlanName = new System.Windows.Forms.TextBox();
            this.lblPlanDescription = new System.Windows.Forms.Label();
            this.txtPlanDescription = new System.Windows.Forms.TextBox();
            this.lstExercises = new System.Windows.Forms.ListBox();
            this.lblExercises = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPlanName
            // 
            this.lblPlanName.AutoSize = true;
            this.lblPlanName.Location = new System.Drawing.Point(12, 9);
            this.lblPlanName.Name = "lblPlanName";
            this.lblPlanName.Size = new System.Drawing.Size(63, 13);
            this.lblPlanName.TabIndex = 0;
            this.lblPlanName.Text = "Plan Name:";
            // 
            // txtPlanName
            // 
            this.txtPlanName.Location = new System.Drawing.Point(12, 25);
            this.txtPlanName.Name = "txtPlanName";
            this.txtPlanName.Size = new System.Drawing.Size(260, 20);
            this.txtPlanName.TabIndex = 1;
            // 
            // lblPlanDescription
            // 
            this.lblPlanDescription.AutoSize = true;
            this.lblPlanDescription.Location = new System.Drawing.Point(12, 48);
            this.lblPlanDescription.Name = "lblPlanDescription";
            this.lblPlanDescription.Size = new System.Drawing.Size(88, 13);
            this.lblPlanDescription.TabIndex = 2;
            this.lblPlanDescription.Text = "Plan Description:";
            // 
            // txtPlanDescription
            // 
            this.txtPlanDescription.Location = new System.Drawing.Point(12, 64);
            this.txtPlanDescription.Multiline = true;
            this.txtPlanDescription.Name = "txtPlanDescription";
            this.txtPlanDescription.Size = new System.Drawing.Size(260, 60);
            this.txtPlanDescription.TabIndex = 3;
            // 
            // lstExercises
            // 
            this.lstExercises.FormattingEnabled = true;
            this.lstExercises.Location = new System.Drawing.Point(12, 154);
            this.lstExercises.Name = "lstExercises";
            this.lstExercises.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstExercises.Size = new System.Drawing.Size(260, 95);
            this.lstExercises.TabIndex = 4;
            // 
            // lblExercises
            // 
            this.lblExercises.AutoSize = true;
            this.lblExercises.Location = new System.Drawing.Point(12, 138);
            this.lblExercises.Name = "lblExercises";
            this.lblExercises.Size = new System.Drawing.Size(56, 13);
            this.lblExercises.TabIndex = 5;
            this.lblExercises.Text = "Exercises:";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 255);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(197, 255);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CreateWorkoutPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 290);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblExercises);
            this.Controls.Add(this.lstExercises);
            this.Controls.Add(this.txtPlanDescription);
            this.Controls.Add(this.lblPlanDescription);
            this.Controls.Add(this.txtPlanName);
            this.Controls.Add(this.lblPlanName);
            this.Name = "CreateWorkoutPlanForm";
            this.Text = "Create Workout Plan";
            this.Load += new System.EventHandler(this.CreateWorkoutPlanForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlanName;
        private System.Windows.Forms.TextBox txtPlanName;
        private System.Windows.Forms.Label lblPlanDescription;
        private System.Windows.Forms.TextBox txtPlanDescription;
        private System.Windows.Forms.ListBox lstExercises;
        private System.Windows.Forms.Label lblExercises;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnClose;
    }
}
