using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminMemberForm : Form
    {
        private readonly string connectionString;

        public AdminMemberForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void LoadMembers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MEMBER1";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable memberTable = new DataTable();
                adapter.Fill(memberTable);
                dataGridView1.DataSource = memberTable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implement any cell content click event logic here
        }
    }
}
