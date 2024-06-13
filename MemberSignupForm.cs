using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class MemberSignupForm : Form
    {
        private readonly SqlConnection conn;

        public MemberSignupForm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }

        private void MemberSignupForm_Load(object sender, EventArgs e)
        {
            LoadGyms();
        }

        private void LoadGyms()
        {
            try
            {
                conn.Open();
                string query = "SELECT GYMID, GYMNAME FROM GYM";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int gymID = reader.GetInt32(0);
                        string gymName = reader.GetString(1);
                        cmbGym.Items.Add(new GymItem(gymID, gymName));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phoneNo = txtPhoneNo.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNo))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (cmbGym.SelectedItem == null)
            {
                MessageBox.Show("Please select a gym.");
                return;
            }

            int gymID = ((GymItem)cmbGym.SelectedItem).GymID;

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("RegisterMember", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password1", password);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNo", phoneNo);
                    cmd.Parameters.AddWithValue("@GymID", gymID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration successful!");
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void ClearFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
            cmbGym.SelectedIndex = -1;
        }
    }

    public class GymItem
    {
        public int GymID { get; set; }
        public string GymName { get; set; }

        public GymItem(int gymID, string gymName)
        {
            GymID = gymID;
            GymName = gymName;
        }

        public override string ToString()
        {
            return GymName;
        }
    }
}
