using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class viewDiet : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public viewDiet(string connectionStringArg)
        {
            InitializeComponent();
            LoadDietPlans();
        }

        private void LoadDietPlans()
        {
            string query = "SELECT DIETID, PLANNAME FROM DIETPLAN";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int planId = reader.GetInt32(0);
                    string planName = reader.GetString(1);
                    dietPlanListBox.Items.Add(new { Id = planId, Name = planName });
                }
                reader.Close();
            }
        }

        private void OpenDietPlanForm(int planId, string planName)
        {
            // Pass planId and planName to the new form
            DietPlanForm dietPlanForm = new DietPlanForm(planId);
            dietPlanForm.ShowDialog();
        }

        private void dietPlanListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dietPlanListBox.SelectedIndex != -1)
            {
                dynamic selectedPlan = dietPlanListBox.SelectedItem;
                int planId = Convert.ToInt32(selectedPlan.Id);
                string planName = selectedPlan.Name;
                OpenDietPlanForm(planId, planName);
            }
        }

        private void viewDiet_Load(object sender, EventArgs e)
        {

        }
    }
}
