namespace WindowsFormsApp1
{
    partial class TrainerAppointmentForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.appointmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memberIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btnUpdateTime = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appointmentIDDataGridViewTextBoxColumn,
            this.memberIDDataGridViewTextBoxColumn,
            this.location1DataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.date1DataGridViewTextBoxColumn,
            this.time1DataGridViewTextBoxColumn,
            this.status1DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.appointmentBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(16, 15);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(995, 185);
            this.dataGridView1.TabIndex = 0;
            // 
            // appointmentIDDataGridViewTextBoxColumn
            // 
            this.appointmentIDDataGridViewTextBoxColumn.DataPropertyName = "APPOINTMENTID";
            this.appointmentIDDataGridViewTextBoxColumn.HeaderText = "Appointment ID";
            this.appointmentIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.appointmentIDDataGridViewTextBoxColumn.Name = "appointmentIDDataGridViewTextBoxColumn";
            this.appointmentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.appointmentIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // memberIDDataGridViewTextBoxColumn
            // 
            this.memberIDDataGridViewTextBoxColumn.DataPropertyName = "MEMBERID";
            this.memberIDDataGridViewTextBoxColumn.HeaderText = "Member ID";
            this.memberIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.memberIDDataGridViewTextBoxColumn.Name = "memberIDDataGridViewTextBoxColumn";
            this.memberIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.memberIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // location1DataGridViewTextBoxColumn
            // 
            this.location1DataGridViewTextBoxColumn.DataPropertyName = "LOCATION1";
            this.location1DataGridViewTextBoxColumn.HeaderText = "Location";
            this.location1DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.location1DataGridViewTextBoxColumn.Name = "location1DataGridViewTextBoxColumn";
            this.location1DataGridViewTextBoxColumn.ReadOnly = true;
            this.location1DataGridViewTextBoxColumn.Width = 125;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "DURATION";
            this.durationDataGridViewTextBoxColumn.HeaderText = "Duration";
            this.durationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.ReadOnly = true;
            this.durationDataGridViewTextBoxColumn.Width = 125;
            // 
            // date1DataGridViewTextBoxColumn
            // 
            this.date1DataGridViewTextBoxColumn.DataPropertyName = "DATE1";
            this.date1DataGridViewTextBoxColumn.HeaderText = "Date";
            this.date1DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.date1DataGridViewTextBoxColumn.Name = "date1DataGridViewTextBoxColumn";
            this.date1DataGridViewTextBoxColumn.ReadOnly = true;
            this.date1DataGridViewTextBoxColumn.Width = 125;
            // 
            // time1DataGridViewTextBoxColumn
            // 
            this.time1DataGridViewTextBoxColumn.DataPropertyName = "TIME1";
            this.time1DataGridViewTextBoxColumn.HeaderText = "Time";
            this.time1DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.time1DataGridViewTextBoxColumn.Name = "time1DataGridViewTextBoxColumn";
            this.time1DataGridViewTextBoxColumn.ReadOnly = true;
            this.time1DataGridViewTextBoxColumn.Width = 125;
            // 
            // status1DataGridViewTextBoxColumn
            // 
            this.status1DataGridViewTextBoxColumn.DataPropertyName = "STATUS1";
            this.status1DataGridViewTextBoxColumn.HeaderText = "Status";
            this.status1DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.status1DataGridViewTextBoxColumn.Name = "status1DataGridViewTextBoxColumn";
            this.status1DataGridViewTextBoxColumn.ReadOnly = true;
            this.status1DataGridViewTextBoxColumn.Width = 125;
            // 
            // appointmentBindingSource
            // 
            //this.appointmentBindingSource.DataSource = typeof(WindowsFormsApp1.TrainerAppointmentForm.Appointment);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 219);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status:";
            // 
            // cbxStatus
            // 
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Items.AddRange(new object[] {
            "Scheduled",
            "Completed",
            "Cancelled"});
            this.cbxStatus.Location = new System.Drawing.Point(73, 215);
            this.cbxStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(160, 24);
            this.cbxStatus.TabIndex = 2;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(243, 213);
            this.btnUpdateStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(100, 28);
            this.btnUpdateStatus.TabIndex = 3;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 258);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 290);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date";
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "hh:mm tt";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(73, 251);
            this.dtpTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(160, 22);
            this.dtpTime.TabIndex = 6;
            // 
            // btnUpdateTime
            // 
            this.btnUpdateTime.Location = new System.Drawing.Point(243, 286);
            this.btnUpdateTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateTime.Name = "btnUpdateTime";
            this.btnUpdateTime.Size = new System.Drawing.Size(100, 28);
            this.btnUpdateTime.TabIndex = 7;
            this.btnUpdateTime.Text = "Update Time";
            this.btnUpdateTime.UseVisualStyleBackColor = true;
            this.btnUpdateTime.Click += new System.EventHandler(this.btnUpdateTime_Click);
            // 
            // TrainerAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 329);
            this.Controls.Add(this.btnUpdateTime);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.cbxStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TrainerAppointmentForm";
            this.Text = "Trainer Appointments";
            this.Load += new System.EventHandler(this.TrainerAppointmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Button btnUpdateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn location1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn date1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn time1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn status1DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource appointmentBindingSource;
    }
}
