namespace WindowsFormsApp1
{
    partial class MemberFeedbackForm
    {
        private System.Windows.Forms.Label lblTrainerId;
        private System.Windows.Forms.TextBox txtTrainerId;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.ComboBox cmbRating;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblStatus;

        private void InitializeComponent()
        {
            this.lblTrainerId = new System.Windows.Forms.Label();
            this.txtTrainerId = new System.Windows.Forms.TextBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.cmbRating = new System.Windows.Forms.ComboBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTrainerId
            // 
            this.lblTrainerId.AutoSize = true;
            this.lblTrainerId.Location = new System.Drawing.Point(20, 20);
            this.lblTrainerId.Name = "lblTrainerId";
            this.lblTrainerId.Size = new System.Drawing.Size(66, 16);
            this.lblTrainerId.TabIndex = 0;
            this.lblTrainerId.Text = "Trainer ID";
            // 
            // txtTrainerId
            // 
            this.txtTrainerId.Location = new System.Drawing.Point(150, 20);
            this.txtTrainerId.Name = "txtTrainerId";
            this.txtTrainerId.Size = new System.Drawing.Size(100, 22);
            this.txtTrainerId.TabIndex = 1;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(20, 53);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(46, 16);
            this.lblRating.TabIndex = 4;
            this.lblRating.Text = "Rating";
            // 
            // cmbRating
            // 
            this.cmbRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRating.FormattingEnabled = true;
            this.cmbRating.Location = new System.Drawing.Point(150, 53);
            this.cmbRating.Name = "cmbRating";
            this.cmbRating.Size = new System.Drawing.Size(100, 24);
            this.cmbRating.TabIndex = 5;
            this.cmbRating.SelectedIndexChanged += new System.EventHandler(this.cmbRating_SelectedIndexChanged);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(20, 93);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(64, 16);
            this.lblComment.TabIndex = 6;
            this.lblComment.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(150, 93);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(200, 100);
            this.txtComment.TabIndex = 7;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(150, 203);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 30);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(150, 290);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 9;
            // 
            // MemberFeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 330);
            this.Controls.Add(this.lblTrainerId);
            this.Controls.Add(this.txtTrainerId);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.cmbRating);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblStatus);
            this.Name = "MemberFeedbackForm";
            this.Text = "Member Feedback";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
