using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminGymOwnerApprovalForm : Form
    {
        private readonly string connectionString;
        private SqlConnection conn;

        public AdminGymOwnerApprovalForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void AdminGymOwnerApprovalForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM GYMREGISTRATIONREQUEST";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            UpdateRequest("Approved");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            UpdateRequest("Rejected");
        }

        private void UpdateRequest(string approvalStatus)
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateGymRegistrationRequest", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RequestID", dataGridView1.SelectedRows[0].Cells["REQUESTID"].Value);
                        cmd.Parameters.AddWithValue("@ApprovalStatus", approvalStatus);
                        cmd.Parameters.AddWithValue("@ApprovalDate", DateTime.Today);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Request Updated Successfully!");
                    }
                }
                LoadData(); // Reload data after update
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
