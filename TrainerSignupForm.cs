using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class TrainerSignupForm : Form
    {
        private readonly SqlConnection conn;

        public TrainerSignupForm()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        private void TrainerSignupForm_Load(object sender, EventArgs e)
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
            string specialization = txtSpecialization.Text.Trim();
            int experience = (int)numExperience.Value;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNo) || string.IsNullOrEmpty(specialization))
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
                using (SqlCommand cmd = new SqlCommand("RegisterTrainer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password1", password);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNo", phoneNo);
                    cmd.Parameters.AddWithValue("@Specialization", specialization);
                    cmd.Parameters.AddWithValue("@Experience", experience);
                    cmd.Parameters.AddWithValue("@gymid", gymID);
                    // For now, setting GymOwnerID to 1, you might need to change this.
                    cmd.Parameters.AddWithValue("@GymOwnerID", 1);
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
            txtSpecialization.Text = "";
            numExperience.Value = 0;
            cmbGym.SelectedIndex = -1;
        }
    }
}
