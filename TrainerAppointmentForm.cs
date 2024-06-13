using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class TrainerAppointmentForm : Form
    {
        private readonly int trainerID;
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public TrainerAppointmentForm(int trainerID)
        {
            InitializeComponent();
            this.trainerID = trainerID;
        }

        private void TrainerAppointmentForm_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            string query = "SELECT APPOINTMENTID, MEMBERID, LOCATION1, DURATION, DATE1, TIME1, STATUS1 FROM APPOINTMENT WHERE TRAINERID = @TrainerID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrainerID", trainerID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int appointmentID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["appointmentIDDataGridViewTextBoxColumn"].Value);
                string status = cbxStatus.SelectedItem.ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("updateAppointmentStatus", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@APPOINTMENTID", appointmentID);
                        cmd.Parameters.AddWithValue("@STATUS1", status);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Appointment status updated successfully.");
                LoadAppointments();
            }
            else
            {
                MessageBox.Show("Please select an appointment to update.");
            }
        }

        private void btnUpdateTime_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int appointmentID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["appointmentIDDataGridViewTextBoxColumn"].Value);
                TimeSpan time = dtpTime.Value.TimeOfDay;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("updateAppointmentTime", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@APPOINTMENTID", appointmentID);
                        cmd.Parameters.AddWithValue("@TIME1", time);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Appointment time updated successfully.");
                LoadAppointments();
            }
            else
            {
                MessageBox.Show("Please select an appointment to update.");
            }
        }
    }
}
