using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GymOwnerSignupForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public GymOwnerSignupForm()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            string phoneNo = txtPhoneNo.Text;
            string gymName = txtGymName.Text;
            string location = txtLocation.Text;
            string contactNumber = txtContactNumber.Text;
            string gymEmail = txtGymEmail.Text;

            RegisterGymOwner(username, password, email, phoneNo, gymName, location, contactNumber, gymEmail);
        }

        private void RegisterGymOwner(string username, string password, string email, string phoneNo, string gymName, string location, string contactNumber, string gymEmail)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("RegisterGymOwner", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password1", password);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PhoneNo", phoneNo);
                        cmd.Parameters.AddWithValue("@GymName", gymName);
                        cmd.Parameters.AddWithValue("@Location1", location);
                        cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                        cmd.Parameters.AddWithValue("@GymEmail", gymEmail);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Gym Owner registered successfully. Your request is pending for approval.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtGymEmail_TextChanged(object sender, EventArgs e)
        {
            // Optional: Add logic if needed
        }
    }
}
