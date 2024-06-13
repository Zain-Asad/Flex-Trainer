using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class memberHome : Form
    {
        private int userId;
        private int memberID;
        private bool profileopened = false;
        private bool workout = false;
        private bool diet = false;
        private bool feedback = false;
        private bool appointments = false;

        public memberHome(int userId)
        {
            InitializeComponent();
            this.userId = userId;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT MEMBERID FROM MEMBER1 WHERE USERID=@userId", con);
            cmd.Parameters.AddWithValue("@userId", userId);

            con.Open();
            memberID = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!profileopened)
            {
                profileopened = true;
                Profile profileForm = new Profile(userId);
                profileForm.FormClosed += ProfileForm_FormClosed;
                profileForm.Show();
                this.Hide();
            }
        }

        private void ProfileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            profileopened = false;
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!workout)
            {
                workout = true;
                workoutPlans workouts = new workoutPlans(userId);
                workouts.FormClosed += workoutPlansForm_FormClosed;
                workouts.Show();
                this.Hide();
            }
        }

        private void workoutPlansForm_FormClosed(object sender, FormClosedEventArgs e)
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
                diets.FormClosed += dietPlansForm_FormClosed;
                diets.Show();
                this.Hide();
            }
        }

        private void dietPlansForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            diet = false;
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!feedback)
            {
                feedback = true;
                MemberFeedbackForm feedbacks = new MemberFeedbackForm(userId);
                feedbacks.FormClosed += MemberFeedBackFormForm_FormClosed;
                feedbacks.Show();
                this.Hide();
            }
        }

        private void MemberFeedBackFormForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            feedback = false;
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!appointments)
            {
                appointments = true;
                CreateAppointmentForm app = new CreateAppointmentForm(memberID, "MEMBER");
                app.Show();
                app.FormClosed += CreateAppointmentFormForm_FormClosed;
                this.Hide();
            }
        }

        private void CreateAppointmentFormForm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            appointments = false;
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!appointments)
            {
                appointments = true;
                ViewAppointmentsForm app = new ViewAppointmentsForm(memberID);
                app.Show();
                app.FormClosed += ViewAppointmentFormForm_FormClosed;
                this.Hide();
            }
        }

        private void ViewAppointmentFormForm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            appointments = false;
            this.Show();
        }
    }
}
