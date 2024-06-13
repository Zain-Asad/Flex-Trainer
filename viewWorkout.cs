using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class viewWorkout : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public viewWorkout()
        {
            InitializeComponent();
            LoadWorkoutPlans();
        }

        private void LoadWorkoutPlans()
        {
            string query = "SELECT PLANID, PLANNAME FROM WORKOUTPLAN";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int planId = reader.GetInt32(0);
                    string planName = reader.GetString(1);
                    workoutPlanListBox.Items.Add(new { Id = planId, Name = planName });
                }
                reader.Close();
            }
        }

        private void OpenWorkoutPlanForm(int planId, string planName)
        {
            // Pass planId and planName to the new form
            WorkoutPlanForm workoutPlanForm = new WorkoutPlanForm(planId, planName);
            workoutPlanForm.ShowDialog();
        }

        private void viewWorkout_Load(object sender, EventArgs e)
        {

        }

        private void workoutPlanListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (workoutPlanListBox.SelectedIndex != -1)
            {
                dynamic selectedPlan = workoutPlanListBox.SelectedItem;
                int planId = Convert.ToInt32(selectedPlan.Id);
                string planName = selectedPlan.Name;
                OpenWorkoutPlanForm(planId, planName);
            }
        }
    }
}
