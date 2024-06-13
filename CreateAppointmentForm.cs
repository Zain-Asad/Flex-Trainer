using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CreateAppointmentForm : Form
    {
        private readonly int userID;
        private readonly string userType;
        private readonly string connectionString;

        public CreateAppointmentForm(int userID, string userType)
        {
            InitializeComponent();
            this.userID = userID;
            this.userType = userType;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void CreateAppointmentForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string query = "";
            switch (userType)
            {
                case "MEMBER":
                    query = "SELECT TRAINERID, USERNAME FROM TRAINER t JOIN USERS u ON t.USERID = u.USERID";
                    break;
                case "TRAINER":
                    query = "SELECT MEMBERID, USERNAME FROM MEMBER1 m JOIN USERS u ON m.USERID = u.USERID";
                    break;
                default:
                    break;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (userType == "MEMBER")
                        {
                            cbxTrainer.DisplayMember = "USERNAME";
                            cbxTrainer.ValueMember = "TRAINERID";
                            cbxTrainer.DataSource = dt;
                        }
                        else if (userType == "TRAINER")
                        {
                            cbxMember.DisplayMember = "USERNAME";
                            cbxMember.ValueMember = "MEMBERID";
                            cbxMember.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int trainerID, memberID;

            if (userType == "MEMBER")
            {
                trainerID = Convert.ToInt32(cbxTrainer.SelectedValue);
                memberID = userID;
            }
            else if (userType == "TRAINER")
            {
                memberID = Convert.ToInt32(cbxMember.SelectedValue);
                trainerID = userID;
            }
            else
            {
                MessageBox.Show("Invalid User Type");
                return;
            }

            string location = txtLocation.Text;
            string duration = txtDuration.Text;
            DateTime date = dtpDate.Value.Date;
            DateTime time = dtpTime.Value;
            string status = "Scheduled";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("CreateAppointment", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TRAINERID", trainerID);
                        cmd.Parameters.AddWithValue("@MEMBERID", memberID);
                        cmd.Parameters.AddWithValue("@LOCATION1", location);
                        cmd.Parameters.AddWithValue("@DURATION", duration);
                        cmd.Parameters.AddWithValue("@DATE1", date);
                        cmd.Parameters.AddWithValue("@TIME1", time);
                        cmd.Parameters.AddWithValue("@STATUS1", status);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Appointment Created Successfully!");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
