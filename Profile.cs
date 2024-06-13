using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Profile : Form
    {
        private int userID;
        private string name;
        private string email;
        private string password;
        private string phoneNumber;
        private int gymID;
        private string gymName;
        private bool isTextHidden = true;

        public Profile(int userID)
        {
            InitializeComponent();
            button1.Text = "Show";
            this.userID = userID;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd;
                if (IsMember(userID, conn))
                {
                    cmd = new SqlCommand("SELECT USERNAME, PASSWORD1, PHONENO, EMAIL, GYMID FROM USERS JOIN MEMBER1 ON USERS.USERID = MEMBER1.USERID WHERE USERS.USERID=@userid;", conn);
                }
                else if (IsAdmin(userID, conn))
                {
                    cmd = new SqlCommand("SELECT USERNAME, PASSWORD1, PHONENO, EMAIL FROM USERS WHERE USERID=@userid;", conn);
                }
                else
                {
                    cmd = new SqlCommand("SELECT USERNAME, PASSWORD1, PHONENO, EMAIL, OWNERID FROM USERS JOIN GYMOWNER ON USERS.USERID = GYMOWNER.USERID WHERE USERS.USERID=@userid;", conn);
                }
                cmd.Parameters.AddWithValue("@userid", this.userID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    name = reader.GetString(0);
                    password = reader.GetString(1);
                    phoneNumber = reader.GetString(2);
                    email = reader.GetString(3);
                    if (IsMember(userID, conn))
                    {
                        gymID = reader.GetInt32(4);
                        cmd = new SqlCommand("SELECT GYMNAME FROM GYM WHERE GYMID=@gymid;", conn);
                        cmd.Parameters.AddWithValue("@gymid", this.gymID);
                        gymName = Convert.ToString(cmd.ExecuteScalar());
                    }
                }
                reader.Close();
                conn.Close();

                label12.Text = name;
                label11.Text = email;
                label10.Text = new string('*', password.Length);
                label8.Text = phoneNumber;
                if (IsMember(userID, conn))
                {
                    label5.Text = gymName;
                }
                else
                {
                    label9.Hide();
                    label5.Hide();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Placeholder for label click event
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Placeholder for picture box click event
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Placeholder for data grid view cell click event
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToggleTextVisibility();
        }

        private void ToggleTextVisibility()
        {
            if (isTextHidden)
            {
                label10.Text = password;
                isTextHidden = false;
                button1.Text = "Hide";
            }
            else
            {
                label10.Text = new string('*', password.Length);
                isTextHidden = true;
                button1.Text = "Show";
            }
        }

        private bool IsAdmin(int userId, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM ADMIN1 WHERE USERID=@userid", conn))
            {
                cmd.Parameters.AddWithValue("@userid", userId);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private bool IsGymOwner(int userId, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM GYMOWNER WHERE USERID=@userid", conn))
            {
                cmd.Parameters.AddWithValue("@userid", userId);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private bool IsMember(int userId, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM MEMBER1 WHERE USERID=@userid", conn))
            {
                cmd.Parameters.AddWithValue("@userid", userId);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Placeholder for label click event
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            // Placeholder for form load event
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Placeholder for button click event
        }
    }
}
