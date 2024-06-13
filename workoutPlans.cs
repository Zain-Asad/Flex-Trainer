using System;
using System.Configuration;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class workoutPlans : Form
    {
        private int userID;

        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public workoutPlans(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        bool workout = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (!workout)
            {
                workout = true;
                viewWorkout workouts = new viewWorkout();
                workouts.FormClosed += viewWorkoutForm_FormClosed;
                workouts.Show();
                this.Hide();
            }
        }

        private void viewWorkoutForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            workout = false;
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!workout)
            {
                workout = true;
                CreateWorkoutPlanForm workouts = new CreateWorkoutPlanForm(userID);
                workouts.FormClosed += WorkoutPlanFormForm_FormClosed;
                workouts.Show();
                this.Hide();
            }
        }

        private void WorkoutPlanFormForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            workout = false;
            this.Show();
        }
    }
}
