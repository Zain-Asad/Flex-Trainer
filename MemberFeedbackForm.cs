using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MemberFeedbackForm : Form
    {
        private int userID;
        private int memberID;
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public MemberFeedbackForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            cmbRating.Items.AddRange(new string[] { "1", "2", "3", "4", "5" });
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cm = new SqlCommand("SELECT MEMBERID FROM MEMBER1 WHERE USERID=@userid", con);
                    cm.Parameters.AddWithValue("@userid", userID);
                    con.Open();
                    memberID = (int)cm.ExecuteScalar();

                    using (SqlCommand cmd = new SqlCommand("giveFeedback", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TRAINERID", int.Parse(txtTrainerId.Text));
                        cmd.Parameters.AddWithValue("@MEMBERID", memberID);
                        cmd.Parameters.AddWithValue("@RATING", int.Parse(cmbRating.SelectedItem.ToString()));
                        cmd.Parameters.AddWithValue("@COMMENT", txtComment.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        lblStatus.Text = "Feedback submitted successfully!";
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }

        private void cmbRating_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: Add logic if needed
        }
    }
}
