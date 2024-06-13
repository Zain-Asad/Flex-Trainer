using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GymOwnerApprovalForm : Form
    {
        private readonly int gymOwnerId;
        private readonly string approvalType;
        private readonly SqlConnection conn;

        public GymOwnerApprovalForm(int gymOwnerId, string approvalType)
        {
            InitializeComponent();
            this.gymOwnerId = gymOwnerId;
            this.approvalType = approvalType;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }

        private void GymOwnerApprovalForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                conn.Open();
                string query = "";
                switch (approvalType)
                {
                    case "MEMBER":
                        query = "SELECT * FROM MEMBERREGISTRATIONREQUEST WHERE OWNERID=@GymOwnerId";
                        break;
                    case "TRAINER":
                        query = "SELECT * FROM TRAINERREGISTRATIONREQUEST WHERE GYMOWNERID=@GymOwnerId";
                        break;
                    default:
                        break;
                }
                if (query != "")
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GymOwnerId", gymOwnerId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
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
                conn.Open();
                string query = "";
                switch (approvalType)
                {
                    case "MEMBER":
                        query = "UpdateMemberRegistrationRequest";
                        break;
                    case "TRAINER":
                        query = "UpdateTrainerRegistrationRequest";
                        break;
                    default:
                        break;
                }

                if (query != "")
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RequestID", dataGridView1.SelectedRows[0].Cells["REQUESTID"].Value);
                        cmd.Parameters.AddWithValue("@ApprovalStatus", approvalStatus);
                        cmd.Parameters.AddWithValue("@ApprovalDate", DateTime.Today);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Request Updated Successfully!");
                    }
                }
                LoadData(); // Refresh data after update
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Add logic if needed
        }
    }
}
