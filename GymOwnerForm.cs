using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GymOwnerForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public GymOwnerForm()
        {
            InitializeComponent();
        }

        private void GymOwnerForm_Load(object sender, EventArgs e)
        {
            LoadGymOwners();
        }

        private void LoadGymOwners()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT GO.OWNERID, U.USERNAME, G.GYMNAME
                                FROM GYMOWNER GO
                                JOIN USERS U ON GO.USERID = U.USERID
                                JOIN GYM G ON GO.OWNERID = G.OWNERID";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable gymOwnerTable = new DataTable();
                adapter.Fill(gymOwnerTable);
                dataGridView1.DataSource = gymOwnerTable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
