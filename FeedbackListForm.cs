using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FeedbackListForm : Form
    {
        private int userId;
        private readonly string connectionString;

        public FeedbackListForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            LoadFeedbacks();
        }

        private void LoadFeedbacks()
        {
            int trainerId = GetTrainerIdFromUserId(userId);
            if (trainerId == -1)
            {
                MessageBox.Show("Trainer not found for this user.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT FEEDBACKID, MEMBERID, RATING, COMMENT, DATE1 
                FROM FEEDBACK 
                WHERE TRAINERID = @TrainerId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrainerId", trainerId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvFeedback.DataSource = dt;
            }
        }

        private int GetTrainerIdFromUserId(int userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TRAINERID FROM TRAINER WHERE USERID = @UserId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFeedbacks();
        }
    }
}
