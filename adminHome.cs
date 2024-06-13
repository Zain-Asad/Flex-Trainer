using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class adminHome : Form
    {
        private int userId;
        bool profileopened = false;
        public adminHome(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!profileopened)
            {
                profileopened = true;
                Profile profileForm = new Profile(userId);
                profileForm.FormClosed += ProfileForm_FormClosed;
                profileForm.Show();
                this.Hide();
            }
        }

        private void ProfileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            profileopened = false;
            this.Show();
        }
        bool approvals = false;
        private void button7_Click(object sender, EventArgs e)
        {
            if(!approvals) { 
                AdminGymOwnerApprovalForm form = new AdminGymOwnerApprovalForm();
                form.Show();
                form.FormClosed += AdminGymOwnerApprovalFormForm_FormClosed;
                approvals = true;
                this.Hide();
            }
        }
        private void AdminGymOwnerApprovalFormForm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            approvals=false;
            this.Show();
        }
        bool audits = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!audits)
            {
                audits = true;
                AdminTrainerForm form = new AdminTrainerForm();
                form.Show();
                this.Hide();
                form.FormClosed += AdminTrainerFormForm_FormClosed;
            }
        }

        private void AdminTrainerFormForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            audits=false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!audits)
            {
                audits = true;
                AdminMemberForm form = new AdminMemberForm();
                form.Show();
                this.Hide();
                form.FormClosed += AdminMemberFormForm_FormClosed;
            }
        }
        private void AdminMemberFormForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            audits = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!audits)
            {
                audits = true;
                GymOwnerForm form = new GymOwnerForm();
                form.Show();
                this.Hide();
                form.FormClosed += GymOwnerFormForm_FormClosed;
            }
        }

        private void GymOwnerFormForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            audits = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
