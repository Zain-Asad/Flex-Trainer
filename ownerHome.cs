using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class ownerHome : Form
    {
        private int userId;
        private int ownerId;
        private int gymId;
        bool profileopened = false;
        bool approvals = false;
        bool audits = false;

        public ownerHome(int userId)
        {
            InitializeComponent();
            this.userId = userId;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT OWNERID FROM GYMOWNER WHERE USERID=@userId", con);
                cmd.Parameters.AddWithValue("@userId", userId);
                ownerId = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("SELECT GYMID FROM GYM WHERE OWNERID=@ownerId", con);
                cmd.Parameters.AddWithValue("@ownerId", ownerId);
                gymId = (int)cmd.ExecuteScalar();

                con.Close();
            }
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (!approvals)
            {
                approvals = true;
                GymOwnerApprovalForm form = new GymOwnerApprovalForm(ownerId, "TRAINER");
                form.Show();
                form.FormClosed += GymOwnerApprovalFormForm_FormClosed;
                this.Hide();
            }
        }

        private void GymOwnerApprovalFormForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            approvals = false;
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!approvals)
            {
                approvals = true;
                GymOwnerApprovalForm form = new GymOwnerApprovalForm(ownerId, "MEMBER");
                form.Show();
                form.FormClosed += GymOwnerApprovalFormForm_FormClosed;
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!audits)
            {
                audits = true;
                TrainerForm form = new TrainerForm(gymId);
                form.Show();
                form.FormClosed += TrainerFormForm_FormClosed;
                this.Hide();
            }
        }

        private void TrainerFormForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            audits = false;
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!audits)
            {
                audits = true;
                MemberForm form = new MemberForm(gymId);
                form.Show();
                form.FormClosed += MemberFormForm_FormClosed;
                this.Hide();
            }
        }

        private void MemberFormForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            audits = false;
            this.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
