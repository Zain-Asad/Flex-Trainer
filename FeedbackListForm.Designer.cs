namespace WindowsFormsApp1
{
    partial class FeedbackListForm
    {
        private System.Windows.Forms.DataGridView dgvFeedback;
        private System.Windows.Forms.Button btnRefresh;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvFeedback = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedback)).BeginInit();
            this.SuspendLayout();

            // dgvFeedback
            this.dgvFeedback.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeedback.Location = new System.Drawing.Point(12, 12);
            this.dgvFeedback.Name = "dgvFeedback";
            this.dgvFeedback.RowTemplate.Height = 24;
            this.dgvFeedback.Size = new System.Drawing.Size(776, 350);
            this.dgvFeedback.TabIndex = 0;

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(12, 380);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(200, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // FeedbackListForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvFeedback);
            this.Name = "FeedbackListForm";
            this.Text = "Feedback List";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedback)).EndInit();
            this.ResumeLayout(false);
        }
    }


}