using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ViewAppointmentsForm : Form
    {
        private readonly int memberID;

        public ViewAppointmentsForm(int memberID)
        {
            InitializeComponent();
            this.memberID = memberID;
        }

        private void ViewAppointmentsForm_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "SELECT APPOINTMENTID, TRAINERID, LOCATION1, DURATION, DATE1, TIME1, STATUS1 FROM APPOINTMENT WHERE MEMBERID = @MemberID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MemberID", memberID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Handle cell content click event if needed
        }
    }
}
