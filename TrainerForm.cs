using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class TrainerForm : Form
    {
        private readonly string connectionStringName = "DefaultConnection";
        private readonly int gymID;

        public TrainerForm(int gymID)
        {
            InitializeComponent();
            this.gymID = gymID;
        }

        private void TrainerForm_Load(object sender, EventArgs e)
        {
            LoadTrainers();
        }

        private void LoadTrainers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            string query = "SELECT TrainerID, TrainerName, Specialization FROM TRAINER WHERE GymID = @GymID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GymID", gymID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable trainerTable = new DataTable();
                adapter.Fill(trainerTable);

                dataGridView1.DataSource = trainerTable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click events here if needed
        }
    }
}
