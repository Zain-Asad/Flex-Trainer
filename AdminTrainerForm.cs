using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdminTrainerForm : Form
    {
        private readonly string connectionString;

        public AdminTrainerForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void TrainerForm_Load(object sender, EventArgs e)
        {
            LoadTrainers();
        }

        private void LoadTrainers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TRAINER";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable trainerTable = new DataTable();
                adapter.Fill(trainerTable);
                dataGridView1.DataSource = trainerTable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implement any cell content click event logic here
        }
    }
}
