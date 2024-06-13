namespace WindowsFormsApp1
{
    partial class WorkoutPlanForm
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
            this.planNameLabel = new System.Windows.Forms.Label();
            this.trainerIdLabel = new System.Windows.Forms.Label();
            this.creationDateLabel = new System.Windows.Forms.Label();
            this.planDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.exercisesListView = new System.Windows.Forms.ListView();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // planNameLabel
            // 
            this.planNameLabel.AutoSize = true;
            this.planNameLabel.Location = new System.Drawing.Point(12, 9);
            this.planNameLabel.Name = "planNameLabel";
            this.planNameLabel.Size = new System.Drawing.Size(44, 16);
            this.planNameLabel.TabIndex = 0;
            this.planNameLabel.Text = "label1";
            this.planNameLabel.Click += new System.EventHandler(this.planNameLabel_Click);
            // 
            // trainerIdLabel
            // 
            this.trainerIdLabel.AutoSize = true;
            this.trainerIdLabel.Location = new System.Drawing.Point(12, 38);
            this.trainerIdLabel.Name = "trainerIdLabel";
            this.trainerIdLabel.Size = new System.Drawing.Size(44, 16);
            this.trainerIdLabel.TabIndex = 1;
            this.trainerIdLabel.Text = "label2";
            // 
            // creationDateLabel
            // 
            this.creationDateLabel.AutoSize = true;
            this.creationDateLabel.Location = new System.Drawing.Point(12, 67);
            this.creationDateLabel.Name = "creationDateLabel";
            this.creationDateLabel.Size = new System.Drawing.Size(44, 16);
            this.creationDateLabel.TabIndex = 2;
            this.creationDateLabel.Text = "label3";
            // 
            // planDescriptionTextBox
            // 
            this.planDescriptionTextBox.Location = new System.Drawing.Point(12, 96);
            this.planDescriptionTextBox.Multiline = true;
            this.planDescriptionTextBox.Name = "planDescriptionTextBox";
            this.planDescriptionTextBox.ReadOnly = true;
            this.planDescriptionTextBox.Size = new System.Drawing.Size(300, 100);
            this.planDescriptionTextBox.TabIndex = 3;
            // 
            // exercisesListView
            // 
            this.exercisesListView.HideSelection = false;
            this.exercisesListView.Location = new System.Drawing.Point(12, 202);
            this.exercisesListView.Name = "exercisesListView";
            this.exercisesListView.Size = new System.Drawing.Size(300, 150);
            this.exercisesListView.TabIndex = 4;
            this.exercisesListView.UseCompatibleStateImageBehavior = false;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(237, 358);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // WorkoutPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 393);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.exercisesListView);
            this.Controls.Add(this.planDescriptionTextBox);
            this.Controls.Add(this.creationDateLabel);
            this.Controls.Add(this.trainerIdLabel);
            this.Controls.Add(this.planNameLabel);
            this.Name = "WorkoutPlanForm";
            this.Text = "Workout Plan Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label planNameLabel;
        private System.Windows.Forms.Label trainerIdLabel;
        private System.Windows.Forms.Label creationDateLabel;
        private System.Windows.Forms.TextBox planDescriptionTextBox;
        private System.Windows.Forms.ListView exercisesListView;
        private System.Windows.Forms.Button backButton;
    }
}
