using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CreateWorkoutPlanForm : Form
    {
        private readonly string connectionString;
        private int userID;

        public CreateWorkoutPlanForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void CreateWorkoutPlanForm_Load(object sender, EventArgs e)
        {
            LoadExercises();
        }

        private void LoadExercises()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT EXERCISE_ID, EXERCISENAME FROM EXERCISE";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    lstExercises.DisplayMember = "EXERCISENAME";
                    lstExercises.ValueMember = "EXERCISE_ID";
                    lstExercises.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading exercises: " + ex.Message);
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (lstExercises.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one exercise.");
                return;
            }

            string planName = txtPlanName.Text;
            string planDescription = txtPlanDescription.Text;
            var exerciseIds = lstExercises.SelectedItems.Cast<DataRowView>().Select(item => item["EXERCISE_ID"].ToString());
            string exerciseList = String.Join(",", exerciseIds);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("createWorkoutPlan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TRAINERID", userID);
                    cmd.Parameters.AddWithValue("@PLANNAME", planName);
                    cmd.Parameters.AddWithValue("@PLANDESCRIPTION", planDescription);
                    cmd.Parameters.AddWithValue("@EXERCISELIST", exerciseList);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Workout plan created successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating workout plan: " + ex.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
