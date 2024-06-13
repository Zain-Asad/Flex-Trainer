using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MemberForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private int gymID;

        public MemberForm(int gymID)
        {
            InitializeComponent();
            this.gymID = gymID;
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void LoadMembers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MEMBER1 WHERE GYMID = @GymID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GymID", gymID);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable memberTable = new DataTable();
                adapter.Fill(memberTable);
                dataGridView1.DataSource = memberTable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Add logic if needed
        }
    }
}
