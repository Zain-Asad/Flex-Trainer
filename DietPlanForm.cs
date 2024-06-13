using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DietPlanForm : Form
    {
        private int dietId;
        private readonly string connectionString;

        public DietPlanForm(int dietId)
        {
            InitializeComponent();
            this.dietId = dietId;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void DietPlanForm_Load(object sender, EventArgs e)
        {
            LoadDietPlan();
            LoadMeals();
        }

        private void LoadDietPlan()
        {
            string query = "SELECT * FROM DIETPLAN WHERE DIETID = @DietId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DietId", dietId);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        planNameLabel.Text = "Plan Name: " + reader["PLANNAME"].ToString();
                        trainerIdLabel.Text = "Trainer ID: " + reader["TRAINERID"].ToString();
                        creationDateLabel.Text = "Creation Date: " + reader["CREATIONDATE"].ToString();
                        planDescriptionTextBox.Text = reader["PLANDESCRIPTION"].ToString();
                    }
                }
            }
        }

        private void LoadMeals()
        {
            string query = "SELECT MEAL.MEALNAME, MEAL.NUTRITION FROM MEAL " +
                           "INNER JOIN MEALPLAN ON MEAL.MEALID = MEALPLAN.MEALID " +
                           "WHERE MEALPLAN.DIETID = @DietId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DietId", dietId);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MEALNAME"].ToString());
                        item.SubItems.Add(reader["NUTRITION"].ToString());
                        mealsListView.Items.Add(item);
                    }
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
