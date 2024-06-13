namespace WindowsFormsApp1
{
    partial class CreateDietPlanForm
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
            this.lstMeals = new System.Windows.Forms.ListBox();
            this.lblMeals = new System.Windows.Forms.Label();
            this.lblAllergens = new System.Windows.Forms.Label();
            this.lstAllergens = new System.Windows.Forms.ListBox();
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
            // lstMeals
            // 
            this.lstMeals.FormattingEnabled = true;
            this.lstMeals.Location = new System.Drawing.Point(12, 154);
            this.lstMeals.Name = "lstMeals";
            this.lstMeals.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstMeals.Size = new System.Drawing.Size(260, 95);
            this.lstMeals.TabIndex = 4;
            // 
            // lblMeals
            // 
            this.lblMeals.AutoSize = true;
            this.lblMeals.Location = new System.Drawing.Point(12, 138);
            this.lblMeals.Name = "lblMeals";
            this.lblMeals.Size = new System.Drawing.Size(39, 13);
            this.lblMeals.TabIndex = 5;
            this.lblMeals.Text = "Meals:";
            // 
            // lblAllergens
            // 
            this.lblAllergens.AutoSize = true;
            this.lblAllergens.Location = new System.Drawing.Point(12, 256);
            this.lblAllergens.Name = "lblAllergens";
            this.lblAllergens.Size = new System.Drawing.Size(57, 13);
            this.lblAllergens.TabIndex = 6;
            this.lblAllergens.Text = "Allergens:";
            // 
            // lstAllergens
            // 
            this.lstAllergens.FormattingEnabled = true;
            this.lstAllergens.Location = new System.Drawing.Point(12, 272);
            this.lstAllergens.Name = "lstAllergens";
            this.lstAllergens.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstAllergens.Size = new System.Drawing.Size(260, 95);
            this.lstAllergens.TabIndex = 7;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 386);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(197, 386);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CreateDietPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 421);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lstAllergens);
            this.Controls.Add(this.lblAllergens);
            this.Controls.Add(this.lblMeals);
            this.Controls.Add(this.lstMeals);
            this.Controls.Add(this.txtPlanDescription);
            this.Controls.Add(this.lblPlanDescription);
            this.Controls.Add(this.txtPlanName);
            this.Controls.Add(this.lblPlanName);
            this.Name = "CreateDietPlanForm";
            this.Text = "Create Diet Plan";
            this.Load += new System.EventHandler(this.CreateDietPlanForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlanName;
        private System.Windows.Forms.TextBox txtPlanName;
        private System.Windows.Forms.Label lblPlanDescription;
        private System.Windows.Forms.TextBox txtPlanDescription;
        private System.Windows.Forms.ListBox lstMeals;
        private System.Windows.Forms.Label lblMeals;
        private System.Windows.Forms.Label lblAllergens;
        private System.Windows.Forms.ListBox lstAllergens;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnClose;
    }
}
