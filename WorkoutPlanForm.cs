using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WorkoutPlanForm : Form
    {
        private int planId;
        private string planName;

        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public WorkoutPlanForm(int planId, string planName)
        {
            InitializeComponent();
            this.planId = planId;
            this.planName = planName;
            LoadPlanDetails();
        }

        private void LoadPlanDetails()
        {
            planNameLabel.Text = planName;

            string query = "SELECT * FROM WORKOUTPLAN WHERE PLANID = @PlanId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlanId", planId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    trainerIdLabel.Text = reader["TRAINERID"].ToString();
                    planDescriptionTextBox.Text = reader["PLANDESCRIPTION"].ToString();
                    creationDateLabel.Text = reader["CREATIONDATE"].ToString();
                }
                reader.Close();
            }

            LoadExercises();
        }

        private void LoadExercises()
        {
            string query = "SELECT E.EXERCISENAME, ED.SETS1, ED.REPS, ED.RESTINTERVAL " +
                           "FROM EXERCISEDESCRIPTION ED " +
                           "JOIN EXERCISE E ON ED.EXERCISEID = E.EXERCISE_ID " +
                           "WHERE ED.PLANID = @PlanId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlanId", planId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string exerciseName = reader["EXERCISENAME"].ToString();
                    int sets = Convert.ToInt32(reader["SETS1"]);
                    int reps = Convert.ToInt32(reader["REPS"]);
                    int restInterval = Convert.ToInt32(reader["RESTINTERVAL"]);

                    ListViewItem item = new ListViewItem(exerciseName);
                    item.SubItems.Add(sets.ToString());
                    item.SubItems.Add(reps.ToString());
                    item.SubItems.Add(restInterval.ToString());
                    exercisesListView.Items.Add(item);
                }
                reader.Close();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void planNameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
