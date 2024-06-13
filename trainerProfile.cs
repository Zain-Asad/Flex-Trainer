using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class trainerProfile : Form
    {
        private int userID;
        private string name;
        private string email;
        private string password;
        private string phoneNumber;
        private int gymID;
        private string gymName;
        private string specialization;
        private int exp;
        private bool isTextHidden = true;

        public trainerProfile(int userID)
        {
            InitializeComponent();
            button1.Text = "Show";
            this.userID = userID;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd;

                cmd = new SqlCommand("SELECT USERNAME FROM USERS WHERE USERID=@userid;", conn);
                cmd.Parameters.AddWithValue("@userid", this.userID);
                name = Convert.ToString(cmd.ExecuteScalar());
                cmd.Dispose();

                cmd = new SqlCommand("SELECT PASSWORD1 FROM USERS WHERE USERID=@userid;", conn);
                cmd.Parameters.AddWithValue("@userid", this.userID);
                password = Convert.ToString(cmd.ExecuteScalar());
                cmd.Dispose();

                cmd = new SqlCommand("SELECT PHONENO FROM USERS WHERE USERID=@userid;", conn);
                cmd.Parameters.AddWithValue("@userid", this.userID);
                phoneNumber = Convert.ToString(cmd.ExecuteScalar());
                cmd.Dispose();

                cmd = new SqlCommand("SELECT EMAIL FROM USERS WHERE USERID=@userid;", conn);
                cmd.Parameters.AddWithValue("@userid", this.userID);
                email = Convert.ToString(cmd.ExecuteScalar());
                cmd.Dispose();

                cmd = new SqlCommand("SELECT GYMID FROM TRAINER WHERE USERID=@userid;", conn);
                cmd.Parameters.AddWithValue("@userid", this.userID);
                gymID = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();

                cmd = new SqlCommand("SELECT GYMNAME FROM GYM WHERE GYMID=@gymid;", conn);
                cmd.Parameters.AddWithValue("@gymid", this.gymID);
                gymName = Convert.ToString(cmd.ExecuteScalar());
                cmd.Dispose();

                label12.Text = name;
                label11.Text = email;
                label10.Text = password;
                label8.Text = phoneNumber;
                label5.Text = gymName;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Optional: Implement functionality for label click event if needed
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Optional: Implement functionality for picture box click event if needed
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Implement functionality for data grid view cell content click event if needed
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ToggleTextVisibility();
        }

        private void ToggleTextVisibility()
        {
            if (isTextHidden)
            {
                label10.Text = password;
                isTextHidden = false;
                button1.Text = "Show";
            }
            else
            {
                label10.Text = new string('*', password.Length);
                isTextHidden = true;
                button1.Text = "Hide";
            }
        }

        private bool IsAdmin(int userId, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM ADMIN1 WHERE USERID=@userid", conn))
            {
                cmd.Parameters.AddWithValue("@userid", userId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
    }
}
