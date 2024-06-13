using System;
using System.Configuration;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class dietPlans : Form
    {
        private int userID;
        private readonly string connectionString;
        private bool diet = false;

        public dietPlans(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!diet)
            {
                diet = true;
                viewDiet diets = new viewDiet(connectionString);
                diets.FormClosed += viewDietForm_FormClosed;
                diets.Show();
                this.Hide();
            }
        }

        private void viewDietForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            diet = false;
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!diet)
            {
                diet = true;
                CreateDietPlanForm diets = new CreateDietPlanForm(userID, connectionString);
                diets.FormClosed += CreateDietPlanFormForm_FormClosed;
                diets.Show();
                this.Hide();
            }
        }

        private void CreateDietPlanFormForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            diet = false;
            this.Show();
        }
    }
}
