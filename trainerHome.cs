using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class trainerHome : Form
    {
        private readonly int userId;
        private int trainerID;
        private bool profileOpened = false;
        private bool workout = false;
        private bool diet = false;
        private bool feedback = false;
        private bool appointments = false;

        public trainerHome(int userId)
        {
            InitializeComponent();
            this.userId = userId;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TRAINERID FROM TRAINER WHERE USERID=@userId", con);
                cmd.Parameters.AddWithValue("@userId", userId);
                trainerID = (int)cmd.ExecuteScalar();
                cmd.Dispose();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!profileOpened)
            {
                profileOpened = true;
                Profile profileForm = new Profile(userId);
                profileForm.FormClosed += ProfileForm_FormClosed;
                profileForm.Show();
                this.Hide();
            }
        }

        private void ProfileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            profileOpened = false;
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!workout)
            {
                workout = true;
                workoutPlans workouts = new workoutPlans(userId);
                workouts.FormClosed += WorkoutPlansForm_FormClosed;
                workouts.Show();
                this.Hide();
            }
        }

        private void WorkoutPlansForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            workout = false;
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!diet)
            {
                diet = true;
                dietPlans diets = new dietPlans(userId);
                diets.FormClosed += DietPlansForm_FormClosed;
                diets.Show();
                this.Hide();
            }
        }

        private void DietPlansForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            diet = false;
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!feedback)
            {
                feedback = true;
                FeedbackListForm feed = new FeedbackListForm(userId);
                feed.FormClosed += FeedbackListForm_FormClosed;
                feed.Show();
                this.Hide();
            }
        }

        private void FeedbackListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            feedback = false;
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!appointments)
            {
                appointments = true;
                TrainerAppointmentForm app = new TrainerAppointmentForm(trainerID);
                app.FormClosed += TrainerAppointmentForm_FormClosed;
                app.Show();
                this.Hide();
            }
        }

        private void TrainerAppointmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            appointments = false;
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!appointments)
            {
                appointments = true;
                CreateAppointmentForm app = new CreateAppointmentForm(trainerID, "TRAINER");
                app.FormClosed += CreateAppointmentForm_FormClosed;
                app.Show();
                this.Hide();
            }
        }

        private void CreateAppointmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            appointments = false;
            this.Show();
        }
    }
}
