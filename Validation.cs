using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Lab11
{
    public partial class Validation : Form
    {
        public Validation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;
            string un = textBox1.Text.Trim();
            string pass = textBox2.Text.Trim();
            if (un == "" || pass == "")
            {
                MessageBox.Show("Invalid Input");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT USERID FROM USERS WHERE username = @Username AND PASSWORD1 = @Password";
                using (SqlCommand cm = new SqlCommand(query, conn))
                {
                    cm.Parameters.AddWithValue("@Username", un);
                    cm.Parameters.AddWithValue("@Password", pass);
                    object ret = cm.ExecuteScalar();
                    if (ret != null)
                    {
                        int userID = Convert.ToInt32(ret);
                        if (IsAdmin(userID, conn))
                        {
                            OpenAdminHome(userID);
                        }
                        else if (IsGymOwner(userID, conn))
                        {
                            int gymID = GetGymID(userID, conn);
                            if (IsApproved("GYMREGISTRATIONREQUEST", "GYMID", gymID, conn))
                                OpenOwnerHome(userID);
                            else
                                MessageBox.Show("Gym owner account not yet approved.");
                        }
                        else if (IsTrainer(userID, conn))
                        {
                            int trainerID = GetTrainerID(userID, conn);
                            if (IsApproved("TRAINERREGISTRATIONREQUEST", "TRAINERID", trainerID, conn))
                                OpenTrainerHome(userID);
                            else
                                MessageBox.Show("Trainer account not yet approved.");
                        }
                        else if (IsMember(userID, conn))
                        {
                            int memberID = GetMemberID(userID, conn);
                            if (IsApproved("MEMBERREGISTRATIONREQUEST", "MEMBERID", memberID, conn))
                                OpenMemberHome(userID);
                            else
                                MessageBox.Show("Member account not yet approved.");
                        }
                        else
                        {
                            MessageBox.Show("No valid user role found.");
                        }
                    }
                    else
                    {
                        textBox2.Clear();
                        label4.Visible = true;
                    }
                }
            }
        }

        private int GetGymID(int userId, SqlConnection conn)
        {
            string query = "SELECT GYMID FROM GYM WHERE OWNERID=(SELECT OWNERID FROM GYMOWNER WHERE USERID=@UserId)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                object ret = cmd.ExecuteScalar();
                return ret != null ? Convert.ToInt32(ret) : -1;
            }
        }

        private int GetTrainerID(int userId, SqlConnection conn)
        {
            string query = "SELECT TRAINERID FROM TRAINER WHERE USERID=@UserId";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                object ret = cmd.ExecuteScalar();
                return ret != null ? Convert.ToInt32(ret) : -1;
            }
        }

        private int GetMemberID(int userId, SqlConnection conn)
        {
            string query = "SELECT MEMBERID FROM MEMBER1 WHERE USERID=@UserId";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                object ret = cmd.ExecuteScalar();
                return ret != null ? Convert.ToInt32(ret) : -1;
            }
        }

        private bool IsAdmin(int userId, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM ADMIN1 WHERE USERID=@userid", conn))
            {
                cmd.Parameters.AddWithValue("@userid", userId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private bool IsApproved(string tableName, string idColumn, int id, SqlConnection conn)
        {
            string approvalStatusQuery = $"SELECT COUNT(1) FROM {tableName} " +
                                         $"WHERE {idColumn}=@id AND APPROVALSTATUS='Approved'";
            using (SqlCommand cmd = new SqlCommand(approvalStatusQuery, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private bool IsGymOwner(int userId, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM GYMOWNER WHERE USERID=@userid", conn))
            {
                cmd.Parameters.AddWithValue("@userid", userId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private bool IsTrainer(int userId, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM TRAINER WHERE USERID=@userid", conn))
            {
                cmd.Parameters.AddWithValue("@userid", userId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private bool IsMember(int userId, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM MEMBER1 WHERE USERID=@userid", conn))
            {
                cmd.Parameters.AddWithValue("@userid", userId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void OpenMemberHome(int userId)
        {
            this.Hide();
            memberHome memberForm = new memberHome(userId);
            memberForm.FormClosed += (s, args) => this.Show();
            memberForm.Show();
        }

        private void OpenOwnerHome(int userId)
        {
            this.Hide();
            ownerHome ownerForm = new ownerHome(userId);
            ownerForm.FormClosed += (s, args) => this.Show();
            ownerForm.Show();
        }

        private void OpenTrainerHome(int userId)
        {
            this.Hide();
            trainerHome trainerForm = new trainerHome(userId);
            trainerForm.FormClosed += (s, args) => this.Show();
            trainerForm.Show();
        }

        private void OpenAdminHome(int userId)
        {
            this.Hide();
            adminHome adminForm = new adminHome(userId);
            adminForm.FormClosed += (s, args) => this.Show();
            adminForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Signup signUpForm = new Signup();
            signUpForm.FormClosed += (s, args) => this.Show();
            signUpForm.Show();
        }
    }
}
